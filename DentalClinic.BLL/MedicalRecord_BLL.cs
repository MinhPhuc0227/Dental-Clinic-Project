using DentalClinic.DAL;
using DentalClinic.DTO;
using DentalClinic.DTO.Common;
using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.BLL
{
    public class MedicalRecord_BLL
    {
        private readonly MedicalRecord_DAL _dal = new MedicalRecord_DAL();

        public Result SaveRecord(SaveMedicalRecordDto dto)
        {
            if (dto.VisitId <= 0)
            {
                return Result.Failure("Dữ liệu lượt khám không hợp lệ!");
            }

            // Kiểm tra hoàn thành khám thì bắt buộc phải có chẩn đoán
            if (!dto.IsDraft && string.IsNullOrWhiteSpace(dto.Diagnosis))
            {
                return Result.Failure("Chẩn đoán không được để trống khi hoàn thành khám.");
            }

            try
            {
                bool isSuccess = _dal.SaveRecordTransaction(dto);

                if (isSuccess)
                {
                    string message = dto.IsDraft ? "Lưu nháp hồ sơ thành công!" : "Hoàn thành khám bệnh thành công!";
                    return Result.Success(message);
                }
                else
                {
                    return Result.Failure("Không thể lưu hồ sơ vào cơ sở dữ liệu.");
                }
            }
            catch (Exception ex)
            {
                return Result.Failure("Lỗi hệ thống: " + ex.Message);
            }
        }
    }
}
