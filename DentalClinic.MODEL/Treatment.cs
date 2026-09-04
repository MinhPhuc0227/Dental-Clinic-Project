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

    //public enum TreatmentPaymentStatus
    //{
    //    Unpaid,
    //    Paid
    //}

    public class Treatment
    {
        public int TreatmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? PlannedSessions { get; set; }
        public decimal TotalAmount { get; set; }
        //public TreatmentPaymentStatus PaymentStatus { get; set; } = TreatmentPaymentStatus.Unpaid;
        public TreatmentStatus Status { get; set; } = TreatmentStatus.InProgress;
        public string? Note { get; set; }

        // Foreign Key
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int ServiceId { get; set; }

        // Navigation Property
        public Patient Patient { get; set; } = null!;
        public Doctor Doctor { get; set; } = null!;
        public Service Service { get; set; } = null!;

        public ICollection<Visit> Visits { get; set; } = new List<Visit>();
    }
}
