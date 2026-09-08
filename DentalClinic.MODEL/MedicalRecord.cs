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
        public string? Note { get; set; }

        // Foreign Key
        public int VisitId { get; set; }
        public Visit Visit { get; set; } = null!;

        // Navigation Property 
        // Bệnh án có thể có hoặc không có đơn thuốc 
        public Prescription? Prescription { get; set; }
        // Bệnh án có thể có nhiều dịch vụ khám chữa bệnh
        public ICollection<MedicalRecordService> MedicalRecordServices { get; set; } = new List<MedicalRecordService>();
    }
}
