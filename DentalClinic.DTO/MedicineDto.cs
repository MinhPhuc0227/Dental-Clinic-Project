using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.DTO
{
    // Hiển thị danh sách thuốc (datagridview)
    public class MedicineDto
    {
        [DisplayName("Mã thuốc")]
        public int MedicineId { get; set; }

        [DisplayName("Tên thuốc")]
        public string MedicineName { get; set; } = string.Empty;

        [DisplayName("Đơn vị tính")]
        public string Unit { get; set; } = string.Empty;

        [DisplayName("Đơn giá")]
        public decimal UnitPrice { get; set; }

        [DisplayName("Số lượng tồn")]
        public int QuantityInStock { get; set; }

        [DisplayName("Mô tả")]
        public string? Description { get; set; }

        [Browsable(false)]
        public MedicineStatus Status { get; set; } = MedicineStatus.Active;

        [DisplayName("Trạng thái")]
        public string StatusDisplay => Status == MedicineStatus.Active ? "Hoạt động" : "Ngừng hoạt động";
    }

    // DTO dùng để tạo mới thuốc
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

        [StringLength(250, ErrorMessage = "Mô tả không được vượt quá 250 ký tự.")]
        public string? Description { get; set; }

        [EnumDataType(typeof(MedicineStatus), ErrorMessage = "Trạng thái không hợp lệ.")]
        public MedicineStatus Status { get; set; } = MedicineStatus.Active;
    }

    // DTO dùng để cập nhật thuốc
    public class UpdateMedicineDto : CreateMedicineDto
    {
        [Required(ErrorMessage = "Mã thuốc không hợp lệ.")]
        [Range(1, int.MaxValue)]
        public int MedicineId { get; set; }
    }

    // DTO dùng để hiển thị chi tiết thuốc (PrescriptionDetail) trong đơn thuốc (Prescription)
    public class SelectedMedicineDto
    {
        public int MedicineId { get; set; }
        public string MedicineName { get; set; } = string.Empty;
        public int Morning { get; set; }
        public int Noon { get; set; }
        public int Afternoon { get; set; }
        public int Evening { get; set; }
        public int Days { get; set; }
        public string Instruction { get; set; } = string.Empty;
        public int Quantity => (Morning + Noon + Afternoon + Evening) * Days;
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
