using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.MODEL
{
    public enum MedicineStatus
    {
        Active,
        Inactive
    }
    public class Medicine
    {
        public int MedicineId { get; set; }
        public string MedicineName { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int QuantityInStock { get; set; } = 0;
        public string? Description { get; set; }
        public MedicineStatus Status { get; set; } = MedicineStatus.Active;
    }
}
