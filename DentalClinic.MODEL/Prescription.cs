using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.MODEL
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Note { get; set; }

        // Foreign Key
        public int MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; } = null!;

        // Navigation Property 
        public ICollection<PrescriptionDetail> PrescriptionDetails { get; set; } = new List<PrescriptionDetail>();
    }
}
