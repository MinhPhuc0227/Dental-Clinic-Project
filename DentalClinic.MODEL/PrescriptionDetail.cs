using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.MODEL
{
    public class PrescriptionDetail
    {
        public int PrescriptionDetailId { get; set; }
        public int Morning { get; set; }  
        public int Noon { get; set; }      
        public int Afternoon { get; set; } 
        public int Evening { get; set; }  
        public int Days { get; set; }    
        public int Quantity { get; set; }  
        public string Instruction { get; set; } = string.Empty;

        // Foreign Key
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; } = null!;

        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; } = null!;
    }
}
