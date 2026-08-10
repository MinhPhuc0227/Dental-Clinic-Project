using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.MODEL
{
    public enum AccountRole
    {
        Admin,
        Doctor,
        Receptionist,
        Patient
    }

    public enum AccountStatus
    {
        Active,
        Inactive,
        Locked
    }
    public class Account
    {
        public int AccountId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public AccountRole Role { get; set; }
        public AccountStatus Status { get; set; } = AccountStatus.Active;
        public DateTime CreatedAt { get; set; }
    }
}
