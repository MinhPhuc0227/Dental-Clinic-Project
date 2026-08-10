using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.MODEL
{
    public enum InvoiceItemType
    {
        Service,
        Medicine
    }

    public class InvoiceDetail
    {
        public int InvoiceDetailId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }

        // Foreign Key
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; } = null!;

        public int? MedicalRecordServiceId { get; set; }
        public MedicalRecordService? MedicalRecordService { get; set; }

        public int? PrescriptionDetailId { get; set; }
        public PrescriptionDetail? PrescriptionDetail { get; set; }

        // Computed property (not mapped to DB)
        public InvoiceItemType ItemType =>
           MedicalRecordServiceId.HasValue ? InvoiceItemType.Service : InvoiceItemType.Medicine;
    }
}
