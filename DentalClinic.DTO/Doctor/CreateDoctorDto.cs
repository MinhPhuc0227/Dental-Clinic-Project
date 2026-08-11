using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.DTO.Doctor
{
    public class CreateDoctorDto
    {
        // Doctor information
        [Required(ErrorMessage = "Họ tên bác sĩ không được để trống.")]
        [StringLength(100, ErrorMessage = "Họ tên không được vượt quá 100 ký tự.")]
        public string FullName { get; set; } = string.Empty;

        [EnumDataType(typeof(Gender), ErrorMessage = "Giới tính không hợp lệ.")]
        public Gender Gender { get; set; } = Gender.Male;

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


        // Account information
        [Required(ErrorMessage = "Tên đăng nhập không được để trống.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Tên đăng nhập phải từ 4 đến 50 ký tự.")]
        public string UserName { get; set; } = string.Empty;

        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 đến 100 ký tự.")]
        public string? Password { get; set; }

        [EnumDataType(typeof(AccountStatus), ErrorMessage = "Trạng thái không hợp lệ.")]
        public AccountStatus Status { get; set; } = AccountStatus.Active;
    }
}
