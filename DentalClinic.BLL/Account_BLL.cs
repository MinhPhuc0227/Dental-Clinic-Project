using DentalClinic.DAL;
using DentalClinic.DTO.Account;
using DentalClinic.DTO.Common;
using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.BLL
{
    public class Account_BLL
    {
        private readonly Account_DAL _dal = new Account_DAL();

        // GetAll
        public Result<List<AccountDto>> GetAll()
        {
            try
            {
                var list = _dal.GetAll();
                var dtoList = list.Select(a => new AccountDto
                {
                    AccountId = a.AccountId,
                    UserName = a.UserName,
                    Role = a.Role,
                    Status = a.Status,
                    CreatedAt = a.CreatedDate
                }).ToList();

                return Result<List<AccountDto>>.Success(dtoList);
            }
            catch (Exception ex)
            {
                return Result<List<AccountDto>>.Failure("Lỗi tải danh sách tài khoản: " + ex.Message);
            }
        }

        // Update
        public Result Update(UpdateAccountDto dto)
        {
            var validationError = dto.Validate();
            if (!string.IsNullOrEmpty(validationError))
            {
                return Result.Failure(validationError);
            }

            var currentAccount = _dal.GetById(dto.AccountId);

            if (currentAccount == null)
            {
                return Result.Failure("Tài khoản không tồn tại trên hệ thống.");
            }

            if (currentAccount.Role != dto.Role)
            {
                return Result.Failure("Không được phép thay đổi vai trò của tài khoản đã liên kết với hồ sơ nhân sự hoặc bệnh nhân.");
            }

            if (_dal.IsUserNameExists(dto.UserName.Trim(), dto.AccountId))
            {
                return Result.Failure("Tên đăng nhập này đã trùng với một tài khoản khác.");
            }

            bool updatePassword = !string.IsNullOrWhiteSpace(dto.Password);

            try
            {
                var entity = new Account
                {
                    AccountId = dto.AccountId,
                    UserName = dto.UserName.Trim(),
                    Password = dto.Password?.Trim() ?? string.Empty,
                    Role = dto.Role,
                    Status = dto.Status
                };

                bool success = _dal.Update(entity, updatePassword);
                return success
                    ? Result.Success("Cập nhật thông tin tài khoản thành công!")
                    : Result.Failure("Cập nhật thất bại.");
            }
            catch (Exception ex)
            {
                return Result.Failure("Lỗi hệ thống: " + ex.Message);
            }
        }

        // Delete
        public Result Delete(int accountId)
        {
            if (accountId <= 0)
            {
                return Result.Failure("Mã tài khoản không hợp lệ.");
            }

            try
            {
                bool success = _dal.Delete(accountId);
                return success
                    ? Result.Success("Xóa tài khoản thành công!")
                    : Result.Failure("Không tìm thấy tài khoản cần xóa.");
            }
            catch (Exception)
            {
                return Result.Failure("Không thể xóa do tài khoản này đang liên kết với hồ sơ Nhân viên / Bệnh nhân.");
            }
        }
    }
}
