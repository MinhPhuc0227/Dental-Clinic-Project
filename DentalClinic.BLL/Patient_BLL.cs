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
        public Result<int> Add(CreatePatientDto dto)
        {
            // When no need account for patient (avoid dto error message)
            if (!dto.CreateAccount)
            {
                dto.UserName = null;
                dto.Password = null;
            }

            var validationError = dto.Validate();
            if (!string.IsNullOrEmpty(validationError)) return Result<int>.Failure(validationError);

            if (_dal.IsPhoneExists(dto.Phone.Trim()))
                return Result<int>.Failure("Số điện thoại này đang trùng với bệnh nhân khác.");

            Account? account = null;

            if (dto.CreateAccount)
            {
                string userName = string.IsNullOrWhiteSpace(dto.UserName) ? dto.Phone.Trim() : dto.UserName.Trim();
                if (_dal.IsUserNameExists(userName))
                    return Result<int>.Failure("Tên đăng nhập đã tồn tại trong hệ thống.");

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

                return success
                    ? Result<int>.Success(patient.PatientId, "Thêm mới bệnh nhân thành công!")
                    : Result<int>.Failure("Thêm mới thất bại.");
            }
            catch (Exception ex)
            {
                return Result<int>.Failure("Lỗi hệ thống: " + ex.Message);
            }
        }

        // Update
        public Result Update(UpdatePatientDto dto)
        {
            if (!dto.AccountId.HasValue && !dto.CreateAccount)
            {
                dto.UserName = null;
                dto.Password = null;
            }

            var validationError = dto.Validate();
            if (!string.IsNullOrEmpty(validationError)) return Result.Failure(validationError);

            if (_dal.IsPhoneExists(dto.Phone.Trim(), dto.PatientId))
                return Result.Failure("Số điện thoại trùng với bệnh nhân khác.");

            Account? account = null;
            bool hasNewPassword = false;

            // Case 1: no account yet and tick "Create account" checkbox
            if (!dto.AccountId.HasValue && dto.CreateAccount)
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
            // Case 2: already hava an account -> update existing account
            else if (dto.AccountId.HasValue)
            {
                if (!string.IsNullOrWhiteSpace(dto.UserName) && _dal.IsUserNameExists(dto.UserName.Trim(), dto.AccountId.Value))
                    return Result.Failure("Tên đăng nhập trùng với tài khoản khác.");

                hasNewPassword = !string.IsNullOrWhiteSpace(dto.Password);

                account = new Account
                {
                    AccountId = dto.AccountId.Value,
                    UserName = dto.UserName?.Trim() ?? string.Empty,
                    Password = dto.Password?.Trim() ?? string.Empty,
                    Status = dto.Status
                };
            }

            try
            {
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
    }
}
