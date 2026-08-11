using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.DTO.Patient
{
    public class UpdatePatientDto : CreatePatientDto
    {
        // Patient information
        [Required(ErrorMessage = "Mã bệnh nhân không hợp lệ.")]
        [Range(1, int.MaxValue, ErrorMessage = "Mã bệnh nhân phải lớn hơn 0.")]
        public int PatientId { get; set; }

        // Account information (optional)
        public int? AccountId { get; set; }
    }
}
