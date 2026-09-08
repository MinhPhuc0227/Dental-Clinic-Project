using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.MODEL
{
    public enum VisitStatus
    {
        Waiting, // Chờ khám
        InExamination, // Đang khám
        WaitingForPayment, // Chờ thanh toán
        Completed, // Đã hoàn thành 
        Cancelled // Đã hủy
    }

    public class Visit
    {
        public int VisitId { get; set; }
        public DateTime CheckInDateTime { get; set; }
        public string ReasonForVisit { get; set; } = string.Empty;
        public VisitStatus Status { get; set; } = VisitStatus.Waiting;
        public int QueueNumber { get; set; }
        public int? TreatmentSessionNumber { get; set; }

        // Foreign Key
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;

        public int ReceptionistId { get; set; }
        public Receptionist Receptionist { get; set; } = null!;

        public int? TreatmentId { get; set; } // Nullable
        public Treatment? Treatment { get; set; }

        public int? AppointmentId { get; set; } // Nullable
        public Appointment? Appointment { get; set; }

        // Navigation Property
        // Một lần khám có thể có hoặc không có bệnh án nào
        public MedicalRecord? MedicalRecord { get; set; }
        // Một lần khám có thể có nhiều hóa đơn, hoặc không có hóa đơn nào
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();  
    }
}
