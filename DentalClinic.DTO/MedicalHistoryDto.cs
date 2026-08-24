using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.DTO
{
    public class MedicalHistoryDto
    {
        public DateTime ExaminationDate { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public string Diagnosis { get; set; } = string.Empty;
        public string Conclusion { get; set; } = string.Empty;
    }
}
