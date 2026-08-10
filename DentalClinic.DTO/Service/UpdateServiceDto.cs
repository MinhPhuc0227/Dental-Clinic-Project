using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.DTO.Service
{
    public class UpdateServiceDto : CreateServiceDto
    {
        [Required(ErrorMessage = "Mã dịch vụ không hợp lệ.")]
        [Range(1, int.MaxValue, ErrorMessage = "Mã dịch vụ phải lớn hơn 0.")]
        public int ServiceId { get; set; }
    }
}
