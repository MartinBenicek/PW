using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Nemocnice.domain.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class FutureDateAttribute : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            else if (value is DateTime dateValue)
            {
                if (dateValue.Date >= DateTime.Now.Date)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult($"Pole {validationContext.DisplayName} musí být dnešní nebo budoucí datum.");
                }
            }
            else
            {
                throw new NotImplementedException($"Atribut {nameof(FutureDateAttribute)} není implementován pro typ: {value.GetType()}");
            }
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (!context.Attributes.ContainsKey("data-val"))
                context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-futuredate", $"Pole {context.ModelMetadata.DisplayName ?? context.ModelMetadata.Name} musí být dnešní nebo budoucí datum.");
        }
    }
}
