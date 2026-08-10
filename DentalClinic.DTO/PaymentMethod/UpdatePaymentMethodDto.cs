using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.DTO.PaymentMethod
{
    public class UpdatePaymentMethodDto : CreatePaymentMethodDto
    {
        [Required(ErrorMessage = "Mã phương thức thanh toán không hợp lệ.")]
        public int PaymentMethodId { get; set; }
    }
}
