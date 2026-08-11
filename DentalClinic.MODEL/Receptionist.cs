using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.MODEL
{
    public class Receptionist
    {
        public int ReceptionistId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Description { get; set; }

        // Foreign Key
        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;
    }
}
