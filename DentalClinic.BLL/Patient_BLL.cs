using DentalClinic.DAL;
using DentalClinic.DTO.Common;
using DentalClinic.DTO.Patient;
using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.BLL
{
    public class Patient_BLL
    {
        private readonly Patient_DAL _dal = new Patient_DAL();

        // GetAll
        public Result<List<PatientDto>> GetAll()
        {
            try
            {
                var list = _dal.GetAll();
                var dtoList = list.Select(p => new PatientDto
                {
                    PatientId = p.PatientId,
                    FullName = p.FullName,
                    Gender = p.Gender,
                    DateOfBirth = p.DateOfBirth,
                    Phone = p.Phone,
                    Email = p.Email,
                    Address = p.Address,
                    Note = p.Note,
                    AccountId = p.AccountId,
                    UserName = p.Account?.UserName ?? string.Empty,
                    Status = p.Account?.Status ?? AccountStatus.Active
                }).ToList();

                return Result<List<PatientDto>>.Success(dtoList);
            }
            catch (Exception ex)
            {
                return Result<List<PatientDto>>.Failure("Lỗi tải danh sách bệnh nhân: " + ex.Message);
            }
        }

        // Add
        public Result Add(CreatePatientDto dto)
        {
            var validationError = ValidateDto(dto);
            if (!string.IsNullOrEmpty(validationError)) return Result.Failure(validationError);

            if (_dal.IsPhoneExists(dto.Phone.Trim()))
                return Result.Failure("Số điện thoại này đang trùng với bệnh nhân khác.");

            Account? account = null;

            if (dto.CreateAccount)
            {
                string userName = string.IsNullOrWhiteSpace(dto.UserName) ? dto.Phone.Trim() : dto.UserName.Trim();
                if (_dal.IsUserNameExists(userName))
                    return Result.Failure("Tên đăng nhập đã tồn tại trong hệ thống.");

                string password = string.IsNullOrWhiteSpace(dto.Password) ? "123456" : dto.Password.Trim();

                account = new Account
                {
                    UserName = userName,
                    Password = password,
                    Role = AccountRole.Patient,
                    Status = dto.Status,
                    CreatedDate = DateTime.Now
                };
            }

            try
            {
                var patient = new Patient
                {
                    FullName = dto.FullName.Trim(),
                    Gender = dto.Gender,
                    DateOfBirth = dto.DateOfBirth,
                    Phone = dto.Phone.Trim(),
                    Email = dto.Email?.Trim(),
                    Address = dto.Address?.Trim(),
                    Note = dto.Note?.Trim()
                };

                bool success = _dal.AddWithAccount(account, patient);
                return success ? Result.Success("Thêm mới bệnh nhân thành công!") : Result.Failure("Thêm mới thất bại.");
            }
            catch (Exception ex)
            {
                return Result.Failure("Lỗi hệ thống: " + ex.Message);
            }
        }

        // Update
        public Result Update(UpdatePatientDto dto)
        {
            var validationError = ValidateDto(dto);
            if (!string.IsNullOrEmpty(validationError)) return Result.Failure(validationError);

            if (_dal.IsPhoneExists(dto.Phone.Trim(), dto.PatientId))
                return Result.Failure("Số điện thoại trùng với bệnh nhân khác.");

            if (dto.AccountId.HasValue && !string.IsNullOrWhiteSpace(dto.UserName))
            {
                if (_dal.IsUserNameExists(dto.UserName.Trim(), dto.AccountId.Value))
                    return Result.Failure("Tên đăng nhập trùng với tài khoản khác.");
            }

            bool hasNewPassword = !string.IsNullOrWhiteSpace(dto.Password);

            try
            {
                Account? account = null;
                if (dto.AccountId.HasValue)
                {
                    account = new Account
                    {
                        AccountId = dto.AccountId.Value,
                        UserName = dto.UserName?.Trim() ?? string.Empty,
                        Password = dto.Password?.Trim() ?? string.Empty,
                        Status = dto.Status
                    };
                }

                var patient = new Patient
                {
                    PatientId = dto.PatientId,
                    FullName = dto.FullName.Trim(),
                    Gender = dto.Gender,
                    DateOfBirth = dto.DateOfBirth,
                    Phone = dto.Phone.Trim(),
                    Email = dto.Email?.Trim(),
                    Address = dto.Address?.Trim(),
                    Note = dto.Note?.Trim(),
                    AccountId = dto.AccountId
                };

                bool success = _dal.UpdateWithAccount(patient, account, hasNewPassword);
                return success ? Result.Success("Cập nhật thông tin bệnh nhân thành công!") : Result.Failure("Cập nhật thất bại.");
            }
            catch (Exception ex)
            {
                return Result.Failure("Lỗi hệ thống: " + ex.Message);
            }
        }

        // Delete
        public Result Delete(int patientId)
        {
            if (patientId <= 0) return Result.Failure("Mã bệnh nhân không hợp lệ.");

            try
            {
                bool success = _dal.DeleteWithAccount(patientId);
                return success ? Result.Success("Xóa bệnh nhân thành công!") : Result.Failure("Không tìm thấy bệnh nhân.");
            }
            catch
            {
                return Result.Failure("Không thể xóa bệnh nhân đã có hồ sơ bệnh án hoặc hóa đơn điều trị.");
            }
        }

        // ValidateDto
        private string? ValidateDto(object dto)
        {
            var context = new ValidationContext(dto);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(dto, context, results, validateAllProperties: true))
                return results.FirstOrDefault()?.ErrorMessage;
            return null;
        }
    }
}
