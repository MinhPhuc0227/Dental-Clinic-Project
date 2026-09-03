using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.DTO
{
    // DTO dùng cho lọc danh sách
    public class AppointmentFilterDto
    {
        public string? Keyword { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? DoctorId { get; set; }
        public AppointmentStatus? Status { get; set; }
    }

    // DTO hiển thị trên DataGridView
    public class AppointmentListDto
    {
        public int AppointmentId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string PatientPhone { get; set; } = string.Empty;
        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public DateTime AppointmentDateTime { get; set; }
        public AppointmentStatus Status { get; set; }
        public string StatusText => Status switch
        {
            AppointmentStatus.Scheduled => "Đã đặt lịch",
            AppointmentStatus.CheckedIn => "Đã tiếp nhận",
            AppointmentStatus.Cancelled => "Đã hủy",
            _ => "Khác"
        };
        public string ReasonForVisit { get; set; } = string.Empty;
        public string? Note { get; set; }
        public string ReceptionistName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }

    // DTO xem chi tiết nạp lên Form Dialog
    public class AppointmentDetailDto
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public DateTime AppointmentDateTime { get; set; }
        public TimeSpan AppointmentTime => AppointmentDateTime.TimeOfDay;
        public DateTime AppointmentDate => AppointmentDateTime.Date;
        public string ReasonForVisit { get; set; } = string.Empty;
        public string? Note { get; set; }
        public AppointmentStatus Status { get; set; }
        public int? ReceptionistId { get; set; }
        public string? ReceptionistName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }

    // DTO tạo mới lịch hẹn
    public class AppointmentCreateDto
    {
        [Required(ErrorMessage = "Vui lòng chọn bệnh nhân.")]
        [Range(1, int.MaxValue, ErrorMessage = "Bệnh nhân chọn không hợp lệ.")]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn bác sĩ phụ trách.")]
        [Range(1, int.MaxValue, ErrorMessage = "Bác sĩ chọn không hợp lệ.")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày khám.")]
        public DateTime AppointmentDate { get; set; }

        public TimeSpan AppointmentTime { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập lý do khám.")]
        [StringLength(500, ErrorMessage = "Lý do khám không được vượt quá 500 ký tự.")]
        public string ReasonForVisit { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Ghi chú không được vượt quá 1000 ký tự.")]
        public string? Note { get; set; }

        [Required(ErrorMessage = "Thiếu thông tin lễ tân tạo lịch.")]
        [Range(1, int.MaxValue, ErrorMessage = "Lễ tân không hợp lệ.")]
        public int ReceptionistId { get; set; }
    }

    // DTO cập nhật lịch hẹn (Kế thừa từ AppointmentCreateDto)
    public class AppointmentUpdateDto : AppointmentCreateDto
    {
        [Required(ErrorMessage = "Mã lịch hẹn không được để trống.")]
        [Range(1, int.MaxValue, ErrorMessage = "Mã lịch hẹn không hợp lệ.")]
        public int AppointmentId { get; set; }

        public AppointmentStatus Status { get; set; }
    }

    // Dành cho website
    public class OnlineAppointmentCreateDto
    {
        [Required(ErrorMessage = "Vui lòng chọn bác sĩ.")]
        [Range(1, int.MaxValue, ErrorMessage = "Bác sĩ không hợp lệ.")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày khám.")]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn giờ khám.")]
        public TimeSpan AppointmentTime { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập lý do khám.")]
        [StringLength(500, ErrorMessage = "Lý do khám không được vượt quá 500 ký tự.")]
        public string ReasonForVisit { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Ghi chú không được vượt quá 1000 ký tự.")]
        public string? Note { get; set; }
    }
}
