using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DentalClinic.DTO.Medicine
{
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
}