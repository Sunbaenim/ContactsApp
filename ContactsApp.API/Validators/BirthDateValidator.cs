using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApp.API.Validators
{
    public class BirthDateValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is null) return true;
            DateTime date = (DateTime)value;
            return date < DateTime.Now;
        }
    }
}
