using DentalClinic.MODEL;
using System;

namespace DentalClinic.DTO
{
    public class PatientHistoryDto
    {
        public int MedicalRecordId { get; set; }
        public int VisitId { get; set; }
        public DateTime ExaminationDate { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public VisitStatus VisitStatus { get; set; }
        public string Diagnosis { get; set; } = string.Empty;
        public string Conclusion { get; set; } = string.Empty;
        public string? Note { get; set; }
    }
}