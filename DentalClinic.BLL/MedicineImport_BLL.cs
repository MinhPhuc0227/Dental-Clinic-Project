using DentalClinic.DAL;
using DentalClinic.DTO;
using DentalClinic.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DentalClinic.BLL
{
    public class MedicineImport_BLL
    {
        private readonly MedicineImport_DAL _dal;

        public MedicineImport_BLL(MedicineImport_DAL dal)
        {
            _dal = dal;
        }

        // CREATE
        public Result Create(CreateMedicineImportDto dto)
        {
            string? validationError = dto.Validate();

            if (!string.IsNullOrEmpty(validationError))
            {
                return Result.Failure(validationError);
            }

            foreach (var item in dto.Items)
            {
                string? itemError = item.Validate();

                if (!string.IsNullOrEmpty(itemError))
                {
                    return Result.Failure($"Thuốc \"{item.MedicineName}\": {itemError}");
                }
            }

            if (dto.ImportDate > DateTime.Now)
            {
                return Result.Failure("Ngày nhập không được lớn hơn thời gian hiện tại.");
            }

            try
            {
                bool success = _dal.CreateImport(dto);

                return success
                    ? Result.Success("Nhập kho thuốc thành công!")
                    : Result.Failure("Không thể tạo phiếu nhập.");
            }
            catch (Exception ex)
            {
                return Result.Failure("Lỗi nhập kho: " + (ex.InnerException?.Message ?? ex.Message));
            }
        }

        // GETHISTORY
        public Result<List<MedicineImportListDto>> GetHistory(
            DateTime fromDate,
            DateTime toDate,
            int? supplierId,
            string keyword)
        {
            if (fromDate.Date > toDate.Date)
            {
                return Result<List<MedicineImportListDto>>.Failure("Ngày bắt đầu không được lớn hơn ngày kết thúc.");
            }

            try
            {
                var data = _dal.GetHistory(fromDate, toDate, supplierId, keyword);

                return Result<List<MedicineImportListDto>>.Success(data);
            }
            catch (Exception ex)
            {
                return Result<List<MedicineImportListDto>>.Failure("Lỗi tải lịch sử nhập kho: " + ex.Message);
            }
        }

        // GETDETAIL
        public Result<MedicineImportDetailDto> GetDetail(int importId)
        {
            if (importId <= 0)
            {
                return Result<MedicineImportDetailDto>.Failure("Mã phiếu nhập không hợp lệ.");
            }

            try
            {
                var data = _dal.GetDetail(importId);

                if (data == null)
                {
                    return Result<MedicineImportDetailDto>.Failure("Không tìm thấy phiếu nhập.");
                }

                return Result<MedicineImportDetailDto>.Success(data);
            }
            catch (Exception ex)
            {
                return Result<MedicineImportDetailDto>.Failure("Lỗi tải chi tiết phiếu nhập: " + ex.Message);
            }
        }
    }
}