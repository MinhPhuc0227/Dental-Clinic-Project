using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.DTO.Doctor
{
    public class UpdateDoctorDto : CreateDoctorDto
    {
        // Doctor information
        [Required(ErrorMessage = "Mã bác sĩ không hợp lệ.")]
        [Range(1, int.MaxValue, ErrorMessage = "Mã bác sĩ phải lớn hơn 0.")]
        public int DoctorId { get; set; }


        // Account information
        [Required(ErrorMessage = "Mã tài khoản không hợp lệ.")]
        [Range(1, int.MaxValue, ErrorMessage = "Mã tài khoản phải lớn hơn 0.")]
        public int AccountId { get; set; }
    }
}
