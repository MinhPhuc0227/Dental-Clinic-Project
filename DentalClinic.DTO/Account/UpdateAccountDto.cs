using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.DTO.Account
{
    // Use for status updating, password resetting, role changing
    public class UpdateAccountDto
    {
        [Required(ErrorMessage = "Mã tài khoản không hợp lệ.")]
        [Range(1, int.MaxValue, ErrorMessage = "Mã tài khoản phải lớn hơn 0.")]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được để trống.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Tên đăng nhập phải từ 4 đến 50 ký tự.")]
        public string UserName { get; set; } = string.Empty;

        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu mới phải từ 6 ký tự trở lên.")]
        public string? Password { get; set; } // Null if dont need to change password

        [EnumDataType(typeof(AccountRole), ErrorMessage = "Vai trò không hợp lệ.")]
        public AccountRole Role { get; set; }

        [EnumDataType(typeof(AccountStatus), ErrorMessage = "Trạng thái không hợp lệ.")]
        public AccountStatus Status { get; set; }
    }
}
