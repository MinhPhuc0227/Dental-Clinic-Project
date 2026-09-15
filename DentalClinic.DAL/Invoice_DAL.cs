using DentalClinic.DTO;
using DentalClinic.MODEL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DentalClinic.DAL
{
    public class Invoice_DAL
    {
        private readonly AppDbContext _context;

        public Invoice_DAL(AppDbContext context)
        {
            _context = context;
        }

        // 1. Lấy danh sách chờ thanh toán
        public List<WaitingPaymentDto> GetWaitingPayments(DateTime startDate, DateTime endDate, string keyword)
        {
            DateTime start = startDate.Date;
            DateTime end = endDate.Date.AddDays(1);

            var query = _context.Invoices
                .Include(i => i.Visit).ThenInclude(v => v.Patient)
                .Include(i => i.Visit).ThenInclude(v => v.Doctor)
                .Where(i => i.Status == InvoiceStatus.Unpaid)
                .Where(i => i.InvoiceDateTime >= start && i.InvoiceDateTime < end);

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string kw = keyword.Trim().ToLower();
                query = query.Where(i => i.Visit.Patient.FullName.ToLower().Contains(kw) || i.Visit.Patient.Phone.Contains(kw));
            }

            return query
                .OrderBy(i => i.InvoiceDateTime)
                .Select(i => new WaitingPaymentDto
                {
                    InvoiceId = i.InvoiceId,
                    VisitId = i.VisitId,
                    PatientName = i.Visit.Patient.FullName,
                    Phone = i.Visit.Patient.Phone,
                    DoctorName = i.Visit.Doctor.FullName,
                    InvoiceDateTime = i.InvoiceDateTime
                })
                .ToList();
        }

        // 2. Gom chung Dịch vụ và Thuốc vào 1 danh sách theo ca khám
        public List<InvoiceDetailDisplayDto> GetInvoiceDetailsByVisit(int visitId)
        {
            var result = new List<InvoiceDetailDisplayDto>();

            var record = _context.MedicalRecords.FirstOrDefault(m => m.VisitId == visitId);
            if (record == null) return result;

            // Dịch vụ
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

            // Thuốc
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

        // Lấy chi tiết hóa đơn theo InvoiceId
        public List<InvoiceDetailDisplayDto> GetInvoiceDetailsByInvoiceId(int invoiceId)
        {
            return _context.InvoiceDetails
                .Where(d => d.InvoiceId == invoiceId)
                .Select(d => new InvoiceDetailDisplayDto
                {
                    ItemType = d.MedicalRecordServiceId.HasValue ? "Dịch vụ" : "Thuốc",
                    ItemName = d.ItemName,
                    Quantity = d.Quantity,
                    UnitPrice = d.UnitPrice,
                    TotalAmount = d.TotalAmount,
                    MedicalRecordServiceId = d.MedicalRecordServiceId,
                    PrescriptionDetailId = d.PrescriptionDetailId
                })
                .ToList();
        }

        // Lấy hóa đơn chưa thanh toán theo VisitId
        public Invoice? GetUnpaidInvoiceByVisitId(int visitId)
        {
            return _context.Invoices.FirstOrDefault(i => i.VisitId == visitId && i.Status == InvoiceStatus.Unpaid);
        }

        // Tạo hóa đơn chưa thanh toán
        public bool CreateUnpaidInvoice(int visitId)
        {
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    var visit = _context.Visits
                        .Include(v => v.MedicalRecord).ThenInclude(m => m.MedicalRecordServices)
                        .Include(v => v.MedicalRecord).ThenInclude(m => m.Prescription).ThenInclude(p => p.PrescriptionDetails)
                        .FirstOrDefault(v => v.VisitId == visitId);

                    if (visit == null) throw new InvalidOperationException("Không tìm thấy ca khám.");
                    if (visit.MedicalRecord == null) throw new InvalidOperationException("Ca khám chưa có hồ sơ bệnh án.");

                    bool hasUnpaidInvoice = _context.Invoices.Any(i => i.VisitId == visitId && i.Status == InvoiceStatus.Unpaid);
                    if (hasUnpaidInvoice) throw new InvalidOperationException("Ca khám này đã có hóa đơn chưa thanh toán.");

                    bool hasPaidInvoice = _context.Invoices.Any(i => i.VisitId == visitId && i.Status == InvoiceStatus.Paid);
                    if (hasPaidInvoice) throw new InvalidOperationException("Ca khám này đã có hóa đơn đã thanh toán.");

                    var record = visit.MedicalRecord;

                    var services = _context.MedicalRecordServices
                        .Include(s => s.Service)
                        .Where(s => s.MedicalRecordId == record.MedicalRecordId)
                        .ToList();

                    var medicines = new List<PrescriptionDetail>();
                    if (record.Prescription != null)
                    {
                        medicines = _context.PrescriptionDetails
                            .Include(p => p.Medicine)
                            .Where(p => p.PrescriptionId == record.Prescription.PrescriptionId)
                            .ToList();
                    }

                    if (!services.Any() && !medicines.Any())
                        throw new InvalidOperationException("Hồ sơ bệnh án chưa có dịch vụ hoặc thuốc.");

                    var invoice = new Invoice
                    {
                        VisitId = visitId,
                        ReceptionistId = visit.ReceptionistId,
                        PaymentMethodId = null,
                        InvoiceDateTime = DateTime.Now,
                        TotalAmount = 0,
                        AmountGiven = 0,
                        ChangeAmount = 0,
                        Status = InvoiceStatus.Unpaid
                    };

                    _context.Invoices.Add(invoice);
                    _context.SaveChanges();

                    decimal totalAmount = 0;

                    foreach (var service in services)
                    {
                        var detail = new InvoiceDetail
                        {
                            InvoiceId = invoice.InvoiceId,
                            ItemName = service.Service.ServiceName,
                            Quantity = service.Quantity,
                            UnitPrice = service.UnitPrice,
                            TotalAmount = service.TotalAmount,
                            MedicalRecordServiceId = service.MedicalRecordServiceId,
                            PrescriptionDetailId = null
                        };

                        _context.InvoiceDetails.Add(detail);
                        totalAmount += service.TotalAmount;
                    }

                    foreach (var medicine in medicines)
                    {
                        decimal medicineTotal = medicine.Quantity * medicine.Medicine.UnitPrice;

                        var detail = new InvoiceDetail
                        {
                            InvoiceId = invoice.InvoiceId,
                            ItemName = medicine.Medicine.MedicineName,
                            Quantity = medicine.Quantity,
                            UnitPrice = medicine.Medicine.UnitPrice,
                            TotalAmount = medicineTotal,
                            MedicalRecordServiceId = null,
                            PrescriptionDetailId = medicine.PrescriptionDetailId
                        };

                        _context.InvoiceDetails.Add(detail);
                        totalAmount += medicineTotal;
                    }

                    invoice.TotalAmount = totalAmount;
                    _context.SaveChanges();

                    trans.Commit();
                    return true;
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        // Thanh toán hóa đơn
        public bool CheckoutInvoice(int invoiceId, int paymentMethodId, int receptionistId, decimal amountGiven, decimal changeAmount)
        {
            using var trans = _context.Database.BeginTransaction();

            try
            {
                var invoice = _context.Invoices.FirstOrDefault(i => i.InvoiceId == invoiceId);
                if (invoice == null) throw new InvalidOperationException("Không tìm thấy hóa đơn.");

                if (invoice.Status != InvoiceStatus.Unpaid)
                    throw new InvalidOperationException("Hóa đơn này không ở trạng thái chưa thanh toán.");

                var paymentMethod = _context.PaymentMethods.FirstOrDefault(p => p.PaymentMethodId == paymentMethodId);
                if (paymentMethod == null) throw new InvalidOperationException("Không tìm thấy phương thức thanh toán.");

                var receptionist = _context.Receptionists.FirstOrDefault(r => r.ReceptionistId == receptionistId);
                if (receptionist == null) throw new InvalidOperationException("Không tìm thấy nhân viên thanh toán.");

                if (amountGiven < invoice.TotalAmount)
                    throw new InvalidOperationException("Số tiền khách đưa chưa đủ.");

                invoice.PaymentMethodId = paymentMethodId;
                invoice.ReceptionistId = receptionistId;
                invoice.AmountGiven = amountGiven;
                invoice.ChangeAmount = changeAmount;
                invoice.Status = InvoiceStatus.Paid;

                var visit = _context.Visits.FirstOrDefault(v => v.VisitId == invoice.VisitId);
                if (visit == null) throw new InvalidOperationException("Không tìm thấy ca khám.");

                var prescriptionDetails = _context.InvoiceDetails
                    .Where(d => d.InvoiceId == invoiceId && d.PrescriptionDetailId.HasValue)
                    .ToList();

                foreach (var detail in prescriptionDetails)
                {
                    if (!detail.PrescriptionDetailId.HasValue) continue;

                    var prescriptionDetail = _context.PrescriptionDetails
                        .FirstOrDefault(p => p.PrescriptionDetailId == detail.PrescriptionDetailId.Value);

                    if (prescriptionDetail == null) continue;

                    var medicine = _context.Medicines
                        .FirstOrDefault(m => m.MedicineId == prescriptionDetail.MedicineId);

                    if (medicine == null) throw new InvalidOperationException($"Không tìm thấy thuốc có mã {prescriptionDetail.MedicineId}.");

                    if (medicine.QuantityInStock < detail.Quantity)
                        throw new InvalidOperationException($"Thuốc '{medicine.MedicineName}' không đủ tồn kho.");

                    medicine.QuantityInStock -= detail.Quantity;
                }

                visit.Status = VisitStatus.Completed;

                _context.SaveChanges();
                trans.Commit();
                return true;
            }
            catch
            {
                trans.Rollback();
                throw;
            }
        }

        // Hủy hóa đơn
        public bool CancelInvoice(int invoiceId, int receptionistId, string cancellationReason)
        {
            using var trans = _context.Database.BeginTransaction();

            try
            {
                var invoice = _context.Invoices.FirstOrDefault(i => i.InvoiceId == invoiceId);
                if (invoice == null) throw new InvalidOperationException("Không tìm thấy hóa đơn.");

                if (invoice.Status != InvoiceStatus.Paid && invoice.Status != InvoiceStatus.Unpaid)
                {
                    throw new InvalidOperationException("Chỉ có thể hủy hóa đơn chưa thanh toán hoặc đã thanh toán.");
                }

                var visit = _context.Visits.FirstOrDefault(v => v.VisitId == invoice.VisitId);
                if (visit == null) throw new InvalidOperationException("Không tìm thấy lượt khám.");

                InvoiceStatus oldStatus = invoice.Status;

                invoice.Status = InvoiceStatus.Cancelled;
                invoice.CancellationReason = cancellationReason;
                invoice.CancelledBy = receptionistId;
                invoice.CancelledDate = DateTime.Now;

                visit.Status = VisitStatus.Cancelled;

                if (oldStatus == InvoiceStatus.Paid)
                {
                    var invoiceDetails = _context.InvoiceDetails
                        .Where(d => d.InvoiceId == invoiceId && d.PrescriptionDetailId.HasValue)
                        .ToList();

                    foreach (var detail in invoiceDetails)
                    {
                        if (!detail.PrescriptionDetailId.HasValue) continue;

                        var prescriptionDetail = _context.PrescriptionDetails
                            .FirstOrDefault(p => p.PrescriptionDetailId == detail.PrescriptionDetailId.Value);

                        if (prescriptionDetail == null) continue;

                        var medicine = _context.Medicines
                            .FirstOrDefault(m => m.MedicineId == prescriptionDetail.MedicineId);

                        if (medicine != null)
                            medicine.QuantityInStock += detail.Quantity;
                    }
                }

                _context.SaveChanges();
                trans.Commit();

                return true;
            }
            catch
            {
                trans.Rollback();
                throw;
            }
        }

        // Lấy danh sách phương thức thanh toán
        public List<PaymentMethod> GetPaymentMethods()
        {
            return _context.PaymentMethods.ToList();
        }

        // Lấy tất cả hóa đơn theo bộ lọc
        public List<InvoiceDisplayDto> GetAllInvoices(DateTime fromDate, DateTime toDate, string keyword = "", InvoiceStatus? status = null)
        {
            var query = _context.Invoices.AsQueryable();

            query = query.Where(i => i.InvoiceDateTime >= fromDate.Date && i.InvoiceDateTime < toDate.Date.AddDays(1));

            if (status.HasValue)
            {
                query = query.Where(i => i.Status == status.Value);
            }

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string kw = keyword.Trim().ToLower();
                query = query.Where(i =>
                    i.InvoiceId.ToString().Contains(kw) ||
                    i.Visit.Patient.FullName.ToLower().Contains(kw) ||
                    i.Visit.Patient.Phone.Contains(kw));
            }

            return query
                .Select(i => new InvoiceDisplayDto
                {
                    InvoiceId = i.InvoiceId,
                    InvoiceDateTime = i.InvoiceDateTime,
                    PatientName = i.Visit.Patient.FullName,
                    ReceptionistName = i.Receptionist.FullName,
                    PaymentMethodName = i.PaymentMethod.PaymentMethodName,
                    TotalAmount = i.TotalAmount,
                    AmountGiven = i.AmountGiven,
                    ChangeAmount = i.ChangeAmount,
                    Status = i.Status == InvoiceStatus.Paid ? "Đã thanh toán" : i.Status == InvoiceStatus.Cancelled ? "Đã hủy" : "Chưa thanh toán"
                })
                .OrderByDescending(i => i.InvoiceDateTime)
                .ToList();
        }

        // Lấy chi tiết hóa đơn theo ID để xem/in
        public InvoiceDetailDto? GetInvoiceDetail(int invoiceId)
        {
            var invoice = _context.Invoices
                .Include(i => i.Visit).ThenInclude(v => v.Patient)
                .Include(i => i.Visit).ThenInclude(v => v.Doctor)
                .Include(i => i.Visit).ThenInclude(v => v.MedicalRecord)
                .Include(i => i.PaymentMethod)
                .Include(i => i.Receptionist)
                .Include(i => i.CancelledByReceptionist)
                .AsNoTracking()
                .FirstOrDefault(i => i.InvoiceId == invoiceId);

            if (invoice == null) return null;

            return new InvoiceDetailDto
            {
                InvoiceId = invoice.InvoiceId,
                InvoiceDateTime = invoice.InvoiceDateTime,
                Status = invoice.Status == InvoiceStatus.Unpaid ? "Chưa thanh toán" : invoice.Status == InvoiceStatus.Paid ? "Đã thanh toán" : "Đã hủy",
                TotalAmount = invoice.TotalAmount,
                AmountGiven = invoice.AmountGiven,
                ChangeAmount = invoice.ChangeAmount,
                PaymentMethodName = invoice.PaymentMethod?.PaymentMethodName ?? "Chưa thanh toán",
                ReceptionistName = invoice.Receptionist?.FullName ?? "",
               
                CancellationReason = invoice.CancellationReason,
                CancelledDate = invoice.CancelledDate,
                CancelledByName = invoice.CancelledByReceptionist?.FullName,
                
                PatientId = invoice.Visit.PatientId,
                PatientName = invoice.Visit.Patient.FullName,
                PatientPhone = invoice.Visit.Patient.Phone,
                PatientDateOfBirth = invoice.Visit.Patient.DateOfBirth,
                PatientAddress = invoice.Visit.Patient.Address,
                
                VisitId = invoice.VisitId,
                CheckInDateTime = invoice.Visit.CheckInDateTime,
                ReasonForVisit = invoice.Visit.ReasonForVisit,
                DoctorName = invoice.Visit.Doctor?.FullName ?? "",
                MedicalRecordId = invoice.Visit.MedicalRecord?.MedicalRecordId,
                ExaminationDateTime = invoice.Visit.MedicalRecord?.ExaminationDateTime,
                Diagnosis = invoice.Visit.MedicalRecord?.Diagnosis,
                Conclusion = invoice.Visit.MedicalRecord?.Conclusion
            };
        }

        // Lấy danh sách item chi tiết trong hóa đơn
        public List<InvoiceDetailItemDto> GetInvoiceDetailItems(int invoiceId)
        {
            return _context.InvoiceDetails
                .Where(d => d.InvoiceId == invoiceId)
                .Select(d => new InvoiceDetailItemDto
                {
                    InvoiceDetailId = d.InvoiceDetailId,
                    ItemType = d.MedicalRecordServiceId.HasValue ? "Dịch vụ" : "Thuốc",
                    ItemName = d.ItemName,
                    Quantity = d.Quantity,
                    UnitPrice = d.UnitPrice,
                    TotalAmount = d.TotalAmount,
                    Morning = d.PrescriptionDetailId.HasValue ? d.PrescriptionDetail.Morning : 0,
                    Noon = d.PrescriptionDetailId.HasValue ? d.PrescriptionDetail.Noon : 0,
                    Afternoon = d.PrescriptionDetailId.HasValue ? d.PrescriptionDetail.Afternoon : 0,
                    Evening = d.PrescriptionDetailId.HasValue ? d.PrescriptionDetail.Evening : 0,
                    Days = d.PrescriptionDetailId.HasValue ? d.PrescriptionDetail.Days : 0,
                    Instruction = d.PrescriptionDetailId.HasValue ? d.PrescriptionDetail.Instruction : "",
                    Note = d.MedicalRecordServiceId.HasValue ? d.MedicalRecordService.Note : null
                })
                .ToList();
        }
    }
}