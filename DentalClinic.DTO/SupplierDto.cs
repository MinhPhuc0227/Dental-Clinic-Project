using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.DTO
{
    public class SupplierDto
    {
        [DisplayName("Mã")]
        public int SupplierId { get; set; }

        [DisplayName("Nhà cung cấp")]
        public string SupplierName { get; set; } = string.Empty;

        [DisplayName("SĐT")]
        public string? Phone { get; set; }

        [DisplayName("Địa chỉ")]
        public string? Address { get; set; }

        [DisplayName("Email")]
        public string? Email { get; set; }

        [DisplayName("Ghi chú")]
        public string? Note { get; set; }

        [Browsable(false)]
        public bool IsActive { get; set; }

        [DisplayName("Trạng thái")]
        public string StatusText => IsActive ? "Đang hoạt động" : "Ngừng hoạt động";
    }

    // DTO tạo mới nhà cung cấp
    public class SupplierCreateDto
    {
        [Required(ErrorMessage = "Tên nhà cung cấp không được để trống.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Tên nhà cung cấp phải từ 2 đến 200 ký tự.")]
        public string SupplierName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Số điện thoại không được để trống.")]
        [StringLength(20, ErrorMessage = "Số điện thoại không được vượt quá 20 ký tự.")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ.")]
        public string Phone { get; set; } = string.Empty;

        [StringLength(300, ErrorMessage = "Địa chỉ không được vượt quá 300 ký tự.")]
        public string? Address { get; set; }

      
        [StringLength(150, ErrorMessage = "Email không được vượt quá 150 ký tự.")]
        public string? Email { get; set; }

        [StringLength(500, ErrorMessage = "Ghi chú không được vượt quá 500 ký tự.")]
        public string? Note { get; set; }
    }

    // DTO cập nhật nhà cung cấp
    public class SupplierUpdateDto : SupplierCreateDto
    {
        public int SupplierId { get; set; }
        public bool IsActive { get; set; }
    }
}
