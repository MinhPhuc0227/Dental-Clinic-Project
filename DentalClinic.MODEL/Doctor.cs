using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.MODEL
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ProfileImage { get; set; }

        // Foreign Key
        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;

        // Navigation Property cho Treatment
        public ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();
    }
}
