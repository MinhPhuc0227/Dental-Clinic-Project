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
        private readonly Visit_BLL _visitBLL;
        public Appointment_BLL(Appointment_DAL appointmentDAL, Visit_BLL visitBLL)
        {
            _appointmentDAL = appointmentDAL;
            _visitBLL = visitBLL;
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
                        Status = AppointmentStatus.Scheduled,
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

            if (entity.Status == AppointmentStatus.CheckedIn || entity.Status == AppointmentStatus.Cancelled)
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

        public Result CreateVisitFromAppointment(
    int appointmentId,
    int receptionistId,
    bool keepPriority = true)
        {
            try
            {
                // 1. Lấy thông tin lịch hẹn
                var appointment = _appointmentDAL.GetById(appointmentId);

                if (appointment == null)
                {
                    return Result.Failure(
                        "Không tìm thấy lịch hẹn.");
                }

                // 2. Kiểm tra trạng thái lịch hẹn
                if (appointment.Status != AppointmentStatus.Scheduled)
                {
                    return Result.Failure(
                        "Lịch hẹn này không còn ở trạng thái có thể tiếp nhận.");
                }

                // 3. Kiểm tra bệnh nhân đã có ca khám chưa hoàn tất hôm nay
                if (_visitBLL.HasActiveVisitToday(appointment.PatientId))
                {
                    return Result.Failure(
                        "Bệnh nhân này đang có một ca khám chưa hoàn tất trong ngày " +
                        "(chờ khám, đang khám hoặc chờ thanh toán).\n\n" +
                        "Vui lòng hoàn tất ca hiện tại trước khi tiếp nhận lịch hẹn này.");
                }

                // 4. Tạo Visit
                bool isSuccess =
                    _appointmentDAL.CreateVisitFromAppointmentTransaction(
                        appointmentId,
                        receptionistId,
                        keepPriority);

                if (isSuccess)
                {
                    string msg = keepPriority
                        ? "Tiếp nhận thành công! Bệnh nhân đã được chuyển lên đầu hàng chờ."
                        : "Tiếp nhận thành công! (Bệnh nhân bị mất quyền ưu tiên do sai giờ và đã xếp hàng như khách vãng lai).";

                    return Result.Success(msg);
                }

                return Result.Failure(
                    "Lịch hẹn không tồn tại hoặc đã bị hủy từ trước!");
            }
            catch (InvalidOperationException ex)
            {
                return Result.Failure(ex.Message);
            }
            catch (Exception ex)
            {
                return Result.Failure(
                    "Lỗi hệ thống khi tiếp nhận: " +
                    (ex.InnerException?.Message ?? ex.Message));
            }
        }

        public List<string> GetCheckInWarnings(DateTime appointmentDateTime)
        {
            var warnings = new List<string>();
            var diff = DateTime.Now - appointmentDateTime; // Trễ là số dương, Sớm là số âm

            if (diff.TotalMinutes < -SystemConstants.AllowedEarlyCheckInMinutes)
            {
                warnings.Add($"Bệnh nhân đến quá sớm (sớm {Math.Abs((int)diff.TotalMinutes)} phút). Chỉ cho phép tiếp nhận trước {SystemConstants.AllowedEarlyCheckInMinutes} phút.");
            }
            else if (diff.TotalMinutes > SystemConstants.AllowedLateCheckInMinutes)
            {
                warnings.Add($"Lịch hẹn đã quá hạn {Math.Abs((int)diff.TotalMinutes)} phút. Bác sĩ có thể đã chuyển sang ca khám khác.");
            }

            return warnings;
        }

        // Đặt lịch online
        public Result CreateOnline(
    int patientId,
    OnlineAppointmentCreateDto dto)
        {
            if (patientId <= 0)
            {
                return Result.Failure(
                    "Không xác định được bệnh nhân đang đăng nhập.");
            }

            string? validationError = dto.Validate();

            if (!string.IsNullOrEmpty(validationError))
            {
                return Result.Failure(validationError);
            }

            DateTime fullDateTime =
                dto.AppointmentDate.Date.Add(dto.AppointmentTime);

            // Không cho đặt lịch trong quá khứ
            if (fullDateTime < DateTime.Now)
            {
                return Result.Failure(
                    "Không thể đặt lịch cho thời điểm trong quá khứ.");
            }

            // Không cho đặt quá xa
            if (fullDateTime >
                DateTime.Now.AddDays(SystemConstants.MaxAdvanceBookingDays))
            {
                return Result.Failure(
                    $"Chỉ được đặt lịch trước tối đa {SystemConstants.MaxAdvanceBookingDays} ngày.");
            }

            // Kiểm tra giờ làm việc
            TimeSpan time = fullDateTime.TimeOfDay;

            bool isMorning =
                time >= SystemConstants.MorningStartTime &&
                time < SystemConstants.MorningEndTime;

            bool isAfternoon =
                time >= SystemConstants.AfternoonStartTime &&
                time < SystemConstants.AfternoonEndTime;

            if (!isMorning && !isAfternoon)
            {
                return Result.Failure(
                    "Giờ đặt lịch nằm ngoài giờ làm việc của phòng khám.");
            }

            // Kiểm tra trùng lịch bệnh nhân
            if (_appointmentDAL.HasPatientConflict(
                patientId,
                fullDateTime,
                SystemConstants.DefaultSlotDurationMinutes))
            {
                return Result.Failure(
                    "Bạn đã có một lịch hẹn khác trùng vào khung giờ này.");
            }

            // Kiểm tra trùng lịch bác sĩ
            if (_appointmentDAL.HasDoctorConflict(
                dto.DoctorId,
                fullDateTime,
                SystemConstants.DefaultSlotDurationMinutes))
            {
                return Result.Failure(
                    "Bác sĩ đã có lịch hẹn khác trùng vào khung giờ này.");
            }

            using var transaction = _appointmentDAL.BeginTransaction();

            try
            {
                var entity = new Appointment
                {
                    PatientId = patientId,
                    DoctorId = dto.DoctorId,
                    AppointmentDateTime = fullDateTime,
                    ReasonForVisit = dto.ReasonForVisit.Trim(),
                    Note = string.IsNullOrWhiteSpace(dto.Note)
                        ? null
                        : dto.Note.Trim(),

                    // Đặt lịch online → chưa có lễ tân
                    ReceptionistId = null,

                    Status = AppointmentStatus.Scheduled,
                    CreatedDate = DateTime.Now
                };

                bool success = _appointmentDAL.Add(entity);

                if (!success)
                {
                    transaction.Rollback();

                    return Result.Failure(
                        "Tạo lịch hẹn thất bại.");
                }

                transaction.Commit();

                return Result.Success(
                    "Đặt lịch khám thành công.");
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                return Result.Failure(
                    "Lỗi hệ thống khi đặt lịch: " +
                    (ex.InnerException?.Message ?? ex.Message));
            }
        }

        // Lấy lịch online
        public Result<List<AppointmentListDto>> GetByPatientId(int patientId)
        {
            if (patientId <= 0)
            {
                return Result<List<AppointmentListDto>>
                    .Failure("Mã bệnh nhân không hợp lệ.");
            }

            try
            {
                var list = _appointmentDAL.GetByPatientId(patientId);

                return Result<List<AppointmentListDto>>
                    .Success(list);
            }
            catch (Exception ex)
            {
                return Result<List<AppointmentListDto>>
                    .Failure(
                        "Không thể tải lịch hẹn: " + ex.Message);
            }
        }

        // Hủy lịch online
        public Result CancelByPatient(
    int appointmentId,
    int patientId)
        {
            if (appointmentId <= 0)
            {
                return Result.Failure(
                    "Mã lịch hẹn không hợp lệ.");
            }

            if (patientId <= 0)
            {
                return Result.Failure(
                    "Mã bệnh nhân không hợp lệ.");
            }

            try
            {
                var appointment =
                    _appointmentDAL.GetById(appointmentId);

                if (appointment == null)
                {
                    return Result.Failure(
                        "Không tìm thấy lịch hẹn.");
                }

                // Không cho bệnh nhân hủy lịch của người khác
                if (appointment.PatientId != patientId)
                {
                    return Result.Failure(
                        "Bạn không có quyền hủy lịch hẹn này.");
                }

                if (appointment.Status != AppointmentStatus.Scheduled)
                {
                    return Result.Failure(
                        "Chỉ có thể hủy lịch hẹn đang ở trạng thái Đã đặt lịch.");
                }

                bool success =
                    _appointmentDAL.CancelByPatient(
                        appointmentId,
                        patientId);

                return success
                    ? Result.Success("Hủy lịch hẹn thành công.")
                    : Result.Failure("Hủy lịch hẹn thất bại.");
            }
            catch (Exception ex)
            {
                return Result.Failure(
                    "Lỗi hệ thống khi hủy lịch: " +
                    (ex.InnerException?.Message ?? ex.Message));
            }
        }
    }
}
