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

        public Result Create(AppointmentCreateDto dto)
        {
            // Xác thực dữ liệu đầu vào bằng Extension Method ValidateDto
            string? validationError = dto.Validate();
            if (!string.IsNullOrEmpty(validationError))
            {
                return Result.Failure(validationError);
            }

            using (var transaction = _appointmentDAL.BeginTransaction())
            {
                try
                {
                    DateTime fullDateTime = dto.AppointmentDate.Date.Add(dto.AppointmentTime);

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
                    //return Result.Failure("Lỗi hệ thống khi tạo lịch hẹn: " + ex.Message);
                    string innerMsg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    return Result.Failure("Lỗi hệ thống khi tạo lịch hẹn: " + innerMsg);
                }
            }
        }

        public Result Update(AppointmentUpdateDto dto)
        {
            // Xác thực dữ liệu đầu vào bằng Extension Method ValidateDto
            string? validationError = dto.Validate();
            if (!string.IsNullOrEmpty(validationError))
            {
                return Result.Failure(validationError);
            }

            using (var transaction = _appointmentDAL.BeginTransaction())
            {
                try
                {
                    var entity = _appointmentDAL.GetById(dto.AppointmentId);
                    if (entity == null)
                    {
                        return Result.Failure("Không tìm thấy dữ liệu lịch hẹn để cập nhật.");
                    }

                    entity.PatientId = dto.PatientId;
                    entity.DoctorId = dto.DoctorId;
                    entity.AppointmentDateTime = dto.AppointmentDate.Date.Add(dto.AppointmentTime);
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
