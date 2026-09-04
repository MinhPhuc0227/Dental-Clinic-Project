using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.DTO
{
    public class SaveMedicalRecordDto
    {
        public int MedicalRecordId { get; set; }
        public int VisitId { get; set; }
        public int DoctorId { get; set; }
        public string Diagnosis { get; set; } = string.Empty;
        public string Conclusion { get; set; } = string.Empty;
        public string? Note { get; set; }
        public bool IsDraft { get; set; }

        // Chứa danh sách dịch vụ và thuốc bác sĩ đã kê
        public List<SelectedServiceDto> Services { get; set; } = new List<SelectedServiceDto>();
        public List<SelectedMedicineDto> Medicines { get; set; } = new List<SelectedMedicineDto>();
    }

    public class ExaminedRecordDto
    {
        public int VisitId { get; set; }
        public int MedicalRecordId { get; set; }
        public DateTime ExaminationTime { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string Diagnosis { get; set; } = string.Empty;
    }

    public class ExaminedServiceDto
    {
        public string ServiceName { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }

    public class ExaminedMedicineDto
    {
        public string MedicineName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Instruction { get; set; } = string.Empty;
    }
}
