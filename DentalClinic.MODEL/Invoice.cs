using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.MODEL
{
    public enum InvoiceStatus
    {
        Paid, // Đã thanh toán, hoàn tất
        Cancelled // Đã hủy
    }
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTime InvoiceDateTime { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountGiven { get; set; }
        public decimal ChangeAmount { get; set; }
        public InvoiceStatus Status { get; set; } 

        // Foreign Key
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; } = null!;

        public int VisitId { get; set; }
        public Visit Visit { get; set; } = null!;

        public int ReceptionistId { get; set; }
        public Receptionist Receptionist { get; set; } = null!;

        // Navigation property 
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
    }
}
