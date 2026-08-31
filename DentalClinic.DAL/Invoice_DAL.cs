using DentalClinic.DTO;
using DentalClinic.MODEL;
using Microsoft.EntityFrameworkCore;
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
            var query = _context.Invoices
                .Include(i => i.Visit)
                    .ThenInclude(v => v.Patient)
                .Include(i => i.Visit)
                    .ThenInclude(v => v.Doctor)
                .Where(i => i.Status == InvoiceStatus.Unpaid);

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string kw = keyword.Trim();

                query = query.Where(i =>
                    i.Visit.Patient.FullName.Contains(kw) ||
                    i.Visit.Patient.Phone.Contains(kw));
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

        public List<InvoiceDetailDisplayDto> GetInvoiceDetailsByInvoiceId(int invoiceId)
        {
            return _context.InvoiceDetails
                .Where(d => d.InvoiceId == invoiceId)
                .Select(d => new InvoiceDetailDisplayDto
                {
                    ItemType = d.MedicalRecordServiceId.HasValue
                        ? "Dịch vụ"
                        : "Thuốc",

                    ItemName = d.ItemName,
                    Quantity = d.Quantity,
                    UnitPrice = d.UnitPrice,
                    TotalAmount = d.TotalAmount,

                    MedicalRecordServiceId = d.MedicalRecordServiceId,
                    PrescriptionDetailId = d.PrescriptionDetailId
                })
                .ToList();
        }

        public Invoice? GetUnpaidInvoiceByVisitId(int visitId)
        {
            return _context.Invoices
                .FirstOrDefault(i =>
                    i.VisitId == visitId &&
                    i.Status == InvoiceStatus.Unpaid);
        }

        public bool CreateUnpaidInvoice(int visitId)
        {
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    // 1. Lấy Visit kèm MedicalRecord
                    var visit = _context.Visits
                        .Include(v => v.MedicalRecord)
                            .ThenInclude(m => m.MedicalRecordServices)
                        .Include(v => v.MedicalRecord)
                            .ThenInclude(m => m.Prescription)
                                .ThenInclude(p => p.PrescriptionDetails)
                        .FirstOrDefault(v => v.VisitId == visitId);

                    if (visit == null)
                        throw new InvalidOperationException("Không tìm thấy ca khám.");

                    if (visit.MedicalRecord == null)
                        throw new InvalidOperationException("Ca khám chưa có hồ sơ bệnh án.");

                    // 2. Kiểm tra đã có Invoice Unpaid chưa
                    bool hasUnpaidInvoice = _context.Invoices
                        .Any(i => i.VisitId == visitId &&
                                  i.Status == InvoiceStatus.Unpaid);

                    if (hasUnpaidInvoice)
                        throw new InvalidOperationException(
                            "Ca khám này đã có hóa đơn chưa thanh toán.");

                    // 3. Kiểm tra đã có Invoice Paid chưa
                    bool hasPaidInvoice = _context.Invoices
                        .Any(i => i.VisitId == visitId &&
                                  i.Status == InvoiceStatus.Paid);

                    if (hasPaidInvoice)
                        throw new InvalidOperationException(
                            "Ca khám này đã có hóa đơn đã thanh toán.");

                    var record = visit.MedicalRecord;

                    // 4. Lấy dịch vụ
                    var services = _context.MedicalRecordServices
                        .Include(s => s.Service)
                        .Where(s => s.MedicalRecordId == record.MedicalRecordId)
                        .ToList();

                    // 5. Lấy thuốc
                    var medicines = new List<PrescriptionDetail>();

                    if (record.Prescription != null)
                    {
                        medicines = _context.PrescriptionDetails
                            .Include(p => p.Medicine)
                            .Where(p => p.PrescriptionId == record.Prescription.PrescriptionId)
                            .ToList();
                    }

                    // 6. Không có gì để thanh toán
                    if (!services.Any() && !medicines.Any())
                        throw new InvalidOperationException(
                            "Hồ sơ bệnh án chưa có dịch vụ hoặc thuốc.");

                    // 7. Tạo Invoice Unpaid
                    var invoice = new Invoice
                    {
                        VisitId = visitId,

                        // Invoice được tạo tự động khi hoàn thành khám.
                        // Tạm dùng Receptionist của Visit.
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

                    // 8. Tạo InvoiceDetail - Dịch vụ
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

                    // 9. Tạo InvoiceDetail - Thuốc
                    foreach (var medicine in medicines)
                    {
                        decimal medicineTotal =
                            medicine.Quantity * medicine.Medicine.UnitPrice;

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

                    // 10. Cập nhật tổng tiền
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

        public bool CheckoutInvoice(
    int invoiceId,
    int paymentMethodId,
    int receptionistId,
    decimal amountGiven,
    decimal changeAmount)
        {
            using var trans = _context.Database.BeginTransaction();

            try
            {
                // 1. Lấy Invoice
                var invoice = _context.Invoices
                    .FirstOrDefault(i => i.InvoiceId == invoiceId);

                if (invoice == null)
                    throw new InvalidOperationException(
                        "Không tìm thấy hóa đơn.");

                // 2. Chỉ cho thanh toán Invoice Unpaid
                if (invoice.Status != InvoiceStatus.Unpaid)
                    throw new InvalidOperationException(
                        "Hóa đơn này không ở trạng thái chưa thanh toán.");

                // 3. Kiểm tra phương thức thanh toán
                var paymentMethod = _context.PaymentMethods
                    .FirstOrDefault(p =>
                        p.PaymentMethodId == paymentMethodId);

                if (paymentMethod == null)
                    throw new InvalidOperationException(
                        "Không tìm thấy phương thức thanh toán.");

                // 4. Kiểm tra nhân viên
                var receptionist = _context.Receptionists
                    .FirstOrDefault(r =>
                        r.ReceptionistId == receptionistId);

                if (receptionist == null)
                    throw new InvalidOperationException(
                        "Không tìm thấy nhân viên thanh toán.");

                // 5. Kiểm tra tiền khách đưa
                if (amountGiven < invoice.TotalAmount)
                    throw new InvalidOperationException(
                        "Số tiền khách đưa chưa đủ.");

                // 6. Cập nhật Invoice
                invoice.PaymentMethodId = paymentMethodId;
                invoice.ReceptionistId = receptionistId;
                invoice.AmountGiven = amountGiven;
                invoice.ChangeAmount = changeAmount;
                invoice.Status = InvoiceStatus.Paid;

                // 7. Lấy Visit
                var visit = _context.Visits
                    .FirstOrDefault(v => v.VisitId == invoice.VisitId);

                if (visit == null)
                    throw new InvalidOperationException(
                        "Không tìm thấy ca khám.");

                // 8. Trừ tồn kho thuốc
                var prescriptionDetails = _context.InvoiceDetails
                    .Where(d =>
                        d.InvoiceId == invoiceId &&
                        d.PrescriptionDetailId.HasValue)
                    .ToList();

                foreach (var detail in prescriptionDetails)
                {
                    if (!detail.PrescriptionDetailId.HasValue)
                        continue;

                    var prescriptionDetail =
                        _context.PrescriptionDetails
                            .FirstOrDefault(p =>
                                p.PrescriptionDetailId ==
                                detail.PrescriptionDetailId.Value);

                    if (prescriptionDetail == null)
                        continue;

                    var medicine = _context.Medicines
                        .FirstOrDefault(m =>
                            m.MedicineId ==
                            prescriptionDetail.MedicineId);

                    if (medicine == null)
                        throw new InvalidOperationException(
                            $"Không tìm thấy thuốc có mã {prescriptionDetail.MedicineId}.");

                    if (medicine.QuantityInStock < detail.Quantity)
                        throw new InvalidOperationException(
                            $"Thuốc '{medicine.MedicineName}' không đủ tồn kho.");

                    medicine.QuantityInStock -= detail.Quantity;
                }

                // 9. Hoàn tất Visit
                visit.Status = VisitStatus.Completed;

                // 10. Lưu
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

        public bool CancelInvoice(
    int invoiceId,
    int cancelledBy,
    string cancellationReason)
        {
            using var trans = _context.Database.BeginTransaction();

            try
            {
                // 1. Lấy hóa đơn
                var invoice = _context.Invoices
                    .FirstOrDefault(i => i.InvoiceId == invoiceId);

                if (invoice == null)
                {
                    throw new InvalidOperationException(
                        "Không tìm thấy hóa đơn.");
                }

                // 2. Chỉ cho hủy hóa đơn đã thanh toán
                if (invoice.Status != InvoiceStatus.Paid)
                {
                    throw new InvalidOperationException(
                        "Chỉ có thể hủy hóa đơn đã thanh toán.");
                }

                // 3. Kiểm tra người hủy
                var receptionist = _context.Receptionists
                    .FirstOrDefault(r =>
                        r.ReceptionistId == cancelledBy);

                if (receptionist == null)
                {
                    throw new InvalidOperationException(
                        "Không tìm thấy nhân viên thực hiện hủy.");
                }

                // 4. Cập nhật thông tin hủy
                invoice.Status = InvoiceStatus.Cancelled;
                invoice.CancellationReason = cancellationReason;
                invoice.CancelledDate = DateTime.Now;
                invoice.CancelledBy = cancelledBy;

                // 5. KHÔNG thay đổi Visit.Status
                // Visit vẫn giữ Completed

                // 6. Hoàn lại thuốc vào kho
                var invoiceDetails = _context.InvoiceDetails
                    .Where(d =>
                        d.InvoiceId == invoiceId &&
                        d.PrescriptionDetailId.HasValue)
                    .ToList();

                foreach (var detail in invoiceDetails)
                {
                    if (!detail.PrescriptionDetailId.HasValue)
                        continue;

                    var prescriptionDetail =
                        _context.PrescriptionDetails
                            .FirstOrDefault(p =>
                                p.PrescriptionDetailId ==
                                detail.PrescriptionDetailId.Value);

                    if (prescriptionDetail == null)
                        continue;

                    var medicine = _context.Medicines
                        .FirstOrDefault(m =>
                            m.MedicineId ==
                            prescriptionDetail.MedicineId);

                    if (medicine != null)
                    {
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

        public List<PaymentMethod> GetPaymentMethods()
        {
            return _context.PaymentMethods.ToList();
        }

        public List<InvoiceDisplayDto> GetAllInvoices(
    DateTime fromDate,
    DateTime toDate,
    InvoiceStatus? status)
        {
            var query = _context.Invoices.AsQueryable();

            // Lọc theo khoảng thời gian
            query = query.Where(i =>
                i.InvoiceDateTime >= fromDate.Date &&
                i.InvoiceDateTime <= toDate.Date.AddDays(1).AddTicks(-1));

            // Lọc theo trạng thái
            if (status.HasValue)
            {
                query = query.Where(i => i.Status == status.Value);
            }

            return query
                .Select(i => new InvoiceDisplayDto
                {
                    InvoiceId = i.InvoiceId,
                    InvoiceDateTime = i.InvoiceDateTime,

                    PatientName = i.Visit.Patient.FullName,

                    ReceptionistName = i.Receptionist.FullName,

                    PaymentMethodName = i.PaymentMethod != null
                        ? i.PaymentMethod.PaymentMethodName
                        : "Chưa thanh toán",

                    TotalAmount = i.TotalAmount,
                    AmountGiven = i.AmountGiven,
                    ChangeAmount = i.ChangeAmount,

                    Status = i.Status == InvoiceStatus.Unpaid
                        ? "Chưa thanh toán"
                        : i.Status == InvoiceStatus.Paid
                            ? "Đã thanh toán"
                            : i.Status == InvoiceStatus.Cancelled
                                ? "Đã hủy"
                                : "Khác"
                })
                .OrderByDescending(i => i.InvoiceDateTime)
                .ToList();
        }

        public InvoiceDetailDto? GetInvoiceDetail(int invoiceId)
        {
            var invoice = _context.Invoices
                .Include(i => i.Visit)
                    .ThenInclude(v => v.Patient)
                .Include(i => i.Visit)
                    .ThenInclude(v => v.Doctor)
                .Include(i => i.Visit)
                    .ThenInclude(v => v.MedicalRecord)
                .Include(i => i.PaymentMethod)
                .Include(i => i.Receptionist)
                .Include(i => i.CancelledByReceptionist)
                .AsNoTracking()
                .FirstOrDefault(i => i.InvoiceId == invoiceId);

            if (invoice == null)
                return null;

            return new InvoiceDetailDto
            {
                // Invoice
                InvoiceId = invoice.InvoiceId,
                InvoiceDateTime = invoice.InvoiceDateTime,

                Status = invoice.Status == InvoiceStatus.Unpaid
                    ? "Chưa thanh toán"
                    : invoice.Status == InvoiceStatus.Paid
                        ? "Đã thanh toán"
                        : "Đã hủy",

                TotalAmount = invoice.TotalAmount,
                AmountGiven = invoice.AmountGiven,
                ChangeAmount = invoice.ChangeAmount,

                PaymentMethodName =
                    invoice.PaymentMethod?.PaymentMethodName
                    ?? "Chưa thanh toán",

                ReceptionistName =
                    invoice.Receptionist?.FullName
                    ?? "",

                // Cancellation
                CancellationReason = invoice.CancellationReason,
                CancelledDate = invoice.CancelledDate,

                CancelledByName =
                    invoice.CancelledByReceptionist?.FullName,

                // Patient
                PatientId = invoice.Visit.PatientId,
                PatientName = invoice.Visit.Patient.FullName,
                PatientPhone = invoice.Visit.Patient.Phone,
                PatientDateOfBirth = invoice.Visit.Patient.DateOfBirth,
                PatientAddress = invoice.Visit.Patient.Address,

                // Visit
                VisitId = invoice.VisitId,
                CheckInDateTime = invoice.Visit.CheckInDateTime,
                ReasonForVisit = invoice.Visit.ReasonForVisit,

                // Doctor
                DoctorName =
                    invoice.Visit.Doctor?.FullName
                    ?? "",

                // MedicalRecord
                MedicalRecordId =
                    invoice.Visit.MedicalRecord?.MedicalRecordId,

                ExaminationDateTime =
                    invoice.Visit.MedicalRecord?.ExaminationDateTime,

                Diagnosis =
                    invoice.Visit.MedicalRecord?.Diagnosis,

                Conclusion =
                    invoice.Visit.MedicalRecord?.Conclusion
            };
        }

        public List<InvoiceDetailItemDto> GetInvoiceDetailItems(int invoiceId)
        {
            return _context.InvoiceDetails
                .Where(d => d.InvoiceId == invoiceId)
                .Select(d => new InvoiceDetailItemDto
                {
                    InvoiceDetailId = d.InvoiceDetailId,

                    ItemType = d.MedicalRecordServiceId.HasValue
                        ? "Dịch vụ"
                        : "Thuốc",

                    ItemName = d.ItemName,
                    Quantity = d.Quantity,
                    UnitPrice = d.UnitPrice,
                    TotalAmount = d.TotalAmount,

                    Morning = d.PrescriptionDetailId.HasValue
                        ? d.PrescriptionDetail.Morning
                        : 0,

                    Noon = d.PrescriptionDetailId.HasValue
                        ? d.PrescriptionDetail.Noon
                        : 0,

                    Afternoon = d.PrescriptionDetailId.HasValue
                        ? d.PrescriptionDetail.Afternoon
                        : 0,

                    Evening = d.PrescriptionDetailId.HasValue
                        ? d.PrescriptionDetail.Evening
                        : 0,

                    Days = d.PrescriptionDetailId.HasValue
                        ? d.PrescriptionDetail.Days
                        : 0,

                    Instruction = d.PrescriptionDetailId.HasValue
                        ? d.PrescriptionDetail.Instruction
                        : "",

                    Note = d.MedicalRecordServiceId.HasValue
                        ? d.MedicalRecordService.Note
                        : null
                })
                .ToList();
        }

    }
}
