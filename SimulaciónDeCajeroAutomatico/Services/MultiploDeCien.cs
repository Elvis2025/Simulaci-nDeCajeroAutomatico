using System.ComponentModel.DataAnnotations;

namespace SimulaciónDeCajeroAutomatico.Services
{
    public class MultiploDeCienAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
         if (value != null && (int)value % 100 != 0)
            {
                return new ValidationResult("El monto debe ser un múltiplo de 100.");
            }

            return ValidationResult.Success!;
        }
    
    }
}
