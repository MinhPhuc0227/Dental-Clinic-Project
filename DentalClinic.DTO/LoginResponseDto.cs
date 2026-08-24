using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.DTO
{
    public class LoginResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty; 

        public int UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
    }
}
