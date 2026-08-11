using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DentalClinic.DTO.Receptionist
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
}
