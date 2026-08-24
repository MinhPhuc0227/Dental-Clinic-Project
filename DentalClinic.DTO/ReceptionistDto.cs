using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.DTO
{
    public class ReceptionistDto
    {
        // Receptionist information
        [DisplayName("Mã Lễ tân")]
        public int ReceptionistId { get; set; }

        [DisplayName("Họ và tên")]
        public string FullName { get; set; } = string.Empty;

        [Browsable(false)]
        public Gender Gender { get; set; }

        [DisplayName("Giới tính")]
        public string GenderDisplay => Gender == Gender.Male ? "Nam" : (Gender == Gender.Female ? "Nữ" : "Khác");

        [DisplayName("Ngày sinh")]
        public DateOnly DateOfBirth { get; set; }

        [DisplayName("Điện thoại")]
        public string Phone { get; set; } = string.Empty;

        [DisplayName("Email")]
        public string Email { get; set; } = string.Empty;

        [DisplayName("Mô tả")]
        public string? Description { get; set; }

        // Account information

        [DisplayName("Mã TK")]
        public int AccountId { get; set; }

        [DisplayName("Tên đăng nhập")]
        public string UserName { get; set; } = string.Empty;

        [Browsable(false)]
        public AccountStatus Status { get; set; }

        [DisplayName("Trạng thái TK")]
        public string StatusDisplay => Status == AccountStatus.Active ? "Hoạt động" : (Status == AccountStatus.Inactive ? "Ngừng hoạt động" : "Khóa");

        [DisplayName("Ngày tạo TK")]
        public DateTime CreatedAt { get; set; }
    }

    public class BaseReceptionistDto
    {
        [Required(ErrorMessage = "Họ tên lễ tân không được để trống.")]
        [StringLength(100, ErrorMessage = "Họ tên không được vượt quá 100 ký tự.")]
        public string FullName { get; set; } = string.Empty;

        [EnumDataType(typeof(Gender), ErrorMessage = "Giới tính không hợp lệ.")]
        public Gender Gender { get; set; } = Gender.Female;

        [Required(ErrorMessage = "Ngày sinh không được để trống.")]
        public DateOnly DateOfBirth { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống.")]
        [Phone(ErrorMessage = "Số điện thoại không đúng định dạng.")]
        [StringLength(20, ErrorMessage = "Số điện thoại không được vượt quá 20 ký tự.")]
        public string Phone { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
        [StringLength(100, ErrorMessage = "Email không được vượt quá 100 ký tự.")]
        public string? Email { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được để trống.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Tên đăng nhập phải từ 4 đến 50 ký tự.")]
        public string UserName { get; set; } = string.Empty;

        [EnumDataType(typeof(AccountStatus), ErrorMessage = "Trạng thái không hợp lệ.")]
        public AccountStatus Status { get; set; } = AccountStatus.Active;
    }

    public class CreateReceptionistDto : BaseReceptionistDto
    {
        [Required(ErrorMessage = "Mật khẩu không được để trống khi tạo tài khoản.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 đến 100 ký tự.")]
        public string Password { get; set; } = string.Empty;
    }

    public class UpdateReceptionistDto : BaseReceptionistDto
    {
        [Required(ErrorMessage = "Mã lễ tân không hợp lệ.")]
        [Range(1, int.MaxValue, ErrorMessage = "Mã lễ tân phải lớn hơn 0.")]
        public int ReceptionistId { get; set; }

        [Required(ErrorMessage = "Mã tài khoản không hợp lệ.")]
        [Range(1, int.MaxValue, ErrorMessage = "Mã tài khoản phải lớn hơn 0.")]
        public int AccountId { get; set; }

        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu mới phải từ 6 đến 100 ký tự.")]
        public string? Password { get; set; }
    }
}
