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
    public class Doctor_BLL
    {
        private readonly Doctor_DAL _dal;
        public Doctor_BLL(Doctor_DAL dal)
        {
            _dal = dal;
        }

        // GetAll
        public Result<List<DoctorDto>> GetAll(string keyword = "", AccountStatus? status = null)
        {
            try
            {
                var list = _dal.GetAll(keyword, status);

                var dtoList = list.Select(r => new DoctorDto
                {
                    DoctorId = r.DoctorId,
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

                return Result<List<DoctorDto>>.Success(dtoList);
            }
            catch (Exception ex)
            {
                return Result<List<DoctorDto>>.Failure("Lỗi tải danh sách lễ tân: " + ex.Message);
            }
        }

        // GetById
        public Result<DoctorDto> GetById(int doctorId)
        {
            try
            {
                var doctor = _dal.GetById(doctorId);

                if (doctor == null)
                {
                    return Result<DoctorDto>.Failure("Không tìm thấy hồ sơ bác sĩ.");
                }

                var dto = new DoctorDto
                {
                    DoctorId = doctor.DoctorId,
                    FullName = doctor.FullName,
                    Gender = doctor.Gender,
                    DateOfBirth = doctor.DateOfBirth,
                    Phone = doctor.Phone,
                    Email = doctor.Email,
                    Description = doctor.Description,

                    AccountId = doctor.AccountId,
                    UserName = doctor.Account?.UserName ?? string.Empty,
                    Status = doctor.Account?.Status ?? AccountStatus.Active,
                    CreatedAt = doctor.Account?.CreatedDate ?? DateTime.Now
                };

                return Result<DoctorDto>.Success(dto);
            }
            catch (Exception ex)
            {
                return Result<DoctorDto>.Failure("Lỗi tải hồ sơ bác sĩ: " + ex.Message);
            }
        }

        // GetDoctorByAccountId
        public Doctor? GetDoctorByAccountId(int accountId)
        {
            return _dal.GetDoctorByAccountId(accountId);
        }

        // ADD
        public Result Add(CreateDoctorDto dto)
        {
            var validationError = dto.Validate();
            if (!string.IsNullOrEmpty(validationError))
            {
                return Result.Failure(validationError);
            }

            if (string.IsNullOrWhiteSpace(dto.Password))
            {
                return Result.Failure("Mật khẩu không được để trống khi tạo mới tài khoản.");
            }

            if (_dal.IsPhoneExists(dto.Phone.Trim()))
            {
                return Result.Failure("Số điện thoại này đã được đăng ký trong hệ thống.");
            }

            if (_dal.IsUserNameExists(dto.UserName.Trim()))
            {
                return Result.Failure("Tên đăng nhập đã tồn tại trong hệ thống.");
            }

            try
            {
                var account = new Account
                {
                    UserName = dto.UserName.Trim(),
                    Password = PasswordHelper.HashPassword(dto.Password.Trim()),
                    Role = AccountRole.Doctor,
                    Status = dto.Status,
                    CreatedDate = DateTime.Now
                };

                var doctor = new Doctor
                {
                    FullName = dto.FullName.Trim(),
                    Gender = dto.Gender,
                    DateOfBirth = dto.DateOfBirth,
                    Phone = dto.Phone.Trim(),
                    Email = dto.Email?.Trim() ?? string.Empty,
                    Description = dto.Description?.Trim()
                };

                bool success = _dal.AddWithAccount(account, doctor);
                return success
                    ? Result.Success("Thêm mới bác sĩ và tài khoản thành công!")
                    : Result.Failure("Thêm mới thất bại.");
            }
            catch (Exception ex)
            {
                return Result.Failure("Lỗi hệ thống: " + ex.Message);
            }
        }

        // UPDATE
        public Result Update(UpdateDoctorDto dto)
        {
            var validationError = dto.Validate();

            if (!string.IsNullOrEmpty(validationError))
            {
                return Result.Failure(validationError);
            }

            if (_dal.IsPhoneExists(dto.Phone.Trim(), dto.DoctorId))
            {
                return Result.Failure("Số điện thoại này đã được đăng ký trong hệ thống.");
            }

            if (_dal.IsUserNameExists(dto.UserName.Trim(), dto.AccountId))
            {
                return Result.Failure("Tên đăng nhập bị trùng với tài khoản khác.");
            }

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
                    account.Password = PasswordHelper.HashPassword(dto.Password?.Trim() ?? string.Empty);
                }

                var doctor = new Doctor
                {
                    DoctorId = dto.DoctorId,
                    FullName = dto.FullName.Trim(),
                    Gender = dto.Gender,
                    DateOfBirth = dto.DateOfBirth,
                    Phone = dto.Phone.Trim(),
                    Email = dto.Email?.Trim() ?? string.Empty,
                    Description = dto.Description?.Trim()
                };

                bool success = _dal.UpdateWithAccount(doctor, account, hasNewPassword);
                return success ? Result.Success("Cập nhật thông tin bác sĩ thành công!") : Result.Failure("Cập nhật thất bại.");
            }
            catch (Exception ex)
            {
                return Result.Failure("Lỗi hệ thống: " + ex.Message);
            }
        }

        // DELETE
        public Result Delete(int doctorId)
        {
            if (doctorId <= 0)
            {
                return Result.Failure("Mã bác sĩ không hợp lệ.");
            }

            try
            {
                bool success = _dal.DeleteWithAccount(doctorId);
                return success ? Result.Success("Xóa bác sĩ và tài khoản liên quan thành công!") : Result.Failure("Không tìm thấy thông tin bác sĩ cần xóa.");
            }
            catch (Exception)
            {
                return Result.Failure("Không thể xóa bác sĩ này do đã phát sinh dữ liệu liên quan (lịch khám, hóa đơn).");
            }
        }
    }
}
