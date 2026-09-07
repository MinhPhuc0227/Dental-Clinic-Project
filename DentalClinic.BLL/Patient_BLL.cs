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
        private readonly Patient_DAL _dal;

        public Patient_BLL(Patient_DAL dal)
        {
            _dal = dal;
        }

        // GetAll
        public Result<List<PatientDto>> GetAll()
        {
            try
            {
                var list = _dal.GetAll();
                var dtoList = list.Select(p => new PatientDto
                {
                    PatientId = p.PatientId,
                    //AccountId = p.AccountId,
                    FullName = p.FullName,
                    Gender = p.Gender,
                    DateOfBirth = p.DateOfBirth,
                    Phone = p.Phone,
                    Email = p.Email,
                    Address = p.Address,
                    Note = p.Note
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
            var validationError = dto.Validate();
            if (!string.IsNullOrEmpty(validationError)) return Result<int>.Failure(validationError);

            if (_dal.IsPhoneExists(dto.Phone.Trim()))
                return Result<int>.Failure("Số điện thoại này đang trùng với bệnh nhân khác.");

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

                bool success = _dal.Add(patient);

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
            var validationError = dto.Validate();
            if (!string.IsNullOrEmpty(validationError)) return Result.Failure(validationError);

            if (_dal.IsPhoneExists(dto.Phone.Trim(), dto.PatientId))
                return Result.Failure("Số điện thoại trùng với bệnh nhân khác.");

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
                    Note = dto.Note?.Trim()
                };

                bool success = _dal.Update(patient);
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
                bool success = _dal.Delete(patientId);
                return success ? Result.Success("Xóa bệnh nhân thành công!") : Result.Failure("Không tìm thấy bệnh nhân.");
            }
            catch
            {
                return Result.Failure("Không thể xóa bệnh nhân đã có hồ sơ bệnh án hoặc hóa đơn điều trị.");
            }
        }

        // Online
        public Result<PatientDto> GetById(int patientId)
        {
            if (patientId <= 0)
            {
                return Result<PatientDto>.Failure(
                    "Mã bệnh nhân không hợp lệ.");
            }

            try
            {
                var patient = _dal.GetById(patientId);

                if (patient == null)
                {
                    return Result<PatientDto>.Failure(
                        "Không tìm thấy bệnh nhân.");
                }

                var dto = new PatientDto
                {
                    PatientId = patient.PatientId,
                    FullName = patient.FullName,
                    Gender = patient.Gender,
                    DateOfBirth = patient.DateOfBirth,
                    Phone = patient.Phone,
                    Email = patient.Email,
                    Address = patient.Address,
                    Note = patient.Note
                    //AccountId = patient.AccountId
                };

                return Result<PatientDto>.Success(dto);
            }
            catch (Exception ex)
            {
                return Result<PatientDto>.Failure(
                    "Lỗi khi lấy thông tin bệnh nhân: " + ex.Message);
            }
        }
    }
}
