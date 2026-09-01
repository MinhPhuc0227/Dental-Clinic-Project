using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.MODEL
{
    public class MedicineImportDetail
    {
        public int MedicineImportDetailId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitImportPrice { get; set; }

        public decimal TotalAmount { get; set; }

        // Foreign Key - MedicineImport
        public int MedicineImportId { get; set; }
        public MedicineImport MedicineImport { get; set; } = null!;

        // Foreign Key - Medicine
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; } = null!;
    }
}
