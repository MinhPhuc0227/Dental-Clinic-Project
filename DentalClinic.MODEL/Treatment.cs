using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.MODEL
{
    public enum TreatmentStatus
    {
        InProgress,
        Completed,
        Cancelled
    }

    public class Treatment
    {
        public int TreatmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? PlannedSessions { get; set; }
        public decimal TotalAmount { get; set; }
        public TreatmentStatus Status { get; set; } = TreatmentStatus.InProgress;
        public string? Note { get; set; }

        // Foreign Key
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;

        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;

        // Navigation Property
        // Một kế hoạch điều trị có thể có nhiều lần khám 
        public ICollection<Visit> Visits { get; set; } = new List<Visit>();
    }
}
