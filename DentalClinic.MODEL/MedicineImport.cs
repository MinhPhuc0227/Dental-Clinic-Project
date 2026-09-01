using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.MODEL
{
    public class MedicineImport
    {
        public int MedicineImportId { get; set; }

        public DateTime ImportDate { get; set; }

        public decimal TotalAmount { get; set; } = 0;

        public string? Note { get; set; }

        // Foreign Key - Supplier
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;

        // Foreign Key - Account
        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;

        // Foreign Key - PaymentMethod
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; } = null!;

        // Navigation property
        public ICollection<MedicineImportDetail> MedicineImportDetails { get; set; }
            = new List<MedicineImportDetail>();
    }
}
