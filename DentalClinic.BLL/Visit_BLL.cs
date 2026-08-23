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
        // Trong file Visit_BLL.cs
        // 1. Khai báo biến _visitDAL
        private readonly Visit_DAL _visitDAL;

        // 2. Constructor nhận DAL từ ngoài truyền vào
        public Visit_BLL(Visit_DAL visitDAL)
        {
            _visitDAL = visitDAL;
        }

        // Tùy chọn: Constructor không tham số (Giúp bạn gọi new Visit_BLL() ở Form cho ngắn gọn)
        public Visit_BLL() : this(new Visit_DAL(new AppDbContext()))
        {
        }
        public Result<List<WaitingQueueDto>> GetWaitingQueue(DateTime date, string keyword, int? doctorId, VisitStatus? status)
        {
            try
            {
                var data = _visitDAL.GetWaitingQueue(date, keyword, doctorId, status);
                return Result<List<WaitingQueueDto>>.Success(data);
            }
            catch (Exception ex)
            {
                return Result<List<WaitingQueueDto>>.Failure("Lỗi khi tải danh sách hàng chờ: " + ex.Message);
            }
        }

        public Result<List<VisitListDto>> GetAllVisits(DateTime date, string keyword)
        {
            try
            {
                var data = _visitDAL.GetAllVisits(date, keyword);
                return Result<List<VisitListDto>>.Success(data);
            }
            catch (Exception ex)
            {
                return Result<List<VisitListDto>>.Failure("Lỗi khi tải danh sách: " + ex.Message);
            }
        }

        public Result CreateWalkInVisit(VisitCreateDto dto)
        {
            // 1. Kiểm tra Validate từ Data Annotations
            string? validationError = dto.Validate();
            if (!string.IsNullOrEmpty(validationError))
            {
                return Result.Failure(validationError);
            }

            try
            {
                // 2. Map DTO sang Entity Model
                var visit = new Visit
                {
                    PatientId = dto.PatientId,
                    DoctorId = dto.DoctorId,
                    ReasonForVisit = dto.ReasonForVisit,
                    CheckInDateTime = DateTime.Now,
                    Status = VisitStatus.Waiting, // Mới tới thì vào Hàng chờ
                    AppointmentId = null // Khách vãng lai
                };

                bool success = _visitDAL.AddWalkInVisit(visit);
                return success ? Result.Success("Tiếp nhận bệnh nhân thành công!")
                               : Result.Failure("Không thể lưu dữ liệu vào hệ thống.");
            }
            catch (Exception ex)
            {
                string innerMsg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return Result.Failure("Lỗi hệ thống: " + innerMsg);
            }
        }

        public Result<List<LookupItemDto>> GetDoctorsLookup() => Result<List<LookupItemDto>>.Success(_visitDAL.GetDoctorsLookup());
        public Result<List<LookupItemDto>> GetPatientsLookup() => Result<List<LookupItemDto>>.Success(_visitDAL.GetPatientsLookup());
    }
}

