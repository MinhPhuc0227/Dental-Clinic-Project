using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.MODEL
{
    public enum AccountRole
    {
        Admin,
        Doctor,
        Receptionist
    }

    public enum AccountStatus
    {
        Active, // Hoạt động
        Inactive, // Ngừng hoạt động
        Locked // Đã khóa
    }
    public class Account
    {
        public int AccountId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public AccountRole Role { get; set; }
        public AccountStatus Status { get; set; } = AccountStatus.Active;
        public DateTime CreatedDate { get; set; }

        // Navigation property
        public virtual Doctor? Doctor { get; set; }
        public virtual Receptionist? Receptionist { get; set; }
    }
}
