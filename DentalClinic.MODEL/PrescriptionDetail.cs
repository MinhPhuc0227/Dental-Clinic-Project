using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.MODEL
{
    public class PrescriptionDetail
    {
        public int PrescriptionDetailId { get; set; }
        public string Dosage { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public int Quantity { get; set; }

        // Foreign Key
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; } = null!;

        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; } = null!;
    }
}
