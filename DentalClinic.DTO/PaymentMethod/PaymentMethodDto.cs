using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DentalClinic.DTO.PaymentMethod
{
    public class PaymentMethodDto
    {
        [DisplayName("Mã PT")]
        public int PaymentMethodId { get; set; }

        [DisplayName("Tên phương thức")]
        public string PaymentMethodName { get; set; } = string.Empty;

        [DisplayName("Mô tả")]
        public string? Description { get; set; }

        [Browsable(false)]
        public bool IsCash { get; set; }

        [DisplayName("Tiền mặt")]
        public string IsCashDisplay => IsCash ? "Có" : "Không";

        [Browsable(false)]
        public PaymentMethodStatus Status { get; set; }

        [DisplayName("Trạng thái")]
        public string StatusDisplay => Status == PaymentMethodStatus.Active ? "Hoạt động" : "Ngừng hoạt động";
    }
}
