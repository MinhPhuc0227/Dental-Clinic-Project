using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.MODEL
{
    public enum InvoiceStatus
    {
        Unpaid, // Chưa thanh toán
        Paid, // Đã thanh toán, hoàn tất
        Cancelled // Đã hủy
    }

    public class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTime InvoiceDateTime { get; set; }
        public decimal TotalAmount { get; set; } = 0;
        public decimal AmountGiven { get; set; } = 0;
        public decimal ChangeAmount { get; set; } = 0;
        public InvoiceStatus Status { get; set; } 

        // Foreign Key
        public int? PaymentMethodId { get; set; }
        public PaymentMethod? PaymentMethod { get; set; } = null!;

        public int VisitId { get; set; }
        public Visit Visit { get; set; } = null!;

        // Create transaction
        public int ReceptionistId { get; set; }
        public Receptionist Receptionist { get; set; } 

        // Cancel info
        public string? CancellationReason { get; set; }
        public DateTime? CancelledDate { get; set; }
        public int? CancelledBy { get; set; }
        public Receptionist? CancelledByReceptionist { get; set; }

        // Navigation property 
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
    }
}
