using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.DTO
{
    // Dùng khi bác sĩ lưu bệnh án
    public class SaveMedicalRecordDto
    {
        public int MedicalRecordId { get; set; }
        public int VisitId { get; set; }
        public int DoctorId { get; set; }
        public string Diagnosis { get; set; } = string.Empty;
        public string Conclusion { get; set; } = string.Empty;
        public string? Note { get; set; }
        public bool IsDraft { get; set; }

        // Thông tin chi tiết dịch vụ và thuốc bác sĩ đã kê
        public List<SelectedServiceDto> Services { get; set; } = new List<SelectedServiceDto>();
        public List<SelectedMedicineDto> Medicines { get; set; } = new List<SelectedMedicineDto>();
    }

    // Dùng để hiển thị thông tin chung các bệnh án đã lưu
    public class ExaminedRecordDto
    {
        public int MedicalRecordId { get; set; }
        public DateTime ExaminationTime { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public VisitStatus VisitStatus { get; set; }
        public string Diagnosis { get; set; } = string.Empty;
        public string Conclusion { get; set; } = string.Empty;
    }

    // Hiển thị ngắn gọn dịch vụ của bệnh án 
    public class ExaminedServiceDto
    {
        public string ServiceName { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }

    // Hiển thị thông tin sử dụng thuốc của bệnh án
    public class ExaminedMedicineDto
    {
        public string MedicineName { get; set; } = string.Empty;
        public int Morning { get; set; }
        public int Noon { get; set; }
        public int Afternoon { get; set; }
        public int Evening { get; set; }
        public int Days { get; set; }
        public int Quantity { get; set; }
        public string Instruction { get; set; } = string.Empty;
    }
}
