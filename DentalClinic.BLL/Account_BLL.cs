using DentalClinic.BLL.Common;
using DentalClinic.DAL;
using DentalClinic.DTO;
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
        private readonly Account_DAL _dal;

        public Account_BLL(Account_DAL dal)
        {
            _dal = dal;
        }

        // GetAll
        public Result<List<AccountDto>> GetAll()
        {
            try
            {
                var list = _dal.GetAll();
                var dtoList = list.Select(a => new AccountDto
                {
                    AccountId = a.AccountId,
                    DoctorId = a.Doctor?.DoctorId,
                    ReceptionistId = a.Receptionist?.ReceptionistId,
                    FullName = a.Doctor?.FullName ?? a.Receptionist?.FullName ?? "",
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

        // UPDATE
        public Result Update(UpdateAccountDto dto, int currentAccountId)
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

            // Không cho tự khóa hoặc tự ngừng hoạt động tài khoản đang đăng nhập
            if (dto.AccountId == currentAccountId &&
                dto.Status != AccountStatus.Active)
            {
                return Result.Failure("Không thể khóa hoặc ngừng hoạt động tài khoản đang đăng nhập.");
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
                    Password = string.Empty,
                    Role = dto.Role,
                    Status = dto.Status
                };

                if (updatePassword)
                {
                    entity.Password = PasswordHelper.HashPassword(dto.Password.Trim());
                }

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

        // DELETE
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

        // CREATE ADMIN
        public Result CreateAdmin(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                return Result.Failure(
                    "Tên đăng nhập không được để trống.");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return Result.Failure(
                    "Mật khẩu không được để trống.");
            }

            userName = userName.Trim();
            password = password.Trim();

            if (userName.Length < 4 || userName.Length > 50)
            {
                return Result.Failure(
                    "Tên đăng nhập phải từ 4 đến 50 ký tự.");
            }

            if (password.Length < 6)
            {
                return Result.Failure(
                    "Mật khẩu phải có ít nhất 6 ký tự.");
            }

            if (_dal.IsUserNameExists(userName))
            {
                return Result.Failure(
                    "Tên đăng nhập này đã tồn tại.");
            }

            try
            {
                var account = new Account
                {
                    UserName = userName,
                    Password = PasswordHelper.HashPassword(password),
                    Role = AccountRole.Admin,
                    Status = AccountStatus.Active,
                    CreatedDate = DateTime.Now
                };

                bool success = _dal.Create(account);

                return success
                    ? Result.Success("Tạo tài khoản Admin thành công!")
                    : Result.Failure("Tạo tài khoản Admin thất bại.");
            }
            catch (Exception ex)
            {
                return Result.Failure(
                    "Lỗi hệ thống: " + ex.Message);
            }
        }

        // LOGIN
        public Result<AccountDto> Login(LoginRequestDto dto)
        {
            var validationError = dto.Validate();
            if (!string.IsNullOrEmpty(validationError))
                return Result<AccountDto>.Failure(validationError);

            var account = _dal.GetByUserName(dto.UserName.Trim());
            if (account == null || !PasswordHelper.VerifyPassword(dto.Password.Trim(), account.Password))
            {
                return Result<AccountDto>.Failure("Tên đăng nhập hoặc mật khẩu không chính xác.");
            }

            if (account.Status == AccountStatus.Locked)
            {
                return Result<AccountDto>.Failure("Tài khoản này hiện đang bị khóa.");
            }

            var accountDto = new AccountDto
            {
                AccountId = account.AccountId,
                DoctorId = account.Doctor?.DoctorId,
                ReceptionistId = account.Receptionist?.ReceptionistId,
                FullName = account.Doctor?.FullName ?? account.Receptionist?.FullName ?? account.UserName,
                UserName = account.UserName,
                Role = account.Role,
                Status = account.Status
            };

            return Result<AccountDto>.Success(accountDto, "Đăng nhập thành công!");
        }
    }
}
