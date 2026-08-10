using DentalClinic.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.DTO.Medicine
{
    public class UpdateMedicineDto : CreateMedicineDto
    {
        [Required(ErrorMessage = "Mã thuốc không hợp lệ.")]
        [Range(1, int.MaxValue)]
        public int MedicineId { get; set; }
    }
}
