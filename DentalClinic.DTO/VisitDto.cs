using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.DTO
{
    // DTO dùng để hiển thị thông tin lượt khám trên DataGridView (UC_Receptionist_Visit)
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
            VisitStatus.Waiting => "Chờ khám",
            VisitStatus.InExamination => "Đang khám",
            VisitStatus.WaitingForPayment => "Chờ thanh toán",
            VisitStatus.Completed => "Khám xong",
            VisitStatus.Cancelled => "Đã hủy",
            _ => "Khác"
        };

        public string VisitType => AppointmentId.HasValue ? "Có hẹn trước" : "Khách vãng lai";
    }

    // DTO dùng để tiếp nhận Khách vãng lai (không có lịch hẹn)
    // Không có AppointmentId (mặc định null) 
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
    }
}
