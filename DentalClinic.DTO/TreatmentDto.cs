using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.DTO
{
    public class TreatmentDto
    {
        [DisplayName("Mã kế hoạch")]
        public int TreatmentId { get; set; }

        [Browsable(false)]
        public int PatientId { get; set; }

        [Browsable(false)]
        public int DoctorId { get; set; }

        [Browsable(false)]
        public int ServiceId { get; set; }

        [DisplayName("Dịch vụ")]
        public string ServiceName { get; set; } = string.Empty;

        [DisplayName("Bác sĩ")]
        public string DoctorName { get; set; } = string.Empty;

        [DisplayName("Ngày bắt đầu")]
        public DateTime StartDate { get; set; }

        [DisplayName("Ngày kết thúc")]
        public DateTime? EndDate { get; set; }

        [DisplayName("Số buổi dự kiến")]
        public int? PlannedSessions { get; set; }

        [DisplayName("Tổng chi phí")]
        public decimal TotalAmount { get; set; }

        [Browsable(false)]
        public TreatmentStatus Status { get; set; } = TreatmentStatus.InProgress;

        [DisplayName("Trạng thái")]
        public string StatusDisplay
            => Status switch
            {
                TreatmentStatus.InProgress => "Đang thực hiện",
                TreatmentStatus.Completed => "Đã hoàn thành",
                TreatmentStatus.Cancelled => "Đã hủy",
                _ => "Không xác định"
            };

        [DisplayName("Ghi chú")]
        public string? Note { get; set; }

        [DisplayName("Đã thực hiện")]
        public int CompletedSessions { get; set; }

        [DisplayName("Tiến độ")]
        public double ProgressPercent { get; set; }
    }

    // DTO dùng để tạo kế hoạch điều trị mới
    public class CreateTreatmentDto
    {
        [Required(ErrorMessage = "Mã bệnh nhân không hợp lệ.")]
        [Range(1, int.MaxValue, ErrorMessage = "Mã bệnh nhân phải lớn hơn 0.")]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Mã bác sĩ không hợp lệ.")]
        [Range(1, int.MaxValue, ErrorMessage = "Mã bác sĩ phải lớn hơn 0.")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn dịch vụ.")]
        [Range(1, int.MaxValue, ErrorMessage = "Mã dịch vụ phải lớn hơn 0.")]
        public int ServiceId { get; set; }

        [Required(ErrorMessage = "Ngày bắt đầu không được để trống.")]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Số buổi dự kiến phải lớn hơn 0.")]
        public int? PlannedSessions { get; set; }

        [StringLength(1000, ErrorMessage = "Ghi chú không được vượt quá 1000 ký tự.")]
        public string? Note { get; set; }

        public string? Validate()
        {
            if (StartDate.Date > DateTime.Today)
                return "Ngày bắt đầu không được lớn hơn ngày hiện tại.";

            if (EndDate.HasValue && EndDate.Value.Date < StartDate.Date)
                return "Ngày kết thúc không được trước ngày bắt đầu.";

            return null;
        }
    }

    // DTO dùng để cập nhật kế hoạch điều trị
    public class UpdateTreatmentDto : CreateTreatmentDto
    {
        [Required(ErrorMessage = "Mã kế hoạch điều trị không hợp lệ.")]
        [Range(1, int.MaxValue, ErrorMessage = "Mã kế hoạch điều trị phải lớn hơn 0.")]
        public int TreatmentId { get; set; }

        [EnumDataType(typeof(TreatmentStatus), ErrorMessage = "Trạng thái không hợp lệ.")]
        public TreatmentStatus Status { get; set; } = TreatmentStatus.InProgress;
    }

    // DTO dùng để hiển thị thông tin buổi điều trị (Visit)
    public class TreatmentSessionDto
    {
        [Browsable(false)]
        public int VisitId { get; set; }

        [DisplayName("Buổi")]
        public int? TreatmentSessionNumber { get; set; }

        [DisplayName("Ngày khám")]
        public DateTime CheckInDateTime { get; set; }

        [DisplayName("Bác sĩ")]
        public string DoctorName { get; set; } = string.Empty;

        [Browsable(false)]
        public VisitStatus Status { get; set; }

        [DisplayName("Trạng thái")]
        public string StatusDisplay => Status switch
        {
            VisitStatus.Waiting => "Chờ khám",
            VisitStatus.InExamination => "Đang khám",
            VisitStatus.WaitingForPayment => "Chờ thanh toán",
            VisitStatus.Completed => "Hoàn thành",
            VisitStatus.Cancelled => "Đã hủy",
            _ => "Không xác định"
        };
    }
}
