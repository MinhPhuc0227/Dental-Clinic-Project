using DentalClinic.DAL;
using DentalClinic.DTO;
using DentalClinic.DTO.Common;
using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace DentalClinic.BLL
{
    public class Supplier_BLL
    {
        private readonly Supplier_DAL _dal;

        public Supplier_BLL(Supplier_DAL dal)
        {
            _dal = dal;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        public Result<List<SupplierDto>> GetAll(
            string keyword = "",
            bool? isActive = null)
        {
            try
            {
                var list =
                    _dal.GetAll(keyword, isActive);

                var dtoList = list
                    .Select(s => new SupplierDto
                    {
                        SupplierId = s.SupplierId,
                        SupplierName = s.SupplierName,
                        Phone = s.Phone,
                        Address = s.Address,
                        Email = s.Email,
                        Note = s.Note,
                        IsActive = s.IsActive
                    })
                    .ToList();

                return Result<List<SupplierDto>>
                    .Success(dtoList);
            }
            catch (Exception ex)
            {
                return Result<List<SupplierDto>>
                    .Failure(
                        "Lỗi khi tải danh sách nhà cung cấp: " +
                        ex.Message);
            }
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        public Result<SupplierDto> GetById(int id)
        {
            if (id <= 0)
                return Result<SupplierDto>
                    .Failure(
                        "Mã nhà cung cấp không hợp lệ.");

            try
            {
                var supplier =
                    _dal.GetById(id);

                if (supplier == null)
                {
                    return Result<SupplierDto>
                        .Failure(
                            "Không tìm thấy nhà cung cấp.");
                }

                return Result<SupplierDto>.Success(
                    new SupplierDto
                    {
                        SupplierId =
                            supplier.SupplierId,

                        SupplierName =
                            supplier.SupplierName,

                        Phone =
                            supplier.Phone,

                        Address =
                            supplier.Address,

                        Email =
                            supplier.Email,

                        Note =
                            supplier.Note,

                        IsActive =
                            supplier.IsActive
                    });
            }
            catch (Exception ex)
            {
                return Result<SupplierDto>
                    .Failure(
                        "Lỗi khi lấy nhà cung cấp: " +
                        ex.Message);
            }
        }

        // =========================================================
        // CREATE
        // =========================================================

        public Result Create(SupplierCreateDto dto)
        {
            string? validationError = dto.Validate();

            if (!string.IsNullOrEmpty(validationError))
            {
                return Result.Failure(validationError);
            }

            string name = dto.SupplierName.Trim();

            if (_dal.IsNameExists(name))
            {
                return Result.Failure(
                    "Tên nhà cung cấp đã tồn tại.");
            }

            string? email = null;

            if (!string.IsNullOrWhiteSpace(dto.Email))
            {
                email = dto.Email.Trim();

                try
                {
                    var mail = new MailAddress(email);

                    if (mail.Address != email)
                    {
                        return Result.Failure(
                            "Email không hợp lệ.");
                    }
                }
                catch
                {
                    return Result.Failure(
                        "Email không hợp lệ.");
                }
            }

            try
            {
                var supplier = new Supplier
                {
                    SupplierName = name,
                    Phone = dto.Phone.Trim(),

                    Address = string.IsNullOrWhiteSpace(dto.Address)
        ? null
        : dto.Address.Trim(),

                    Email = email,

                    Note = string.IsNullOrWhiteSpace(dto.Note)
        ? null
        : dto.Note.Trim(),

                    IsActive = true
                };

                bool success = _dal.Add(supplier);

                return success
                    ? Result.Success(
                        "Thêm nhà cung cấp thành công!")
                    : Result.Failure(
                        "Thêm nhà cung cấp thất bại.");
            }
            catch (Exception ex)
            {
                return Result.Failure(
                    "Lỗi hệ thống: " +
                    (ex.InnerException?.Message ?? ex.Message));
            }
        }

        // =========================================================
        // UPDATE
        // =========================================================

        public Result Update(SupplierUpdateDto dto)
        {
            string? validationError = dto.Validate();

            if (!string.IsNullOrEmpty(validationError))
            {
                return Result.Failure(validationError);
            }

            if (dto.SupplierId <= 0)
            {
                return Result.Failure(
                    "Mã nhà cung cấp không hợp lệ.");
            }

            string name = dto.SupplierName.Trim();

            if (_dal.IsNameExists(
                name,
                dto.SupplierId))
            {
                return Result.Failure(
                    "Tên nhà cung cấp đã tồn tại.");
            }

            // Email không bắt buộc.
            // Chỉ kiểm tra khi người dùng có nhập.
            string? email = null;

            if (!string.IsNullOrWhiteSpace(dto.Email))
            {
                email = dto.Email.Trim();

                try
                {
                    var mail = new System.Net.Mail.MailAddress(email);

                    if (mail.Address != email)
                    {
                        return Result.Failure(
                            "Email không hợp lệ.");
                    }
                }
                catch
                {
                    return Result.Failure(
                        "Email không hợp lệ.");
                }
            }

            try
            {
                var supplier =
                    _dal.GetById(dto.SupplierId);

                if (supplier == null)
                {
                    return Result.Failure(
                        "Không tìm thấy nhà cung cấp.");
                }

                supplier.SupplierName = name;

                supplier.Phone =
                    dto.Phone.Trim();

                supplier.Address =
                    string.IsNullOrWhiteSpace(dto.Address)
                        ? null
                        : dto.Address.Trim();

                supplier.Email = email;

                supplier.Note =
                    string.IsNullOrWhiteSpace(dto.Note)
                        ? null
                        : dto.Note.Trim();

                supplier.IsActive =
                    dto.IsActive;

                bool success =
                    _dal.Update(supplier);

                return success
                    ? Result.Success(
                        "Cập nhật nhà cung cấp thành công!")
                    : Result.Failure(
                        "Cập nhật nhà cung cấp thất bại.");
            }
            catch (Exception ex)
            {
                return Result.Failure(
                    "Lỗi hệ thống: " +
                    (ex.InnerException?.Message ?? ex.Message));
            }
        }

        // =========================================================
        // DELETE
        // =========================================================

        public Result Delete(int supplierId)
        {
            if (supplierId <= 0)
            {
                return Result.Failure(
                    "Mã nhà cung cấp không hợp lệ.");
            }

            try
            {
                var supplier =
                    _dal.GetById(supplierId);

                if (supplier == null)
                {
                    return Result.Failure(
                        "Không tìm thấy nhà cung cấp.");
                }

                if (!supplier.IsActive)
                {
                    return Result.Failure(
                        "Nhà cung cấp này đã ngừng hoạt động.");
                }

                bool hasImportHistory =
                    _dal.HasImportHistory(
                        supplierId);

                bool success =
                    _dal.Delete(supplierId);

                if (!success)
                {
                    return Result.Failure(
                        "Không thể xóa nhà cung cấp.");
                }

                if (hasImportHistory)
                {
                    return Result.Success(
                        "Nhà cung cấp đã từng có phiếu nhập kho nên " +
                        "hệ thống đã chuyển sang trạng thái " +
                        "\"Ngừng hoạt động\" để bảo toàn lịch sử.");
                }

                return Result.Success(
                    "Xóa nhà cung cấp thành công.");
            }
            catch (Exception ex)
            {
                return Result.Failure(
                    "Lỗi khi xóa nhà cung cấp: " +
                    ex.Message);
            }
        }
    }
}
