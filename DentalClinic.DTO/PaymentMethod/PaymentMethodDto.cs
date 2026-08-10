using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DentalClinic.DTO.PaymentMethod
{
    public class PaymentMethodDto
    {
        public int PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsCash { get; set; }

        public PaymentMethodStatus Status { get; set; }

        // Translate to Vietnamese for DataGridView
        public string StatusDisplay => Status == PaymentMethodStatus.Active ? "Hoạt động" : "Ngưng hoạt động";
    }
}
