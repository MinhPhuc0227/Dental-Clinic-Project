using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DentalClinic.DTO.Account
{
    public class AccountDto
    {
        [DisplayName("Mã TK")]
        public int AccountId { get; set; }

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
            AccountRole.Patient => "Bệnh nhân",
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
}
