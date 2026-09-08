using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.DTO
{
    public class SupplierDto
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Note { get; set; }
        public bool IsActive { get; set; }
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
