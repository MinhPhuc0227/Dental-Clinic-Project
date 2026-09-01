using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.MODEL
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Note { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation property
        public ICollection<MedicineImport> MedicineImports { get; set; }
            = new List<MedicineImport>();
    }
}
