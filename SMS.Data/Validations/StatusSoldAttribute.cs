using SMS.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Data.Validations
{
    public class StatusSoldAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var v = (VehicleViewModel)validationContext.ObjectInstance;
            if(v.Status == 2 && v.DateSold == null)
            {
                return new ValidationResult("Date is required if sold.");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}