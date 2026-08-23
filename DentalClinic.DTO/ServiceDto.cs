using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.DTO
{
    public class ServiceDto
    {
        [DisplayName("Mã dịch vụ")]
        public int ServiceId { get; set; }

        [DisplayName("Tên dịch vụ")]
        public string ServiceName { get; set; } = string.Empty;

        [DisplayName("Đơn giá")]
        public decimal UnitPrice { get; set; }

        [DisplayName("Mô tả")]
        public string? Description { get; set; }

        [Browsable(false)]
        public ServiceStatus Status { get; set; } = ServiceStatus.Active;

        [DisplayName("Trạng thái")]
        public string StatusDisplay => Status == ServiceStatus.Active ? "Kinh doanh" : "Ngừng kinh doanh";
    }

    public class CreateServiceDto
    {
        [Required(ErrorMessage = "Tên dịch vụ không được để trống.")]
        [StringLength(100, ErrorMessage = "Tên dịch vụ không được vượt quá 100 ký tự.")]
        public string ServiceName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Đơn giá không được để trống.")]
        [Range(0, 999_999_999, ErrorMessage = "Đơn giá phải lớn hơn hoặc bằng 0.")]
        public decimal UnitPrice { get; set; }

        [StringLength(250, ErrorMessage = "Mô tả không được vượt quá 250 ký tự.")]
        public string? Description { get; set; }

        [EnumDataType(typeof(ServiceStatus), ErrorMessage = "Trạng thái không hợp lệ.")]
        public ServiceStatus Status { get; set; } = ServiceStatus.Active;
    }

    public class UpdateServiceDto : CreateServiceDto
    {
        [Required(ErrorMessage = "Mã dịch vụ không hợp lệ.")]
        [Range(1, int.MaxValue, ErrorMessage = "Mã dịch vụ phải lớn hơn 0.")]
        public int ServiceId { get; set; }
    }
}
