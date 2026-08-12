using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.DTO.Common
{
    public static class ValidateDto
    {
        public static string? Validate<T>(this T dto) where T : class
        {
            if (dto == null) return "Dữ liệu không được để trống.";

            var context = new ValidationContext(dto);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(dto, context, results, validateAllProperties: true))
            {
                return results.FirstOrDefault()?.ErrorMessage;
            }

            return null;
        }
    }
}
