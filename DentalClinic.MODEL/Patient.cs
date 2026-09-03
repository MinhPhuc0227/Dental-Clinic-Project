using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.MODEL
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Note { get; set; }

        // Account dành cho bệnh nhân đăng nhập website
        public int? AccountId { get; set; }
        public virtual Account? Account { get; set; }
    }
}
