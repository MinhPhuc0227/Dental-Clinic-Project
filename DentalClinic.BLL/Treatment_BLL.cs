using DentalClinic.DAL;
using DentalClinic.DTO;
using DentalClinic.DTO.Common;
using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DentalClinic.BLL
{
    public class Treatment_BLL
    {
        private readonly Treatment_DAL _dal;
        private readonly Service_DAL _serviceDAL;
        private readonly Doctor_DAL _doctorDAL;
        private readonly Visit_DAL _visitDAL;

        public Treatment_BLL(
            Treatment_DAL dal,
            Service_DAL serviceDAL,
            Doctor_DAL doctorDAL,
            Visit_DAL visitDAL)
        {
            _dal = dal;
            _serviceDAL = serviceDAL;
            _doctorDAL = doctorDAL;
            _visitDAL = visitDAL;
        }

        // GET ALL BY PATIENT
        public Result<List<TreatmentDto>> GetByPatientId(int patientId)
        {
            if (patientId <= 0)
            {
                return Result<List<TreatmentDto>>.Failure("Mã bệnh nhân không hợp lệ.");
            }

            try
            {
                var list = _dal.GetByPatientId(patientId);

                var dtoList = list.Select(t =>
                {
                    int completedSessions = t.Visits.Count(v => v.Status == VisitStatus.Completed);
                    double progressPercent = 0;

                    if (t.PlannedSessions.HasValue && t.PlannedSessions.Value > 0)
                    {
                        progressPercent = (double)completedSessions / t.PlannedSessions.Value * 100;

                        // Không cho vượt quá 100%
                        if (progressPercent > 100)
                            progressPercent = 100;
                    }

                    return new TreatmentDto
                    {
                        TreatmentId = t.TreatmentId,
                        PatientId = t.PatientId,
                        DoctorId = t.DoctorId,
                        ServiceId = t.ServiceId,
                        ServiceName = t.Service?.ServiceName ?? string.Empty,
                        DoctorName = t.Doctor?.FullName ?? string.Empty,
                        StartDate = t.StartDate,
                        EndDate = t.EndDate,
                        PlannedSessions = t.PlannedSessions,
                        TotalAmount = t.TotalAmount,
                        Status = t.Status,
                        Note = t.Note,
                        CompletedSessions = completedSessions,
                        ProgressPercent = progressPercent
                    };
                }).ToList();

                return Result<List<TreatmentDto>>.Success(dtoList);
            }
            catch (Exception ex)
            {
                return Result<List<TreatmentDto>>.Failure("Lỗi khi tải danh sách kế hoạch điều trị: " + ex.Message);
            }
        }

        // GET BY ID
        public Result<TreatmentDto> GetById(int treatmentId)
        {
            if (treatmentId <= 0)
            {
                return Result<TreatmentDto>.Failure("Mã kế hoạch điều trị không hợp lệ.");
            }

            try
            {
                var treatment = _dal.GetById(treatmentId);

                if (treatment == null)
                {
                    return Result<TreatmentDto>.Failure("Không tìm thấy kế hoạch điều trị.");
                }

                int completedSessions = treatment.Visits.Count(v => v.Status == VisitStatus.Completed);
                double progressPercent = 0;

                if (treatment.PlannedSessions.HasValue && treatment.PlannedSessions.Value > 0)
                {
                    progressPercent = (double)completedSessions / treatment.PlannedSessions.Value * 100;

                    if (progressPercent > 100)
                        progressPercent = 100;
                }

                var dto = new TreatmentDto
                {
                    TreatmentId = treatment.TreatmentId,
                    PatientId = treatment.PatientId,
                    DoctorId = treatment.DoctorId,
                    ServiceId = treatment.ServiceId,
                    ServiceName = treatment.Service?.ServiceName ?? string.Empty,
                    DoctorName = treatment.Doctor?.FullName ?? string.Empty,
                    StartDate = treatment.StartDate,
                    EndDate = treatment.EndDate,
                    PlannedSessions = treatment.PlannedSessions,
                    TotalAmount = treatment.TotalAmount,
                    Status = treatment.Status,
                    Note = treatment.Note,
                    CompletedSessions = completedSessions,
                    ProgressPercent = progressPercent
                };

                return Result<TreatmentDto>.Success(dto);
            }
            catch (Exception ex)
            {
                return Result<TreatmentDto>.Failure("Lỗi khi tải kế hoạch điều trị: " + ex.Message);
            }
        }

        // ADD
        public Result<int> Add(CreateTreatmentDto dto)
        {
            var validationError = dto.Validate();

            if (!string.IsNullOrEmpty(validationError))
            {
                return Result<int>.Failure(validationError);
            }

            try
            {
                // Kiểm tra dịch vụ
                var service = _serviceDAL.GetById(dto.ServiceId);

                if (service == null)
                {
                    return Result<int>.Failure("Không tìm thấy dịch vụ.");
                }

                // Chỉ cho phép dịch vụ dài hạn
                if (!service.IsLongTerm)
                {
                    return Result<int>.Failure("Chỉ dịch vụ điều trị dài hạn mới được tạo kế hoạch điều trị.");
                }

                // Kiểm tra bác sĩ
                var doctor = _doctorDAL.GetById(dto.DoctorId);

                if (doctor == null)
                {
                    return Result<int>.Failure("Không tìm thấy bác sĩ.");
                }

                var entity = new Treatment
                {
                    PatientId = dto.PatientId,
                    DoctorId = dto.DoctorId,
                    ServiceId = dto.ServiceId,
                    StartDate = dto.StartDate,
                    EndDate = dto.EndDate,
                    PlannedSessions = dto.PlannedSessions,
                    TotalAmount = service.UnitPrice,
                    Status = TreatmentStatus.InProgress,
                    Note = string.IsNullOrWhiteSpace(dto.Note) ? null : dto.Note.Trim()
                };

                bool success = _dal.Add(entity);

                if (!success)
                {
                    return Result<int>.Failure("Tạo kế hoạch điều trị thất bại.");
                }

                return Result<int>.Success(entity.TreatmentId, "Tạo kế hoạch điều trị thành công!");
            }
            catch (Exception ex)
            {
                return Result<int>.Failure("Lỗi hệ thống khi tạo kế hoạch điều trị: " + ex.Message);
            }
        }

        // UPDATE
        public Result Update(UpdateTreatmentDto dto)
        {
            var validationError = dto.Validate();

            if (!string.IsNullOrEmpty(validationError))
            {
                return Result.Failure(validationError);
            }

            try
            {
                var existing = _dal.GetById(dto.TreatmentId);

                if (existing == null)
                {
                    return Result.Failure("Không tìm thấy kế hoạch điều trị.");
                }

                var service = _serviceDAL.GetById(dto.ServiceId);

                if (service == null)
                {
                    return Result.Failure("Không tìm thấy dịch vụ.");
                }

                if (!service.IsLongTerm)
                {
                    return Result.Failure("Dịch vụ được chọn không phải dịch vụ điều trị dài hạn.");
                }

                var doctor = _doctorDAL.GetById(dto.DoctorId);

                if (doctor == null)
                {
                    return Result.Failure("Không tìm thấy bác sĩ.");
                }

                var entity = new Treatment
                {
                    TreatmentId = dto.TreatmentId,
                    PatientId = existing.PatientId,
                    DoctorId = dto.DoctorId,
                    ServiceId = dto.ServiceId,
                    StartDate = dto.StartDate,
                    EndDate = dto.EndDate,
                    PlannedSessions = dto.PlannedSessions,
                    TotalAmount = service.UnitPrice,
                    Status = dto.Status,
                    Note = string.IsNullOrWhiteSpace(dto.Note) ? null : dto.Note.Trim()
                };

                bool success = _dal.Update(entity);

                return success
                    ? Result.Success("Cập nhật kế hoạch điều trị thành công!")
                    : Result.Failure("Cập nhật kế hoạch điều trị thất bại.");
            }
            catch (Exception ex)
            {
                return Result.Failure("Lỗi hệ thống khi cập nhật kế hoạch điều trị: " + ex.Message);
            }
        }

        // DELETE
        public Result Delete(int treatmentId)
        {
            if (treatmentId <= 0)
            {
                return Result.Failure("Mã kế hoạch điều trị không hợp lệ.");
            }

            try
            {
                // Chỉ được xóa khi chưa có Visit nào được gán
                if (_dal.HasVisits(treatmentId))
                {
                    return Result.Failure("Không thể xóa kế hoạch điều trị vì đã có buổi khám thuộc kế hoạch.");
                }

                bool success = _dal.Delete(treatmentId);

                return success
                    ? Result.Success("Xóa kế hoạch điều trị thành công!")
                    : Result.Failure("Không tìm thấy kế hoạch điều trị cần xóa.");
            }
            catch (Exception ex)
            {
                return Result.Failure("Lỗi khi xóa kế hoạch điều trị: " + ex.Message);
            }
        }

        // COMPLETE
        public Result Complete(int treatmentId)
        {
            if (treatmentId <= 0)
            {
                return Result.Failure("Mã kế hoạch điều trị không hợp lệ.");
            }

            try
            {
                var treatment = _dal.GetById(treatmentId);

                if (treatment == null)
                {
                    return Result.Failure("Không tìm thấy kế hoạch điều trị.");
                }

                if (treatment.Status == TreatmentStatus.Completed)
                {
                    return Result.Failure("Kế hoạch điều trị đã hoàn thành.");
                }

                if (treatment.Status == TreatmentStatus.Cancelled)
                {
                    return Result.Failure("Kế hoạch điều trị đã bị hủy.");
                }

                bool success = _dal.UpdateStatus(treatmentId, TreatmentStatus.Completed);

                return success
                    ? Result.Success("Kế hoạch điều trị đã được đánh dấu hoàn thành!")
                    : Result.Failure("Không thể cập nhật trạng thái kế hoạch.");
            }
            catch (Exception ex)
            {
                return Result.Failure("Lỗi hệ thống khi hoàn thành kế hoạch: " + ex.Message);
            }
        }

        // GET VISITS
        public Result<List<TreatmentSessionDto>> GetVisits(int treatmentId)
        {
            if (treatmentId <= 0)
            {
                return Result<List<TreatmentSessionDto>>.Failure("Mã kế hoạch điều trị không hợp lệ.");
            }

            try
            {
                var visits = _dal.GetVisitsByTreatmentId(treatmentId);

                var dtoList = visits.Select(v => new TreatmentSessionDto
                {
                    VisitId = v.VisitId,
                    TreatmentSessionNumber = v.TreatmentSessionNumber,
                    CheckInDateTime = v.CheckInDateTime,
                    DoctorName = v.Doctor?.FullName ?? string.Empty,
                    Status = v.Status
                }).ToList();

                return Result<List<TreatmentSessionDto>>.Success(dtoList);
            }
            catch (Exception ex)
            {
                return Result<List<TreatmentSessionDto>>.Failure("Lỗi khi tải các buổi điều trị: " + ex.Message);
            }
        }

        // COMPLETED SESSION COUNT
        public int GetCompletedSessionCount(int treatmentId)
        {
            return _dal.GetCompletedVisitCount(treatmentId);
        }

        // PROGRESS
        public double GetProgressPercent(int treatmentId, int? plannedSessions)
        {
            if (!plannedSessions.HasValue || plannedSessions.Value <= 0)
            {
                return 0;
            }

            int completedSessions = GetCompletedSessionCount(treatmentId);
            double progress = (double)completedSessions / plannedSessions.Value * 100;

            return Math.Min(progress, 100);
        }

        // NEXT SESSION NUMBER
        public int GetNextSessionNumber(int treatmentId)
        {
            return _dal.GetNextSessionNumber(treatmentId);
        }

        // ASSIGN CURRENT VISIT
        public Result AssignVisitToTreatment(int visitId, int treatmentId)
        {
            if (visitId <= 0)
            {
                return Result.Failure("Mã buổi khám không hợp lệ.");
            }

            if (treatmentId <= 0)
            {
                return Result.Failure("Mã kế hoạch điều trị không hợp lệ.");
            }

            try
            {
                var treatment = _dal.GetById(treatmentId);

                if (treatment == null)
                {
                    return Result.Failure("Không tìm thấy kế hoạch điều trị.");
                }

                // Chỉ kế hoạch đang thực hiện mới được thêm buổi
                if (treatment.Status != TreatmentStatus.InProgress)
                {
                    return Result.Failure("Chỉ có thể thêm buổi vào kế hoạch đang thực hiện.");
                }

                var visit = _visitDAL.GetById(visitId);

                if (visit == null)
                {
                    return Result.Failure("Không tìm thấy buổi khám hiện tại.");
                }

                // Visit phải thuộc cùng bệnh nhân
                if (visit.PatientId != treatment.PatientId)
                {
                    return Result.Failure("Buổi khám không thuộc bệnh nhân của kế hoạch điều trị.");
                }

                if (visit.Status == VisitStatus.Cancelled)
                {
                    return Result.Failure("Không thể thêm buổi khám đã bị hủy vào kế hoạch điều trị.");
                }

                // Visit không được thuộc Treatment khác
                if (visit.TreatmentId.HasValue)
                {
                    return Result.Failure("Buổi khám này đã thuộc một kế hoạch điều trị khác.");
                }

                // Lấy session tiếp theo
                int nextSessionNumber = _dal.GetNextSessionNumber(treatmentId);

                bool success = _visitDAL.AssignTreatment(visitId, treatmentId, nextSessionNumber);

                return success
                    ? Result.Success($"Thêm buổi điều trị thành công! Đây là buổi {nextSessionNumber}.")
                    : Result.Failure("Không thể thêm buổi điều trị.");
            }
            catch (Exception ex)
            {
                return Result.Failure("Lỗi hệ thống khi thêm buổi điều trị: " + ex.Message);
            }
        }

        public Result<TreatmentDto?> GetActiveByPatientAndService(int patientId, int serviceId)
        {
            try
            {
                var treatment = _dal.GetActiveByPatientAndService(patientId, serviceId);

                if (treatment == null)
                {
                    return Result<TreatmentDto?>.Success(null);
                }

                var dto = new TreatmentDto
                {
                    TreatmentId = treatment.TreatmentId,
                    PatientId = treatment.PatientId,
                    DoctorId = treatment.DoctorId,
                    ServiceId = treatment.ServiceId,
                    ServiceName = treatment.Service?.ServiceName ?? "",
                    DoctorName = treatment.Doctor?.FullName ?? "",
                    StartDate = treatment.StartDate,
                    EndDate = treatment.EndDate,
                    PlannedSessions = treatment.PlannedSessions,
                    TotalAmount = treatment.TotalAmount,
                    Status = treatment.Status,
                    Note = treatment.Note,
                    CompletedSessions = treatment.Visits.Count(v => v.Status == VisitStatus.Completed),
                    ProgressPercent = treatment.PlannedSessions.HasValue && treatment.PlannedSessions.Value > 0
                        ? Math.Min(100, treatment.Visits.Count(v => v.Status == VisitStatus.Completed) * 100.0 / treatment.PlannedSessions.Value)
                        : 0
                };

                return Result<TreatmentDto?>.Success(dto);
            }
            catch (Exception ex)
            {
                return Result<TreatmentDto?>.Failure("Lỗi khi kiểm tra kế hoạch điều trị: " + ex.Message);
            }
        }
    }
}