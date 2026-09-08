using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.MODEL
{
    public enum InvoiceStatus
    {
        Unpaid, // Chưa thanh toán
        Paid, // Đã thanh toán
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

        // Thông tin hủy hóa đơn
        public string? CancellationReason { get; set; }
        public DateTime? CancelledDate { get; set; }
        public int? CancelledBy { get; set; } // Foreign Key 
        public Receptionist? CancelledByReceptionist { get; set; }

        // Foreign Key
        public int? PaymentMethodId { get; set; }
        public PaymentMethod? PaymentMethod { get; set; } = null!;

        public int VisitId { get; set; }
        public Visit Visit { get; set; } = null!;

        public int ReceptionistId { get; set; }
        public Receptionist Receptionist { get; set; } = null!;

        // Navigation property 
        // Một hóa đơn có thể có nhiều chi tiết hóa đơn
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
    }
}
