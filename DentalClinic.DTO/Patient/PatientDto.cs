using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DentalClinic.DTO.Patient
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
}
