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
    public class Receptionist_BLL
    {
        private readonly Receptionist_DAL _dal;

        public Receptionist_BLL(Receptionist_DAL dal)
        {
            _dal = dal;
        }

        // GetAll
        public Result<List<ReceptionistDto>> GetAll()
        {
            try
            {
                var list = _dal.GetAll();
                var dtoList = list.Select(r => new ReceptionistDto
                {
                    ReceptionistId = r.ReceptionistId,
                    FullName = r.FullName,
                    Gender = r.Gender,
                    DateOfBirth = r.DateOfBirth,
                    Phone = r.Phone,
                    Email = r.Email,
                    Description = r.Description,
                    AccountId = r.AccountId,
                    UserName = r.Account?.UserName ?? string.Empty,
                    Status = r.Account?.Status ?? AccountStatus.Active,
                    CreatedAt = r.Account?.CreatedDate ?? DateTime.Now
                }).ToList();

                return Result<List<ReceptionistDto>>.Success(dtoList);
            }
            catch (Exception ex)
            {
                return Result<List<ReceptionistDto>>.Failure("Lỗi tải danh sách lễ tân: " + ex.Message);
            }
        }

        public Result<ReceptionistDto> GetById(int receptionistId)
        {
            try
            {
                var receptionist = _dal.GetById(receptionistId);

                if (receptionist == null)
                {
                    return Result<ReceptionistDto>.Failure(
                        "Không tìm thấy hồ sơ lễ tân.");
                }

                var dto = new ReceptionistDto
                {
                    ReceptionistId = receptionist.ReceptionistId,
                    FullName = receptionist.FullName,
                    Gender = receptionist.Gender,
                    DateOfBirth = receptionist.DateOfBirth,
                    Phone = receptionist.Phone,
                    Email = receptionist.Email,
                    Description = receptionist.Description,

                    AccountId = receptionist.AccountId,
                    UserName = receptionist.Account?.UserName ?? string.Empty,
                    Status = receptionist.Account?.Status ?? AccountStatus.Active,
                    CreatedAt = receptionist.Account?.CreatedDate ?? DateTime.Now
                };

                return Result<ReceptionistDto>.Success(dto);
            }
            catch (Exception ex)
            {
                return Result<ReceptionistDto>.Failure(
                    "Lỗi tải hồ sơ lễ tân: " + ex.Message);
            }
        }

        public Receptionist? GetReceptionistByAccountId(int accountId)
        {
            return _dal.GetReceptionistByAccountId(accountId);
        }

        // Add
        public Result Add(CreateReceptionistDto dto)
        {
            var validationError = dto.Validate();
            if (!string.IsNullOrEmpty(validationError)) return Result.Failure(validationError);

            if (string.IsNullOrWhiteSpace(dto.Password))
                return Result.Failure("Mật khẩu không được để trống khi tạo mới tài khoản.");

            if (_dal.IsPhoneExists(dto.Phone.Trim()))
                return Result.Failure("Số điện thoại này đã được đăng ký trong hệ thống.");

            if (_dal.IsUserNameExists(dto.UserName.Trim()))
                return Result.Failure("Tên đăng nhập đã tồn tại trong hệ thống.");

            try
            {
                var account = new Account
                {
                    UserName = dto.UserName.Trim(),
                    Password = PasswordHelper.HashPassword(dto.Password.Trim()),
                    Role = AccountRole.Receptionist,
                    Status = dto.Status,
                    CreatedDate = DateTime.Now
                };

                var receptionist = new Receptionist
                {
                    FullName = dto.FullName.Trim(),
                    Gender = dto.Gender,
                    DateOfBirth = dto.DateOfBirth,
                    Phone = dto.Phone.Trim(),
                    Email = dto.Email?.Trim() ?? string.Empty,
                    Description = dto.Description?.Trim()
                };

                bool success = _dal.AddWithAccount(account, receptionist);
                return success ? Result.Success("Thêm mới lễ tân thành công!") : Result.Failure("Thêm mới thất bại.");
            }
            catch (Exception ex)
            {
                return Result.Failure("Lỗi hệ thống: " + ex.Message);
            }
        }

        // Update
        public Result Update(UpdateReceptionistDto dto)
        {
            var validationError = dto.Validate();
            if (!string.IsNullOrEmpty(validationError)) return Result.Failure(validationError);

            if (_dal.IsPhoneExists(dto.Phone.Trim(), dto.ReceptionistId))
                return Result.Failure("Số điện thoại này đã được đăng ký trong hệ thống.");

            if (_dal.IsUserNameExists(dto.UserName.Trim(), dto.AccountId))
                return Result.Failure("Tên đăng nhập bị trùng với tài khoản khác.");

            bool hasNewPassword = !string.IsNullOrWhiteSpace(dto.Password);

            try
            {
                var account = new Account
                {
                    AccountId = dto.AccountId,
                    UserName = dto.UserName.Trim(),
                    Password = string.Empty,
                    Status = dto.Status
                };

                if (hasNewPassword)
                {
                    account.Password = PasswordHelper.HashPassword(dto.Password.Trim());
                }

                var receptionist = new Receptionist
                {
                    ReceptionistId = dto.ReceptionistId,
                    FullName = dto.FullName.Trim(),
                    Gender = dto.Gender,
                    DateOfBirth = dto.DateOfBirth,
                    Phone = dto.Phone.Trim(),
                    Email = dto.Email?.Trim() ?? string.Empty,
                    Description = dto.Description?.Trim()
                };

                bool success = _dal.UpdateWithAccount(receptionist, account, hasNewPassword);
                return success ? Result.Success("Cập nhật thông tin lễ tân thành công!") : Result.Failure("Cập nhật thất bại.");
            }
            catch (Exception ex)
            {
                return Result.Failure("Lỗi hệ thống: " + ex.Message);
            }
        }

        // Delete
        public Result Delete(int receptionistId)
        {
            if (receptionistId <= 0) return Result.Failure("Mã lễ tân không hợp lệ.");

            try
            {
                bool success = _dal.DeleteWithAccount(receptionistId);
                return success ? Result.Success("Xóa lễ tân thành công!") : Result.Failure("Không tìm thấy dữ liệu.");
            }
            catch
            {
                return Result.Failure("Không thể xóa lễ tân này do đã có dữ liệu giao dịch/tiếp nhận liên quan.");
            }
        }
    }
}
