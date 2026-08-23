using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.DTO
{
    // 1. DTO dùng để hiển thị trên DataGridView (UC_Receptionist_Visit)
    public class VisitListDto
    {
        public int VisitId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string PatientPhone { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public DateTime CheckInDateTime { get; set; }
        public string ReasonForVisit { get; set; } = string.Empty;
        public VisitStatus Status { get; set; }

        public int? AppointmentId { get; set; }
        public int QueueNumber { get; set; }

        public string StatusText => Status switch
        {
            VisitStatus.Waiting => "Đang chờ khám",
            VisitStatus.InExamination => "Đang khám",
            VisitStatus.Completed => "Khám xong",
            VisitStatus.Cancelled => "Đã hủy",
            _ => "Khác"
        };

        public string VisitType => AppointmentId.HasValue ? "Có hẹn trước" : "Khách vãng lai";
    }

    // 2. DTO dùng để Tạo mới tiếp nhận vãng lai (Có Validation)
    public class VisitCreateDto
    {
        [Required(ErrorMessage = "Vui lòng chọn bệnh nhân.")]
        [Range(1, int.MaxValue, ErrorMessage = "Bệnh nhân chọn không hợp lệ.")]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn bác sĩ phụ trách.")]
        [Range(1, int.MaxValue, ErrorMessage = "Bác sĩ chọn không hợp lệ.")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập lý do khám bệnh.")]
        [StringLength(500, MinimumLength = 2, ErrorMessage = "Lý do khám phải từ 2 đến 500 ký tự.")]
        public string ReasonForVisit { get; set; } = string.Empty;

        public int ReceptionistId { get; set; }

        // Không cần truyền AppointmentId vì đây là form tạo khách vãng lai (mặc định sẽ null)
    }
}
