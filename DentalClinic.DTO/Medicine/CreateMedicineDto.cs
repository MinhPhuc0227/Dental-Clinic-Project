using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.DTO.Medicine
{
    public class CreateMedicineDto
    {
        [Required(ErrorMessage = "Tên thuốc không được để trống.")]
        [StringLength(100, ErrorMessage = "Tên thuốc không được vượt quá 100 ký tự.")]
        public string MedicineName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Đơn vị tính không được để trống.")]
        [StringLength(20, ErrorMessage = "Đơn vị tính không được vượt quá 20 ký tự.")]
        public string Unit { get; set; } = string.Empty;

        [Required(ErrorMessage = "Đơn giá không được để trống.")]
        [Range(0, 999_999_999, ErrorMessage = "Đơn giá phải lớn hơn hoặc bằng 0.")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Số lượng tồn không được để trống.")]
        [Range(0, 100_000, ErrorMessage = "Số lượng tồn phải lớn hơn hoặc bằng 0.")]
        public int QuantityInStock { get; set; } = 0;

        [StringLength(250, ErrorMessage = "Mô tả không được vượt quá 250 ký tự.")]
        public string? Description { get; set; }

        [EnumDataType(typeof(MedicineStatus), ErrorMessage = "Trạng thái không hợp lệ.")]
        public MedicineStatus Status { get; set; } = MedicineStatus.Active;
    }
}
