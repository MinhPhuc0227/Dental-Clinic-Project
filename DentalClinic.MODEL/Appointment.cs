using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.MODEL
{
    public enum AppointmentStatus
    {
        Pending,
        Confirmed,
        Completed,
        Cancelled
    }
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDateTime { get; set; }

        public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;
        public string? Note { get; set; }
        public DateTime CreatedDate { get; set; }

        // Foreign Key
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;

        public int ReceptionistId { get; set; }
        public Receptionist Receptionist { get; set; } = null!;

        // Navigation Property
        public Visit? Visit { get; set; }
    }
}
