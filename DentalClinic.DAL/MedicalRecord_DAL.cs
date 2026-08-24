using DentalClinic.DTO;
using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.DAL
{
    public class MedicalRecord_DAL
    {
        private readonly AppDbContext _context = new AppDbContext();

        public bool SaveRecordTransaction(SaveMedicalRecordDto dto)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // 1. Tìm hoặc tạo mới MedicalRecord
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

                    // Cập nhật dữ liệu 
                    record.Diagnosis = dto.Diagnosis;
                    record.Conclusion = dto.Conclusion;

                    _context.SaveChanges();

                    // 2. Cập nhật dịch vụ (MedicalRecordService)
                    // Xóa dịch vụ cũ để ghi đè dịch vụ mới 
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
                            Status = MedicalRecordServiceStatus.Pending,
                            Note = ""
                        }).ToList();

                        _context.MedicalRecordServices.AddRange(newServices);
                    }

                    // 3.Tìm hoặc tạo đơn thuốc (Prescription)
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

                    // 4. Cập nhật chi tiết đơn thuốc (PrescriptionDetail)
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

                    // 5. Cập nhật trạng thái Visit sang Hoàn thành (Nếu chọn Hoàn thành khám)
                    if (!dto.IsDraft)
                    {
                        var visit = _context.Visits.Find(dto.VisitId);
                        if (visit != null)
                        {
                            visit.Status = VisitStatus.Completed;
                            _context.Visits.Update(visit);
                        }
                    }

                    // 6. Lưu vào dtb, kết thúc transaction
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


        public SaveMedicalRecordDto GetDraftRecordByVisitId(int visitId)
        {
            // 1. Tìm hồ sơ khám
            var record = _context.MedicalRecords.FirstOrDefault(m => m.VisitId == visitId);
            if (record == null) return null;

            // 2. Tạo DTO trả về
            var dto = new SaveMedicalRecordDto
            {
                MedicalRecordId = record.MedicalRecordId,
                VisitId = visitId,
                Diagnosis = record.Diagnosis,
                Conclusion = record.Conclusion,
                IsDraft = true
            };

            // 3. Lấy danh sách dịch vụ
            dto.Services = _context.MedicalRecordServices
                .Where(s => s.MedicalRecordId == record.MedicalRecordId)
                .Select(s => new SelectedServiceDto
                {
                    ServiceId = s.ServiceId,
                    ServiceName = s.Service.ServiceName, 
                    Quantity = s.Quantity,
                    UnitPrice = s.UnitPrice
                }).ToList();

            // 4. Lấy danh sách thuốc
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
    }
}
