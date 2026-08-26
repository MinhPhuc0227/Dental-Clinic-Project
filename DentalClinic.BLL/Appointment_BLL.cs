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
    public class Appointment_BLL
    {
        private readonly Appointment_DAL _appointmentDAL;

        public Appointment_BLL(Appointment_DAL appointmentDAL)
        {
            _appointmentDAL = appointmentDAL;
        }

        public Result<List<AppointmentListDto>> GetFiltered(AppointmentFilterDto filter)
        {
            try
            {
                var list = _appointmentDAL.GetFiltered(filter);
                return Result<List<AppointmentListDto>>.Success(list);
            }
            catch (Exception ex)
            {
                return Result<List<AppointmentListDto>>.Failure("Lỗi khi tải danh sách lịch hẹn: " + ex.Message);
            }
        }

        public Result<AppointmentDetailDto> GetById(int id)
        {
            try
            {
                var app = _appointmentDAL.GetById(id);
                if (app == null)
                    return Result<AppointmentDetailDto>.Failure("Không tìm thấy lịch hẹn.");

                var dto = new AppointmentDetailDto
                {
                    AppointmentId = app.AppointmentId,
                    PatientId = app.PatientId,
                    PatientName = app.Patient?.FullName ?? string.Empty,
                    DoctorId = app.DoctorId,
                    DoctorName = app.Doctor?.FullName ?? string.Empty,
                    AppointmentDateTime = app.AppointmentDateTime,
                    ReasonForVisit = app.ReasonForVisit,
                    Note = app.Note,
                    Status = app.Status,
                    ReceptionistId = app.ReceptionistId,
                    ReceptionistName = app.Receptionist?.FullName ?? string.Empty,
                    CreatedDate = app.CreatedDate
                };

                return Result<AppointmentDetailDto>.Success(dto);
            }
            catch (Exception ex)
            {
                return Result<AppointmentDetailDto>.Failure("Lỗi khi lấy chi tiết lịch hẹn: " + ex.Message);
            }
        }

        // CREATE
        public Result Create(AppointmentCreateDto dto)
        {
            string? validationError = dto.Validate();
            if (!string.IsNullOrEmpty(validationError)) return Result.Failure(validationError);

            DateTime fullDateTime = dto.AppointmentDate.Date.Add(dto.AppointmentTime);

            // Chặn đặt lịch ở quá khứ
            if (fullDateTime < DateTime.Now)
                return Result.Failure("Không thể đặt lịch cho một thời điểm trong quá khứ.");

            // Kiểm tra trùng lịch Bệnh nhân
            if (_appointmentDAL.HasPatientConflict(dto.PatientId, fullDateTime, SystemConstants.DefaultSlotDurationMinutes))
                return Result.Failure("Bệnh nhân này đang có một lịch hẹn khác trùng vào khung giờ này.");

            using (var transaction = _appointmentDAL.BeginTransaction())
            {
                try
                {
                    var entity = new Appointment
                    {
                        PatientId = dto.PatientId,
                        DoctorId = dto.DoctorId,
                        AppointmentDateTime = fullDateTime,
                        ReasonForVisit = dto.ReasonForVisit,
                        Note = dto.Note,
                        ReceptionistId = dto.ReceptionistId,
                        Status = AppointmentStatus.Pending,
                        CreatedDate = DateTime.Now
                    };

                    bool success = _appointmentDAL.Add(entity);
                    if (success)
                    {
                        transaction.Commit();
                        return Result.Success("Tạo lịch hẹn thành công.");
                    }

                    transaction.Rollback();
                    return Result.Failure("Tạo lịch hẹn thất bại.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    string innerMsg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    return Result.Failure("Lỗi hệ thống khi tạo lịch hẹn: " + innerMsg);
                }
            }
        }

        public Result Update(AppointmentUpdateDto dto)
        {
            string? validationError = dto.Validate();
            if (!string.IsNullOrEmpty(validationError)) return Result.Failure(validationError);

            var entity = _appointmentDAL.GetById(dto.AppointmentId);
            if (entity == null)
            {
                return Result.Failure("Không tìm thấy dữ liệu lịch hẹn để cập nhật.");
            }

            if (entity.Status == AppointmentStatus.Completed || entity.Status == AppointmentStatus.Cancelled)
            {
                return Result.Failure("Không thể chỉnh sửa lịch hẹn đã hoàn thành hoặc đã hủy.");
            }

            DateTime fullDateTime = dto.AppointmentDate.Date.Add(dto.AppointmentTime);

            // Kiểm tra trùng lịch Bệnh nhân
            if (_appointmentDAL.HasPatientConflict(dto.PatientId, fullDateTime, SystemConstants.DefaultSlotDurationMinutes, dto.AppointmentId))
                return Result.Failure("Bệnh nhân này đang có một lịch hẹn khác trùng vào khung giờ này.");

            using (var transaction = _appointmentDAL.BeginTransaction())
            {
                try
                {
                    entity.PatientId = dto.PatientId;
                    entity.DoctorId = dto.DoctorId;
                    entity.AppointmentDateTime = fullDateTime;
                    entity.ReasonForVisit = dto.ReasonForVisit;
                    entity.Note = dto.Note;
                    entity.Status = dto.Status;

                    bool success = _appointmentDAL.Update(entity);
                    if (success)
                    {
                        transaction.Commit();
                        return Result.Success("Cập nhật lịch hẹn thành công.");
                    }

                    transaction.Rollback();
                    return Result.Failure("Cập nhật lịch hẹn thất bại.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return Result.Failure("Lỗi hệ thống khi cập nhật lịch hẹn: " + ex.Message);
                }
            }
        }

        public List<string> GetBookingWarnings(int doctorId, DateTime fullDateTime, int? excludeAppId = null)
        {
            var warnings = new List<string>();

            // 1: Vượt số ngày đặt trước
            if (fullDateTime > DateTime.Now.AddDays(SystemConstants.MaxAdvanceBookingDays))
                warnings.Add($"Lịch hẹn vượt quá số ngày đặt trước tối đa ({SystemConstants.MaxAdvanceBookingDays} ngày).");

            // 2: Ngoài giờ làm việc
            TimeSpan time = fullDateTime.TimeOfDay;
            bool isMorning = time >= SystemConstants.MorningStartTime && time < SystemConstants.MorningEndTime;
            bool isAfternoon = time >= SystemConstants.AfternoonStartTime && time < SystemConstants.AfternoonEndTime;
            if (!isMorning && !isAfternoon)
            {
                string mStart = SystemConstants.MorningStartTime.ToString(@"hh\:mm");
                string mEnd = SystemConstants.MorningEndTime.ToString(@"hh\:mm");
                string aStart = SystemConstants.AfternoonStartTime.ToString(@"hh\:mm");
                string aEnd = SystemConstants.AfternoonEndTime.ToString(@"hh\:mm");
                warnings.Add($"Giờ hẹn đang nằm ngoài khung giờ làm việc tiêu chuẩn ({mStart}-{mEnd}, {aStart}-{aEnd}).");
            }

            // 3: Trùng lịch Bác sĩ
            if (_appointmentDAL.HasDoctorConflict(doctorId, fullDateTime, SystemConstants.DefaultSlotDurationMinutes, excludeAppId))
                warnings.Add("Bác sĩ này đã có lịch hẹn/ca khám trùng vào khung giờ này.");

            return warnings;
        }
        public Result<List<LookupItemDto>> GetPatientsLookup()
        {
            try
            {
                return Result<List<LookupItemDto>>.Success(_appointmentDAL.GetPatientsLookup());
            }
            catch (Exception ex)
            {
                return Result<List<LookupItemDto>>.Failure("Không thể lấy danh sách bệnh nhân: " + ex.Message);
            }
        }

        public Result<List<LookupItemDto>> GetDoctorsLookup()
        {
            try
            {
                return Result<List<LookupItemDto>>.Success(_appointmentDAL.GetDoctorsLookup());
            }
            catch (Exception ex)
            {
                return Result<List<LookupItemDto>>.Failure("Không thể lấy danh sách bác sĩ: " + ex.Message);
            }
        }

        public Result CreateVisitFromAppointment(int appointmentId, int receptionistId)
        {
            try
            {
                // Gọi xuống tầng DAL để thực hiện thao tác
                bool isSuccess = _appointmentDAL.CreateVisitFromAppointmentTransaction(appointmentId, receptionistId);

                if (isSuccess)
                {
                    return Result.Success("Tiếp nhận thành công! Bệnh nhân đã được chuyển sang hàng chờ khám.");
                }
                else
                {
                    return Result.Failure("Lịch hẹn không tồn tại hoặc đã bị hủy từ trước!");
                }
            }
            catch (Exception ex)
            {
                // Bắt lỗi hệ thống (ví dụ: mất kết nối DB)
                string innerMsg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return Result.Failure("Lỗi hệ thống khi tiếp nhận: " + innerMsg);
            }
        }
    }
}
