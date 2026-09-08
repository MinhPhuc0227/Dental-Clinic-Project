using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.MODEL
{
    public class MedicalRecordService
    {
        public int MedicalRecordServiceId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Note { get; set; }

        // Foreign Key 
        public int MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; } = null!;

        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;
    }
}
