using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.DTO.Service
{
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
}
