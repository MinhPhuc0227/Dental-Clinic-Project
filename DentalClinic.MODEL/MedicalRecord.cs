using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.MODEL
{
    public class MedicalRecord
    {
        public int MedicalRecordId { get; set; }
        public DateTime ExaminationDateTime { get; set; }
        public string Diagnosis { get; set; } = string.Empty;
        public string Conclusion { get; set; } = string.Empty;

        // Foreign Key
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; } = null!;

        // Navigation Property (MedicalRecord 1-1 Prescription) 
        public Prescription? Prescription { get; set; }

        // Navigation Property (MedicalRecord 1-N MedicalRecordService)
        public ICollection<MedicalRecordService> MedicalRecordServices { get; set; } = new List<MedicalRecordService>();
    }
}
