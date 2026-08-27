using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.DTO
{
    public class WaitingQueueDto
    {
        public int VisitId { get; set; }
        public int QueueNumber { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string PatientPhone { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public DateTime CheckInDateTime { get; set; }
        public string TimeString => CheckInDateTime.ToString("HH:mm"); // Chỉ lấy giờ phút để hiện trên lưới
        public string ReasonForVisit { get; set; } = string.Empty;
        public VisitStatus Status { get; set; }

        public string StatusText => Status switch
        {
            VisitStatus.Waiting => "Chờ khám",
            VisitStatus.InExamination => "Đang khám",
            VisitStatus.Completed => "Khám xong",
            VisitStatus.Cancelled => "Đã hủy",
            _ => "Khác"
        };

        public string? PatientNote { get; set; } 
        public string? AppointmentNote { get; set; }

        public bool IsAppointment { get; set; } // True nếu có AppointmentId hợp lệ
        public string VisitType => IsAppointment ? "Có hẹn trước" : "Khách vãng lai";
        public string AppointmentBadge => IsAppointment ? "⭐ Có hẹn trước" : "Vãng lai";
    }
}
