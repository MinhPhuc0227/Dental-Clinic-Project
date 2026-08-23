using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.DTO
{
    public class PatientDto
    {
        // Patient information

        [DisplayName("Mã BN")]
        public int PatientId { get; set; }

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
        public string? Email { get; set; }

        [DisplayName("Địa chỉ")]
        public string? Address { get; set; }

        [DisplayName("Ghi chú")]
        public string? Note { get; set; }


        // Account information

        [DisplayName("Mã TK")]
        public int? AccountId { get; set; }

        [DisplayName("Tên đăng nhập")]
        public string UserName { get; set; } = string.Empty;

        [Browsable(false)]
        public AccountStatus Status { get; set; }

        [DisplayName("Trạng thái TK")]
        public string StatusDisplay => AccountId == null ? "Không dùng TK" : (Status == AccountStatus.Active ? "Hoạt động" : "Khóa");
    }

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

        private string? _email;

        [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
        [StringLength(100, ErrorMessage = "Email không được vượt quá 100 ký tự.")]
        public string? Email
        {
            get => _email;
            set => _email = string.IsNullOrWhiteSpace(value) ? null : value.Trim();
        }

        [StringLength(255, ErrorMessage = "Địa chỉ không vượt quá 255 ký tự.")]
        public string? Address { get; set; }

        [StringLength(500, ErrorMessage = "Ghi chú không vượt quá 500 ký tự.")]
        public string? Note { get; set; }


        // Account information (optional)
        public bool CreateAccount { get; set; } = true;

        [StringLength(50, MinimumLength = 4, ErrorMessage = "Tên đăng nhập phải từ 4 đến 50 ký tự.")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống khi tạo tài khoản.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 đến 100 ký tự.")]
        public string Password { get; set; } = string.Empty;

        public AccountStatus Status { get; set; } = AccountStatus.Active;
    }

    public class UpdatePatientDto : CreatePatientDto
    {
        // Patient information
        [Required(ErrorMessage = "Mã bệnh nhân không hợp lệ.")]
        [Range(1, int.MaxValue, ErrorMessage = "Mã bệnh nhân phải lớn hơn 0.")]
        public int PatientId { get; set; }

        // Account information (optional)
        public int? AccountId { get; set; }

        // Password nullable (update or not)
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu mới phải từ 6 đến 100 ký tự.")]
        public new string? Password { get; set; }
    }
}
