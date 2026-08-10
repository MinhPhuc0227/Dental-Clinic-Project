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

        // 1. Get all
        public Result<List<PaymentMethodDto>> GetAll()
        {
            try
            {
                var entities = _dal.GetAll();
                var dtoList = entities.Select(p => new PaymentMethodDto
                {
                    PaymentMethodId = p.PaymentMethodId,
                    PaymentMethodName = p.PaymentMethodName,
                    Description = p.Description,
                    IsCash = p.IsCash,
                    Status = p.Status
                }).ToList();

                return Result<List<PaymentMethodDto>>.Success(dtoList);
            }
            catch (Exception ex)
            {
                return Result<List<PaymentMethodDto>>.Failure($"Lỗi khi lấy dữ liệu: {ex.Message}");
            }
        }

        // 2. Add
        public Result Add(CreatePaymentMethodDto dto)
        {
            var validateResult = ValidateDto(dto);
            if (!validateResult.IsSuccess) return validateResult;

            // Check duplicate payment method name
            bool isDuplicate = _dal.GetAll().Any(p => p.PaymentMethodName.Trim()
                .Equals(dto.PaymentMethodName.Trim(), StringComparison.OrdinalIgnoreCase));

            if (isDuplicate)
            {
                return Result.Failure("Tên phương thức thanh toán đã tồn tại.");
            }

            try
            {
                var entity = new PaymentMethod
                {
                    PaymentMethodName = dto.PaymentMethodName.Trim(),
                    Description = dto.Description?.Trim(),
                    IsCash = dto.IsCash,
                    Status = dto.Status
                };

                _dal.Add(entity);
                return Result.Success("Thêm phương thức thanh toán thành công.");
            }
            catch (Exception ex)
            {
                return Result.Failure($"Lỗi hệ thống khi thêm: {ex.Message}");
            }
        }

        // 3. Update
        public Result Update(UpdatePaymentMethodDto dto)
        {
            var validateResult = ValidateDto(dto);
            if (!validateResult.IsSuccess) return validateResult;

            // Check duplicate payment method name
            bool isDuplicate = _dal.GetAll().Any(p => p.PaymentMethodId != dto.PaymentMethodId &&
                                                      p.PaymentMethodName.Trim().Equals(dto.PaymentMethodName.Trim(), StringComparison.OrdinalIgnoreCase));
            if (isDuplicate)
            {
                return Result.Failure("Tên phương thức thanh toán đã trùng với một phương thức khác.");
            }

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

                bool isUpdated = _dal.Update(entity);
                if (!isUpdated) return Result.Failure("Không tìm thấy phương thức thanh toán để cập nhật.");

                return Result.Success("Cập nhật phương thức thanh toán thành công.");
            }
            catch (Exception ex)
            {
                return Result.Failure($"Lỗi hệ thống khi cập nhật: {ex.Message}");
            }
        }

        // 4. Delete
        public Result Delete(int paymentMethodId)
        {
            try
            {
                // Check invoice constraints
                if (_dal.HasAssociatedInvoices(paymentMethodId))
                {
                    return Result.Failure("Không thể xóa phương thức này vì đã có hóa đơn liên kết.");
                }

                bool isDeleted = _dal.Delete(paymentMethodId);
                if (!isDeleted) return Result.Failure("Phương thức thanh toán không tồn tại hoặc đã bị xóa.");

                return Result.Success("Xóa phương thức thanh toán thành công.");
            }
            catch (Exception ex)
            {
                return Result.Failure($"Lỗi hệ thống khi xóa: {ex.Message}");
            }
        }

        // Function for validating DataAnnotations (in DTOs)
        private Result ValidateDto(object dto)
        {
            var context = new ValidationContext(dto);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(dto, context, results, true))
            {
                var errorMessage = results.FirstOrDefault()?.ErrorMessage ?? "Dữ liệu không hợp lệ.";
                return Result.Failure(errorMessage);
            }
            return Result.Success("Hợp lệ.");
        }
    }
}
