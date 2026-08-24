using DentalClinic.DTO;
using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.DAL
{
    public class Invoice_DAL
    {
        private readonly AppDbContext _context = new AppDbContext();

        // 1. Lấy danh sách những người đã khám xong nhưng chưa xuất hóa đơn Paid
        public List<WaitingPaymentDto> GetWaitingPayments(string keyword)
        {
            var query = _context.Visits
                .Where(v => v.Status == VisitStatus.Completed)
                // Loại trừ những ca đã thanh toán rồi (đã có hóa đơn Paid)
                .Where(v => !_context.Invoices.Any(i => i.VisitId == v.VisitId && i.Status == InvoiceStatus.Paid));

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(v => v.Patient.FullName.Contains(keyword) || v.Patient.Phone.Contains(keyword));
            }

            return query.Select(v => new WaitingPaymentDto
            {
                VisitId = v.VisitId,
                PatientName = v.Patient.FullName,
                Phone = v.Patient.Phone,
                DoctorName = v.Doctor.FullName,
                CheckInDateTime = v.CheckInDateTime,
                CompletedTime = _context.MedicalRecords
                                .Where(m => m.VisitId == v.VisitId)
                                .Select(m => m.ExaminationDateTime)
                                .FirstOrDefault()
            })
                .OrderBy(v => v.CompletedTime) // Sắp xếp khám xong trước thì nằm trên cùng
                .ToList();
        }

        // 2. Gom chung Dịch vụ và Thuốc vào 1 danh sách
        public List<InvoiceDetailDisplayDto> GetInvoiceDetailsByVisit(int visitId)
        {
            var result = new List<InvoiceDetailDisplayDto>();

            var record = _context.MedicalRecords.FirstOrDefault(m => m.VisitId == visitId);
            if (record == null) return result;

            // Kéo Dịch vụ
            var services = _context.MedicalRecordServices
                .Where(s => s.MedicalRecordId == record.MedicalRecordId)
                .Select(s => new InvoiceDetailDisplayDto
                {
                    ItemType = "Dịch vụ",
                    ItemName = s.Service.ServiceName,
                    Quantity = s.Quantity,
                    UnitPrice = s.UnitPrice,
                    TotalAmount = s.TotalAmount,
                    MedicalRecordServiceId = s.MedicalRecordServiceId,
                    PrescriptionDetailId = null
                }).ToList();
            result.AddRange(services);

            // Kéo Thuốc
            var prescription = _context.Prescriptions.FirstOrDefault(p => p.MedicalRecordId == record.MedicalRecordId);
            if (prescription != null)
            {
                var medicines = _context.PrescriptionDetails
                    .Where(p => p.PrescriptionId == prescription.PrescriptionId)
                    .Select(p => new InvoiceDetailDisplayDto
                    {
                        ItemType = "Thuốc",
                        ItemName = p.Medicine.MedicineName,
                        Quantity = p.Quantity,
                        UnitPrice = p.Medicine.UnitPrice,
                        TotalAmount = p.Quantity * p.Medicine.UnitPrice,
                        MedicalRecordServiceId = null,
                        PrescriptionDetailId = p.PrescriptionDetailId
                    }).ToList();
                result.AddRange(medicines);
            }

            return result;
        }

        public bool CheckoutInvoice(int visitId, int paymentMethodId, int receptionistId, decimal totalAmount, decimal amountGiven, decimal changeAmount, List<InvoiceDetailDisplayDto> details)
        {
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    // 1. Tạo Hóa đơn tổng (Invoice)
                    var invoice = new Invoice
                    {
                        VisitId = visitId,
                        PaymentMethodId = paymentMethodId,
                        ReceptionistId = receptionistId, 
                        InvoiceDateTime = DateTime.Now,
                        TotalAmount = totalAmount,
                        AmountGiven = amountGiven,    
                        ChangeAmount = changeAmount,
                        Status = InvoiceStatus.Paid 
                    };

                    _context.Invoices.Add(invoice);
                    _context.SaveChanges(); // Lưu nhịp 1 để lấy ra InvoiceId

                    // 2. Chép chi tiết Dịch vụ & Thuốc vào InvoiceDetail
                    var invoiceDetails = details.Select(d => new InvoiceDetail
                    {
                        InvoiceId = invoice.InvoiceId,
                        ItemName = d.ItemName,
                        Quantity = d.Quantity,
                        UnitPrice = d.UnitPrice,
                        TotalAmount = d.TotalAmount,
                        MedicalRecordServiceId = d.MedicalRecordServiceId,
                        PrescriptionDetailId = d.PrescriptionDetailId
                    }).ToList();

                    _context.InvoiceDetails.AddRange(invoiceDetails);


                    // 3. Trừ tồn kho thuốc
                    // Lấy ra danh sách các ID Chi tiết đơn thuốc có trong hóa đơn 
                    var prescriptionDetailIds = details
                        .Where(d => d.PrescriptionDetailId.HasValue)
                        .Select(d => d.PrescriptionDetailId.Value)
                        .ToList();

                    // Tìm các loại thuốc tương ứng và trừ số lượng
                    if (prescriptionDetailIds.Any())
                    {
                        var prescriptionDetails = _context.PrescriptionDetails
                            .Where(p => prescriptionDetailIds.Contains(p.PrescriptionDetailId))
                            .ToList();

                        foreach (var pDetail in prescriptionDetails)
                        {
                            var medicine = _context.Medicines.Find(pDetail.MedicineId);
                            if (medicine != null)
                            {
                                medicine.QuantityInStock -= pDetail.Quantity;
                                _context.Medicines.Update(medicine);
                            }
                        }
                    }

                    // 4. Kết thúc transaction
                    _context.SaveChanges();
                    trans.Commit();
                    return true;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public List<PaymentMethod> GetPaymentMethods()
        {
            return _context.PaymentMethods.ToList();
        }

        public List<InvoiceDisplayDto> GetAllInvoices(DateTime fromDate, DateTime toDate, InvoiceStatus? status)
        {
            var query = _context.Invoices.AsQueryable();

            // Lọc theo khoảng thời gian (từ 00:00:00 của ngày bắt đầu đến 23:59:59 của ngày kết thúc)
            query = query.Where(i => i.InvoiceDateTime >= fromDate.Date
                                  && i.InvoiceDateTime <= toDate.Date.AddDays(1).AddTicks(-1));

            // Lọc theo trạng thái
            if (status.HasValue)
            {
                query = query.Where(i => i.Status == status.Value);
            }

            return query.Select(i => new InvoiceDisplayDto
            {
                InvoiceId = i.InvoiceId,
                InvoiceDateTime = i.InvoiceDateTime,
                PatientName = i.Visit.Patient.FullName,
                ReceptionistName = i.Receptionist.FullName,
                PaymentMethodName = i.PaymentMethod.PaymentMethodName,
                TotalAmount = i.TotalAmount,
                AmountGiven = i.AmountGiven,
                ChangeAmount = i.ChangeAmount,
                Status = i.Status == InvoiceStatus.Paid ? "Đã thanh toán" :
                 i.Status == InvoiceStatus.Pending ? "Chờ thanh toán" : "Đã hủy"
            })
            .OrderByDescending(i => i.InvoiceDateTime)
            .ToList();
        }
    }
}
