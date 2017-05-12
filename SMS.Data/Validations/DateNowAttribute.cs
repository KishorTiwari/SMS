using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SMS.Data.Validations
{
    public class DateNowAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var dateTime = Convert.ToDateTime(value);
            return (dateTime <= DateTime.Now.AddDays(1));
        }
    }
}
