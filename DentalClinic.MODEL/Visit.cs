using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.MODEL
{
    public enum VisitStatus
    {
        Waiting, // Chờ khám
        InExamination, // Đang khám
        WaitingForPayment, // Đã khám xong, chờ thanh toán
        Completed, // Đã hoàn thành (đã thanh toán)
        Cancelled // Đã hủy
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

        public int ReceptionistId { get; set; }
        public Receptionist Receptionist { get; set; } = null!;

        // Navigation Property
        public MedicalRecord? MedicalRecord { get; set; }
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

        // For Treatment 
        public int? TreatmentId { get; set; }
        public Treatment? Treatment { get; set; }

        public int? TreatmentSessionNumber { get; set; }
    }
}
