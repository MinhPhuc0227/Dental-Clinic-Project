using DentalClinic.DAL;
using DentalClinic.DTO.Common;
using DentalClinic.DTO;
using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.BLL
{
    public class Service_BLL
    {
        private readonly Service_DAL _dal;

        public Service_BLL(Service_DAL dal)
        {
            _dal = dal;
        }

        // GetAll
        public Result<List<ServiceDto>> GetAll(string keyword = "", bool? isLongTerm = null, ServiceStatus? status = null)
        {
            try
            {
                var list = _dal.GetAll(keyword, isLongTerm, status);

                var dtoList = list.Select(s => new ServiceDto
                {
                    ServiceId = s.ServiceId,
                    ServiceName = s.ServiceName,
                    Description = s.Description,
                    UnitPrice = s.UnitPrice,
                    IsLongTerm = s.IsLongTerm,
                    Status = s.Status
                }).ToList();

                return Result<List<ServiceDto>>.Success(dtoList);
            }
            catch (Exception ex)
            {
                return Result<List<ServiceDto>>.Failure("Lỗi tải danh sách dịch vụ: " + ex.Message);
            }
        }

        // GetById
        public Result<ServiceDto> GetById(int serviceId)
        {
            if (serviceId <= 0)
            {
                return Result<ServiceDto>.Failure("Mã dịch vụ không hợp lệ.");
            }

            try
            {
                var service = _dal.GetById(serviceId);

                if (service == null)
                {
                    return Result<ServiceDto>.Failure("Không tìm thấy dịch vụ.");
                }

                var dto = new ServiceDto
                {
                    ServiceId = service.ServiceId,
                    ServiceName = service.ServiceName,
                    UnitPrice = service.UnitPrice,
                    IsLongTerm = service.IsLongTerm,
                    Description = service.Description,
                    Status = service.Status
                };

                return Result<ServiceDto>.Success(dto);
            }
            catch (Exception ex)
            {
                return Result<ServiceDto>.Failure(
                    "Lỗi khi tải thông tin dịch vụ: " + ex.Message);
            }
        }

        // ADD
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
                    IsLongTerm = dto.IsLongTerm,
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

        // UPDATE
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
                    IsLongTerm = dto.IsLongTerm,
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

        // DELETE
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
