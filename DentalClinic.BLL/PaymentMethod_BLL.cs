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
    public class PaymentMethod_BLL
    {
        private readonly PaymentMethod_DAL _dal;
        public PaymentMethod_BLL(PaymentMethod_DAL dal)
        {
            _dal = dal;
        }

        // GetAll
        public Result<List<PaymentMethodDto>> GetAll(string keyword = "", PaymentMethodStatus? status = null)
        {
            try
            {
                var list = _dal.GetAll(keyword, status);

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

        // ADD
        public Result Add(CreatePaymentMethodDto dto)
        {
            // Xác thực dữ liệu bằng DataAnnotations (trong dto)
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

        // UPDATE
        public Result Update(UpdatePaymentMethodDto dto)
        {
            var validationError = dto.Validate();

            if (!string.IsNullOrEmpty(validationError)) 
                return Result.Failure(validationError);

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

        // DELETE
        public Result Delete(int id)
        {
            if (id <= 0) 
                return Result.Failure("Mã phương thức thanh toán không hợp lệ.");

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
