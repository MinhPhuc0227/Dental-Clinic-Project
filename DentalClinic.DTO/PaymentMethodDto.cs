using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.DTO
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

    public class CreatePaymentMethodDto
    {
        [Required(ErrorMessage = "Tên phương thức thanh toán không được để trống.")]
        [StringLength(100, ErrorMessage = "Tên phương thức không được vượt quá 100 ký tự.")]
        public string PaymentMethodName { get; set; } = string.Empty;

        [StringLength(255, ErrorMessage = "Mô tả không được vượt quá 255 ký tự.")]
        public string? Description { get; set; }

        public bool IsCash { get; set; } = false;

        [EnumDataType(typeof(PaymentMethodStatus), ErrorMessage = "Trạng thái không hợp lệ.")]
        public PaymentMethodStatus Status { get; set; } = PaymentMethodStatus.Active;
    }

    public class UpdatePaymentMethodDto : CreatePaymentMethodDto
    {
        [Required(ErrorMessage = "Mã phương thức thanh toán không hợp lệ.")]
        public int PaymentMethodId { get; set; }
    }
}
