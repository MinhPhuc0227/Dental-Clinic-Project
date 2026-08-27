using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.DTO
{
    public class AccountDto
    {
        [DisplayName("Mã TK")]
        public int AccountId { get; set; }

        public int? DoctorId { get; set; }
        public int? ReceptionistId { get; set; }
        public string FullName { get; set; } = string.Empty;

        [DisplayName("Tên đăng nhập")]
        public string UserName { get; set; } = string.Empty;

        [Browsable(false)]
        public AccountRole Role { get; set; }

        [DisplayName("Vai trò")]
        public string RoleDisplay => Role switch
        {
            AccountRole.Admin => "Quản trị viên",
            AccountRole.Doctor => "Bác sĩ",
            AccountRole.Receptionist => "Lễ tân",
            _ => "Khác"
        };

        [Browsable(false)]
        public AccountStatus Status { get; set; }

        [DisplayName("Trạng thái")]
        public string StatusDisplay => Status switch
        {
            AccountStatus.Active => "Hoạt động",
            AccountStatus.Inactive => "Ngừng hoạt động",
            AccountStatus.Locked => "Đã khóa",
            _ => "Khác"
        };

        [DisplayName("Ngày tạo")]
        public DateTime CreatedAt { get; set; }
    }

    public class LoginRequestDto
    {
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập.")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        public string Password { get; set; } = string.Empty;
    }

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
