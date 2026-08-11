using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.DTO.Patient
{
    public class CreatePatientDto
    {
        // Patient information

        [Required(ErrorMessage = "Họ tên bệnh nhân không được để trống.")]
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
        public string? Email { get; set; }

        [StringLength(255, ErrorMessage = "Địa chỉ không vượt quá 255 ký tự.")]
        public string? Address { get; set; }

        [StringLength(500, ErrorMessage = "Ghi chú không vượt quá 500 ký tự.")]
        public string? Note { get; set; }


        // Account information (optional)
        public bool CreateAccount { get; set; } = true;

        [StringLength(50, MinimumLength = 4, ErrorMessage = "Tên đăng nhập phải từ 4 đến 50 ký tự.")]
        public string? UserName { get; set; }

        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 ký tự trở lên.")]
        public string? Password { get; set; }

        public AccountStatus Status { get; set; } = AccountStatus.Active;
    }
}
