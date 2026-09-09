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
    public class Medicine_BLL
    {
        private readonly Medicine_DAL _dal;

        public Medicine_BLL(Medicine_DAL dal)
        {
            _dal = dal;
        }

        // GetAll
        public Result<List<MedicineDto>> GetAll(string keyword = "", MedicineStatus? status = null)
        {
            try
            {
                var list = _dal.GetAll(keyword, status);

                var dtoList = list
                    .Select(m => new MedicineDto
                    {
                        MedicineId = m.MedicineId,
                        MedicineName = m.MedicineName,
                        Unit = m.Unit,
                        UnitPrice = m.UnitPrice,
                        QuantityInStock = m.QuantityInStock,
                        Description = m.Description,
                        Status = m.Status
                    })
                    .ToList();

                return Result<List<MedicineDto>>.Success(dtoList);
            }
            catch (Exception ex)
            {
                return Result<List<MedicineDto>>
                    .Failure("Lỗi khi tải danh sách thuốc: " + ex.Message);
            }
        }

        // GetById
        public Result<MedicineDto> GetById(int medicineId)
        {
            if (medicineId <= 0)
            {
                return Result<MedicineDto>.Failure("Mã thuốc không hợp lệ.");
            }

            try
            {
                var medicine = _dal.GetById(medicineId);

                if (medicine == null)
                {
                    return Result<MedicineDto>.Failure("Không tìm thấy thuốc.");
                }

                var dto = new MedicineDto
                {
                    MedicineId = medicine.MedicineId,
                    MedicineName = medicine.MedicineName,
                    Unit = medicine.Unit,
                    UnitPrice = medicine.UnitPrice,
                    QuantityInStock = medicine.QuantityInStock,
                    Description = medicine.Description,
                    Status = medicine.Status
                };

                return Result<MedicineDto>.Success(dto);
            }
            catch (Exception ex)
            {
                return Result<MedicineDto>.Failure("Lỗi khi lấy thông tin thuốc: " + ex.Message);
            }
        }

        // ADD
        public Result Add(CreateMedicineDto dto)
        {
            var validationError = dto.Validate();
            if (!string.IsNullOrEmpty(validationError))
            {
                return Result.Failure(validationError);
            }

            if (_dal.IsNameExists(dto.MedicineName.Trim()))
            {
                return Result.Failure("Tên thuốc đã tồn tại trong hệ thống.");
            }

            try
            {
                var entity = new Medicine
                {
                    MedicineName = dto.MedicineName.Trim(),
                    Unit = dto.Unit.Trim(),
                    UnitPrice = dto.UnitPrice,
                    QuantityInStock = 0,
                    Description = dto.Description?.Trim(),
                    Status = dto.Status
                };

                bool isSuccess = _dal.Add(entity);
                return isSuccess
                    ? Result.Success("Thêm mới thuốc thành công!")
                    : Result.Failure("Thêm thuốc thất bại.");
            }
            catch (Exception ex)
            {
                return Result.Failure("Lỗi hệ thống: " + ex.Message);
            }
        }

        // UPDATE
        public Result Update(UpdateMedicineDto dto)
        {
            var validationError = dto.Validate();
            if (!string.IsNullOrEmpty(validationError))
            {
                return Result.Failure(validationError);
            }

            if (_dal.IsNameExists(dto.MedicineName.Trim(), dto.MedicineId))
            {
                return Result.Failure("Tên thuốc đã trùng với một loại thuốc khác.");
            }

            try
            {
                var entity = new Medicine
                {
                    MedicineId = dto.MedicineId,
                    MedicineName = dto.MedicineName.Trim(),
                    Unit = dto.Unit.Trim(),
                    UnitPrice = dto.UnitPrice,
                    Description = dto.Description?.Trim(),
                    Status = dto.Status
                };

                bool isSuccess = _dal.Update(entity);
                return isSuccess
                    ? Result.Success("Cập nhật thông tin thuốc thành công!")
                    : Result.Failure("Không tìm thấy thuốc hoặc cập nhật thất bại.");
            }
            catch (Exception ex)
            {
                return Result.Failure("Lỗi hệ thống: " + ex.Message);
            }
        }

        // DELETE
        public Result Delete(int medicineId)
        {
            if (medicineId <= 0)
            {
                return Result.Failure("Mã thuốc không hợp lệ.");
            }

            try
            {
                bool isSuccess = _dal.Delete(medicineId);
                return isSuccess
                    ? Result.Success("Xóa thuốc thành công!")
                    : Result.Failure("Không tìm thấy thuốc cần xóa.");
            }
            catch (Exception)
            {
                return Result.Failure("Không thể xóa do thuốc này đã xuất hiện trong đơn thuốc hoặc hóa đơn.");
            }
        }
    }
}
