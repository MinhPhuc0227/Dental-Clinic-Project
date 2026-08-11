using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.DTO.Receptionist
{
    public class UpdateReceptionistDto : CreateReceptionistDto
    {
        // Receptionist information
        [Required(ErrorMessage = "Mã lễ tân không hợp lệ.")]
        [Range(1, int.MaxValue, ErrorMessage = "Mã lễ tân phải lớn hơn 0.")]
        public int ReceptionistId { get; set; }

        // Account information
        [Required(ErrorMessage = "Mã tài khoản không hợp lệ.")]
        [Range(1, int.MaxValue, ErrorMessage = "Mã tài khoản phải lớn hơn 0.")]
        public int AccountId { get; set; }
    }
}
