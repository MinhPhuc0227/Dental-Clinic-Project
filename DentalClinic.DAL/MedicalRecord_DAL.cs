using DentalClinic.DTO;
using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.DAL
{
    public class MedicalRecord_DAL
    {

        private readonly AppDbContext _context;

        public MedicalRecord_DAL(AppDbContext context)
        {
            _context = context;
        }

        public bool SaveRecordTransaction(SaveMedicalRecordDto dto)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var record = _context.MedicalRecords.FirstOrDefault(m => m.VisitId == dto.VisitId);

                    if (record == null)
                    {
                        record = new MedicalRecord
                        {
                            VisitId = dto.VisitId,
                            ExaminationDateTime = DateTime.Now
                        };
                        _context.MedicalRecords.Add(record);

                        dto.MedicalRecordId = record.MedicalRecordId;
                    }

                    record.Diagnosis = dto.Diagnosis;
                    record.Conclusion = dto.Conclusion;
                    record.Note = dto.Note;

                    _context.SaveChanges();

                    // Cập nhật dịch vụ 
                    var oldServices = _context.MedicalRecordServices.Where(s => s.MedicalRecordId == record.MedicalRecordId).ToList();
                    _context.MedicalRecordServices.RemoveRange(oldServices);

                    // Thêm danh sách dịch vụ mới
                    if (dto.Services != null && dto.Services.Any())
                    {
                        var newServices = dto.Services.Select(s => new MedicalRecordService
                        {
                            MedicalRecordId = record.MedicalRecordId,
                            ServiceId = s.ServiceId,
                            Quantity = s.Quantity,
                            UnitPrice = s.UnitPrice,
                            TotalAmount = s.TotalPrice,
                            Note = ""
                        }).ToList();

                        _context.MedicalRecordServices.AddRange(newServices);
                    }

                    // Tìm hoặc tạo đơn thuốc (Prescription)
                    var prescription = _context.Prescriptions.FirstOrDefault(p => p.MedicalRecordId == record.MedicalRecordId);
                    if (prescription == null)
                    {
                        prescription = new Prescription
                        {
                            MedicalRecordId = record.MedicalRecordId,
                        };
                        _context.Prescriptions.Add(prescription);
                        _context.SaveChanges(); 
                    }

                    // Xóa thuốc cũ
                    var oldDetails = _context.PrescriptionDetails.Where(d => d.PrescriptionId == prescription.PrescriptionId).ToList();
                    _context.PrescriptionDetails.RemoveRange(oldDetails);

                    // Thêm danh sách thuốc mới 
                    if (dto.Medicines != null && dto.Medicines.Any())
                    {
                        var newDetails = dto.Medicines.Select(m => new PrescriptionDetail
                        {
                            PrescriptionId = prescription.PrescriptionId,
                            MedicineId = m.MedicineId,
                            Morning = m.Morning,
                            Noon = m.Noon,
                            Afternoon = m.Afternoon,
                            Evening = m.Evening,
                            Days = m.Days,
                            Quantity = m.Quantity,
                            Instruction = m.Instruction
                        }).ToList();

                        _context.PrescriptionDetails.AddRange(newDetails);
                    }

                    _context.SaveChanges();

                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback(); 
                    throw; 
                }
            }
        }


        public SaveMedicalRecordDto? GetDraftRecordByVisitId(int visitId)
        {
            // Tìm hồ sơ khám
            var record = _context.MedicalRecords.FirstOrDefault(m => m.VisitId == visitId);
            if (record == null) return null;

            var dto = new SaveMedicalRecordDto
            {
                MedicalRecordId = record.MedicalRecordId,
                VisitId = visitId,
                Diagnosis = record.Diagnosis,
                Conclusion = record.Conclusion,
                Note = record.Note,
                IsDraft = true
            };

            // Lấy danh sách dịch vụ
            dto.Services = _context.MedicalRecordServices
                .Where(s => s.MedicalRecordId == record.MedicalRecordId)
                .Select(s => new SelectedServiceDto
                {
                    ServiceId = s.ServiceId,
                    ServiceName = s.Service.ServiceName, 
                    Quantity = s.Quantity,
                    UnitPrice = s.UnitPrice
                }).ToList();

            // Lấy danh sách thuốc
            var prescription = _context.Prescriptions.FirstOrDefault(p => p.MedicalRecordId == record.MedicalRecordId);
            if (prescription != null)
            {
                dto.Medicines = _context.PrescriptionDetails
                    .Where(pd => pd.PrescriptionId == prescription.PrescriptionId)
                    .Select(pd => new SelectedMedicineDto
                    {
                        MedicineId = pd.MedicineId,
                        MedicineName = pd.Medicine.MedicineName,
                        Morning = pd.Morning,
                        Noon = pd.Noon,
                        Afternoon = pd.Afternoon,
                        Evening = pd.Evening,
                        Days = pd.Days,
                        Instruction = pd.Instruction,
                        UnitPrice = pd.Medicine.UnitPrice
                    }).ToList();
            }

            return dto;
        }

        public List<PatientHistoryDto> GetPatientHistoryByVisit(int currentVisitId)
        {
            var currentVisit = _context.Visits.Find(currentVisitId);

            if (currentVisit == null)
                return new List<PatientHistoryDto>();

            return _context.MedicalRecords
                .Where(m =>
                    m.Visit.PatientId == currentVisit.PatientId &&
                    m.Visit.Status == VisitStatus.Completed)
                .OrderByDescending(m => m.ExaminationDateTime)
                .Select(m => new PatientHistoryDto
                {
                    MedicalRecordId = m.MedicalRecordId,
                    VisitId = m.VisitId,
                    ExaminationDate = m.ExaminationDateTime,
                    DoctorName = m.Visit.Doctor.FullName,
                    VisitStatus = m.Visit.Status,
                    Diagnosis = m.Diagnosis,
                    Conclusion = m.Conclusion,
                    Note = m.Note
                })
                .ToList();
        }

        // Lấy danh sách các ca đã khám của Bác sĩ 
        public List<ExaminedRecordDto> GetExaminedRecords(
            int doctorId,
            DateTime fromDate,
            DateTime toDate,
            string keyword,
            VisitStatus? status)
        {
            var query = _context.MedicalRecords
                .Where(m =>
                    m.Visit.DoctorId == doctorId &&
                    m.ExaminationDateTime.Date >= fromDate.Date &&
                    m.ExaminationDateTime.Date <= toDate.Date);

            if (status.HasValue)
                query = query.Where(m => m.Visit.Status == status.Value);

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string kw = keyword.Trim().ToLower();
                query = query.Where(m =>
                    m.Visit.Patient.FullName.ToLower().Contains(kw));
            }

            return query
                .Select(m => new ExaminedRecordDto
                {
                    MedicalRecordId = m.MedicalRecordId,
                    ExaminationTime = m.ExaminationDateTime,
                    PatientName = m.Visit.Patient.FullName,
                    VisitStatus = m.Visit.Status,
                    Diagnosis = m.Diagnosis,
                    Conclusion = m.Conclusion
                })
                .OrderByDescending(m => m.ExaminationTime)
                .ToList();
        }

        // Lấy chi tiết 1 ca khám để hiển thị (pnRight trong UC_Doctor_MedicalRecord)
        public (
            string Diagnosis,
            string Conclusion,
            string? Note,
            List<ExaminedServiceDto> Services,
            List<ExaminedMedicineDto> Medicines
                ) GetRecordDetails(int medicalRecordId)
        {
            var record = _context.MedicalRecords.FirstOrDefault(m => m.MedicalRecordId == medicalRecordId);

            if (record == null)
                return (
                    string.Empty,
                    string.Empty,
                    null,
                    new List<ExaminedServiceDto>(),
                    new List<ExaminedMedicineDto>());

            var services = _context.MedicalRecordServices
                .Where(s => s.MedicalRecordId == record.MedicalRecordId)
                .Select(s => new ExaminedServiceDto
                {
                    ServiceName = s.Service.ServiceName,
                    Quantity = s.Quantity
                })
                .ToList();

            var medicines = new List<ExaminedMedicineDto>();

            var prescription = _context.Prescriptions
                .FirstOrDefault(p => p.MedicalRecordId == record.MedicalRecordId);

            if (prescription != null)
            {
                medicines = _context.PrescriptionDetails
                    .Where(pd => pd.PrescriptionId == prescription.PrescriptionId)
                    .Select(pd => new ExaminedMedicineDto
                    {
                        MedicineName = pd.Medicine.MedicineName,
                        Morning = pd.Morning,
                        Noon = pd.Noon,
                        Afternoon = pd.Afternoon,
                        Evening = pd.Evening,
                        Days = pd.Days,
                        Quantity = pd.Quantity,
                        Instruction = pd.Instruction
                    })
                    .ToList();
            }

            return (
                record.Diagnosis,
                record.Conclusion,
                record.Note,
                services,
                medicines
            );
        }
    }
}
