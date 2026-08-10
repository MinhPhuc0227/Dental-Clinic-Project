using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DentalClinic.DTO.Service
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

        public ServiceStatus Status { get; set; } = ServiceStatus.Active;

        [DisplayName("Trạng thái")]
        public string StatusDisplay => Status == ServiceStatus.Active ? "Hoạt động" : "Ngừng hoạt động";
    }
}
