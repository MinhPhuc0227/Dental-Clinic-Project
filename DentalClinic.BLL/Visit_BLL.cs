using DentalClinic.BLL.Common;
using DentalClinic.DAL;
using DentalClinic.DTO;
using DentalClinic.DTO.Common;
using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.BLL
{
    public class Visit_BLL
    {
        private readonly Visit_DAL _visitDAL;

        public Visit_BLL(Visit_DAL visitDAL)
        {
            _visitDAL = visitDAL;
        }

        public Result<List<WaitingQueueDto>> GetWaitingQueue(DateTime startDate, DateTime endDate, string keyword, int? doctorId, VisitStatus? status)
        {
            try
            {
                var data = _visitDAL.GetWaitingQueue(startDate, endDate, keyword, doctorId, status);
                return Result<List<WaitingQueueDto>>.Success(data);
            }
            catch (Exception ex)
            {
                return Result<List<WaitingQueueDto>>.Failure("Lỗi khi tải danh sách hàng chờ: " + ex.Message);
            }
        }

        public Result<List<VisitListDto>> GetAllVisits(
            DateTime startDate,
            DateTime endDate,
            string keyword = "",
            int? doctorId = null,
            VisitStatus? status = null)
        {
            try
            {
                var data = _visitDAL.GetAllVisits(startDate, endDate, keyword, doctorId, status);
                return Result<List<VisitListDto>>.Success(data);
            }
            catch (Exception ex)
            {
                return Result<List<VisitListDto>>.Failure("Lỗi khi tải danh sách lượt khám: " + ex.Message);
            }
        }

        public Result CreateWalkInVisit(VisitCreateDto dto)
        {
            string? validationError = dto.Validate();

            if (!string.IsNullOrEmpty(validationError))
            {
                return Result.Failure(validationError);
            }

            if (_visitDAL.HasActiveVisitToday(dto.PatientId))
            {
                return Result.Failure(
                    "Bệnh nhân này đang có một ca khám chưa hoàn tất trong ngày " +
                    "Vui lòng hoàn tất ca hiện tại trước khi tạo lượt tiếp nhận mới.");
            }

            try
            {
                var visit = new Visit
                {
                    PatientId = dto.PatientId,
                    DoctorId = dto.DoctorId,
                    ReasonForVisit = dto.ReasonForVisit,
                    CheckInDateTime = DateTime.Now,
                    Status = VisitStatus.Waiting,
                    AppointmentId = null,
                    ReceptionistId = dto.ReceptionistId,
                };

                bool success = _visitDAL.AddWalkInVisit(visit);
                return success ? Result.Success("Tiếp nhận bệnh nhân thành công!") : Result.Failure("Không thể lưu dữ liệu vào hệ thống.");
            }
            catch (Exception ex)
            {
                string innerMsg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return Result.Failure("Lỗi hệ thống: " + innerMsg);
            }
        }

        public Result<List<LookupItemDto>> GetDoctorsLookup() => Result<List<LookupItemDto>>.Success(_visitDAL.GetDoctorsLookup());
        public Result<List<LookupItemDto>> GetPatientsLookup() => Result<List<LookupItemDto>>.Success(_visitDAL.GetPatientsLookup());

        public List<string> GetWalkInWarnings(int doctorId)
        {
            var warnings = new List<string>();
            TimeSpan time = DateTime.Now.TimeOfDay;

            // Cảnh báo ngoài giờ làm việc
            bool isMorning = time >= SystemConstants.MorningStartTime && time < SystemConstants.MorningEndTime;
            bool isAfternoon = time >= SystemConstants.AfternoonStartTime && time < SystemConstants.AfternoonEndTime;

            if (!isMorning && !isAfternoon)
            {
                string mStart = SystemConstants.MorningStartTime.ToString(@"hh\:mm");
                string mEnd = SystemConstants.MorningEndTime.ToString(@"hh\:mm");
                string aStart = SystemConstants.AfternoonStartTime.ToString(@"hh\:mm");
                string aEnd = SystemConstants.AfternoonEndTime.ToString(@"hh\:mm");
                warnings.Add($"Hiện tại đang là ngoài khung giờ làm việc tiêu chuẩn ({mStart}-{mEnd}, {aStart}-{aEnd}).");
            }

            // Cảnh báo quá tải bác sĩ
            if (IsDoctorOverloaded(doctorId))
            {
                warnings.Add($"Bác sĩ này hôm nay đã tiếp nhận từ {SystemConstants.MaxDailyVisitsPerDoctor} bệnh nhân trở lên.");
            }

            return warnings;
        }

        public bool IsDoctorOverloaded(int doctorId)
        {
            int currentCount = _visitDAL.CountVisitsToday(doctorId);
            return currentCount >= SystemConstants.MaxDailyVisitsPerDoctor;

        }

        public Result UpdateVisitStatus(int visitId, VisitStatus newStatus)
        {
            try
            {
                bool success = _visitDAL.UpdateStatus(visitId, newStatus);
                return success ? Result.Success("Cập nhật trạng thái thành công") : Result.Failure("Không tìm thấy ca khám");
            }
            catch (Exception ex)
            {
                return Result.Failure("Lỗi cập nhật trạng thái: " + ex.Message);
            }
        }

        public bool HasActiveVisitToday(int patientId)
        {
            return _visitDAL.HasActiveVisitToday(patientId);
        }
    }
}