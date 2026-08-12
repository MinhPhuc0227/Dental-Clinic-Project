using DentalClinic.DAL;
using DentalClinic.DTO.Common;
using DentalClinic.DTO.PaymentMethod;
using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.BLL
{
    public class PaymentMethod_BLL
    {
        private readonly PaymentMethod_DAL _dal = new PaymentMethod_DAL();

        // GetAll
        public Result<List<PaymentMethodDto>> GetAll()
        {
            try
            {
                var list = _dal.GetAll();
                var dtoList = list.Select(pm => new PaymentMethodDto
                {
                    PaymentMethodId = pm.PaymentMethodId,
                    PaymentMethodName = pm.PaymentMethodName,
                    Description = pm.Description,
                    IsCash = pm.IsCash,
                    Status = pm.Status
                }).ToList();

                return Result<List<PaymentMethodDto>>.Success(dtoList);
            }
            catch (Exception ex)
            {
                return Result<List<PaymentMethodDto>>.Failure("Lỗi tải danh sách phương thức thanh toán: " + ex.Message);
            }
        }

        // Add
        public Result Add(CreatePaymentMethodDto dto)
        {
            // Sử dụng ValidationHelper extension method
            var validationError = dto.Validate();
            if (!string.IsNullOrEmpty(validationError)) return Result.Failure(validationError);

            if (_dal.IsNameExists(dto.PaymentMethodName.Trim()))
                return Result.Failure("Tên phương thức thanh toán đã tồn tại.");

            try
            {
                var entity = new PaymentMethod
                {
                    PaymentMethodName = dto.PaymentMethodName.Trim(),
                    Description = dto.Description?.Trim(),
                    IsCash = dto.IsCash,
                    Status = dto.Status
                };

                bool success = _dal.Add(entity);
                return success ? Result.Success("Thêm mới phương thức thanh toán thành công!") : Result.Failure("Thêm mới thất bại.");
            }
            catch (Exception ex)
            {
                return Result.Failure("Lỗi hệ thống: " + ex.Message);
            }
        }

        // Update
        public Result Update(UpdatePaymentMethodDto dto)
        {
            var validationError = dto.Validate();
            if (!string.IsNullOrEmpty(validationError)) return Result.Failure(validationError);

            if (_dal.IsNameExists(dto.PaymentMethodName.Trim(), dto.PaymentMethodId))
                return Result.Failure("Tên phương thức thanh toán đã trùng với phương thức khác.");

            try
            {
                var entity = new PaymentMethod
                {
                    PaymentMethodId = dto.PaymentMethodId,
                    PaymentMethodName = dto.PaymentMethodName.Trim(),
                    Description = dto.Description?.Trim(),
                    IsCash = dto.IsCash,
                    Status = dto.Status
                };

                bool success = _dal.Update(entity);
                return success ? Result.Success("Cập nhật phương thức thanh toán thành công!") : Result.Failure("Cập nhật thất bại.");
            }
            catch (Exception ex)
            {
                return Result.Failure("Lỗi hệ thống: " + ex.Message);
            }
        }

        // Delete
        public Result Delete(int id)
        {
            if (id <= 0) return Result.Failure("Mã phương thức thanh toán không hợp lệ.");

            try
            {
                bool success = _dal.Delete(id);
                return success ? Result.Success("Xóa phương thức thanh toán thành công!") : Result.Failure("Không tìm thấy dữ liệu.");
            }
            catch
            {
                return Result.Failure("Không thể xóa phương thức thanh toán này do đã có hóa đơn liên kết.");
            }
        }
    }
}
