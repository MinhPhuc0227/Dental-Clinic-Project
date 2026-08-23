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
        private readonly Medicine_DAL _dal = new Medicine_DAL();

        // 1. Lấy tất cả thuốc (Dùng Result<T> để trả về danh sách DTO)
        public Result<List<MedicineDto>> GetAll()
        {
            try
            {
                var list = _dal.GetAll();
                var dtoList = list.Select(m => new MedicineDto
                {
                    MedicineId = m.MedicineId,
                    MedicineName = m.MedicineName,
                    Unit = m.Unit,
                    UnitPrice = m.UnitPrice,
                    QuantityInStock = m.QuantityInStock,
                    Description = m.Description,
                    Status = m.Status
                }).ToList();

                return Result<List<MedicineDto>>.Success(dtoList);
            }
            catch (Exception ex)
            {
                return Result<List<MedicineDto>>.Failure("Lỗi khi tải danh sách thuốc: " + ex.Message);
            }
        }

        // 2. Thêm thuốc mới (Dùng Result không tham số data)
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
                    QuantityInStock = dto.QuantityInStock,
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

        // 3. Cập nhật thông tin thuốc
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
                    QuantityInStock = dto.QuantityInStock,
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

        // 4. Xóa thuốc
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
