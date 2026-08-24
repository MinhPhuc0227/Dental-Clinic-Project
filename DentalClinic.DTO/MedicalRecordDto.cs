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
        public bool IsDraft { get; set; }

        // Chứa danh sách dịch vụ và thuốc bác sĩ đã kê
        public List<SelectedServiceDto> Services { get; set; } = new List<SelectedServiceDto>();
        public List<SelectedMedicineDto> Medicines { get; set; } = new List<SelectedMedicineDto>();
    }
}
