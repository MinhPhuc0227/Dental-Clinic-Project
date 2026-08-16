using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.MODEL
{
    public enum VisitStatus
    {
        Waiting,
        InExamination,
        Completed,
        Cancelled
    }

    public class Visit
    {
        public int VisitId { get; set; }
        public DateTime CheckInDateTime { get; set; }
        public string ReasonForVisit { get; set; } = string.Empty;
        public VisitStatus Status { get; set; } = VisitStatus.Waiting;
        public int QueueNumber { get; set; }

        // Foreign Key
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;

        public int? AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;

        // Navigation Property
        public MedicalRecord? MedicalRecord { get; set; }
        public Invoice? Invoice { get; set; }
    }
}
