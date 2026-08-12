using DentalClinic.DAL;
using DentalClinic.DTO.Common;
using DentalClinic.DTO.Service;
using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.BLL
{
    public class Service_BLL
    {
        private readonly Service_DAL _dal = new Service_DAL();

        // GetAll
        public Result<List<ServiceDto>> GetAll()
        {
            try
            {
                var list = _dal.GetAll();
                var dtoList = list.Select(s => new ServiceDto
                {
                    ServiceId = s.ServiceId,
                    ServiceName = s.ServiceName,
                    UnitPrice = s.UnitPrice,
                    Description = s.Description,
                    Status = s.Status
                }).ToList();

                return Result<List<ServiceDto>>.Success(dtoList);
            }
            catch (Exception ex)
            {
                return Result<List<ServiceDto>>.Failure("Lỗi khi tải danh sách dịch vụ: " + ex.Message);
            }
        }

        // Add
        public Result Add(CreateServiceDto dto)
        {
            var validationError = dto.Validate();
            if (!string.IsNullOrEmpty(validationError))
            {
                return Result.Failure(validationError);
            }

            if (_dal.IsNameExists(dto.ServiceName.Trim()))
            {
                return Result.Failure("Tên dịch vụ đã tồn tại trong hệ thống.");
            }

            try
            {
                var entity = new Service
                {
                    ServiceName = dto.ServiceName.Trim(),
                    UnitPrice = dto.UnitPrice,
                    Description = dto.Description?.Trim(),
                    Status = dto.Status
                };

                bool isSuccess = _dal.Add(entity);
                return isSuccess
                    ? Result.Success("Thêm mới dịch vụ thành công!")
                    : Result.Failure("Thêm dịch vụ thất bại.");
            }
            catch (Exception ex)
            {
                return Result.Failure("Lỗi hệ thống: " + ex.Message);
            }
        }

        // Update
        public Result Update(UpdateServiceDto dto)
        {
            var validationError = dto.Validate();
            if (!string.IsNullOrEmpty(validationError))
            {
                return Result.Failure(validationError);
            }

            if (_dal.IsNameExists(dto.ServiceName.Trim(), dto.ServiceId))
            {
                return Result.Failure("Tên dịch vụ đã trùng với một dịch vụ khác.");
            }

            try
            {
                var entity = new Service
                {
                    ServiceId = dto.ServiceId,
                    ServiceName = dto.ServiceName.Trim(),
                    UnitPrice = dto.UnitPrice,
                    Description = dto.Description?.Trim(),
                    Status = dto.Status
                };

                bool isSuccess = _dal.Update(entity);
                return isSuccess
                    ? Result.Success("Cập nhật dịch vụ thành công!")
                    : Result.Failure("Không tìm thấy dịch vụ hoặc cập nhật thất bại.");
            }
            catch (Exception ex)
            {
                return Result.Failure("Lỗi hệ thống: " + ex.Message);
            }
        }

        // Delete
        public Result Delete(int serviceId)
        {
            if (serviceId <= 0)
            {
                return Result.Failure("Mã dịch vụ không hợp lệ.");
            }

            try
            {
                bool isSuccess = _dal.Delete(serviceId);
                return isSuccess
                    ? Result.Success("Xóa dịch vụ thành công!")
                    : Result.Failure("Không tìm thấy dịch vụ cần xóa.");
            }
            catch (Exception)
            {
                return Result.Failure("Không thể xóa do dịch vụ này đã phát sinh trong lịch khám hoặc hóa đơn.");
            }
        }
    }
}
