using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.DTO.PaymentMethod
{
    public class UpdatePaymentMethodDto
    {
        [Required(ErrorMessage = "Mã phương thức thanh toán không hợp lệ.")]
        public int PaymentMethodId { get; set; }

        [Required(ErrorMessage = "Tên phương thức thanh toán không được để trống.")]
        [StringLength(50, ErrorMessage = "Tên phương thức không được vượt quá 50 ký tự.")]
        public string PaymentMethodName { get; set; } = string.Empty;

        [StringLength(250, ErrorMessage = "Mô tả không được vượt quá 250 ký tự.")]
        public string? Description { get; set; }
        public bool IsCash { get; set; }

        [EnumDataType(typeof(PaymentMethodStatus), ErrorMessage = "Trạng thái không hợp lệ.")]
        public PaymentMethodStatus Status { get; set; }
    }
}
