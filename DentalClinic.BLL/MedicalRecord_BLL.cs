using DentalClinic.DAL;
using DentalClinic.DTO;
using DentalClinic.DTO.Common;
using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DentalClinic.BLL
{
    public class MedicalRecord_BLL
    {
        private readonly MedicalRecord_DAL _dal;

        public MedicalRecord_BLL(MedicalRecord_DAL dal)
        {
            _dal = dal;
        }

        public Result SaveRecord(SaveMedicalRecordDto dto)
        {
            if (dto.VisitId <= 0)
            {
                return Result.Failure("Dữ liệu lượt khám không hợp lệ!");
            }

            // Kiểm tra hoàn thành khám thì bắt buộc phải có chẩn đoán
            if (!dto.IsDraft && string.IsNullOrWhiteSpace(dto.Diagnosis))
            {
                return Result.Failure("Chẩn đoán không được để trống khi hoàn thành khám.");
            }

            try
            {
                bool isSuccess = _dal.SaveRecordTransaction(dto);

                if (isSuccess)
                {
                    string message = dto.IsDraft ? "Lưu nháp hồ sơ thành công!" : "Hoàn thành khám bệnh thành công!";
                    return Result.Success(message);
                }
                else
                {
                    return Result.Failure("Không thể lưu hồ sơ vào cơ sở dữ liệu.");
                }
            }
            catch (Exception ex)
            {
                return Result.Failure("Lỗi hệ thống: " + ex.Message);
            }
        }

        public SaveMedicalRecordDto GetDraftRecord(int visitId)
        {
            try
            {
                return _dal.GetDraftRecordByVisitId(visitId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Message: {ex.Message}");
                Debug.WriteLine($"Inner: {ex.InnerException?.Message}");
                Debug.WriteLine($"StackTrace: {ex.StackTrace}");
                return null;
            }
        }

        public List<MedicalHistoryDto> GetPatientHistory(int visitId)
        {
            try
            {
                return _dal.GetPatientHistoryByVisit(visitId);
            }
            catch { return new List<MedicalHistoryDto>(); }
        }

        // Lấy danh sách các ca đã khám của Bác sĩ (pnLeft trong UC_Doctor_MedicalRecord)
        public List<ExaminedRecordDto> GetExaminedRecords(int doctorId, DateTime fromDate, DateTime toDate, string keyword, VisitStatus? status)
        {
            try
            {
                return _dal.GetExaminedRecords(
                    doctorId,
                    fromDate,
                    toDate,
                    keyword,
                    status);
            }
            catch (Exception)
            {
                return new List<ExaminedRecordDto>();
            }
        }

        // Lấy chi tiết 1 ca khám để hiển thị (pnRight trong UC_Doctor_MedicalRecord)
        public (string Diagnosis, string Conclusion, string? Note, List<ExaminedServiceDto> Services, List<ExaminedMedicineDto> Medicines) GetRecordDetails(int visitId)
        {
            try
            {
                return _dal.GetRecordDetails(visitId);
            }
            catch (Exception)
            {
                return (string.Empty, string.Empty, null, new List<ExaminedServiceDto>(), new List<ExaminedMedicineDto>());
            }
        }

        // Khách hàng online có thể xem được lịch sử khám bệnh của mình
        public List<MedicalHistoryDto> GetPatientHistoryByPatientId(int patientId)
        {
            if (patientId <= 0)
            {
                return new List<MedicalHistoryDto>();
            }

            try
            {
                return _dal.GetPatientHistoryByPatientId(patientId);
            }
            catch
            {
                return new List<MedicalHistoryDto>();
            }
        }
    }
}
