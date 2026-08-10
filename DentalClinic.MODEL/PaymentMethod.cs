using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.MODEL
{
    public enum PaymentMethodStatus
    {
        Active,
        Inactive
    }
    public class PaymentMethod
    {
        public int PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsCash { get; set; } = false;
        public PaymentMethodStatus Status { get; set; } = PaymentMethodStatus.Active;
    }
}
