using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BorsaMvc.Validations
{
    public class UrlValidation:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string val = value.ToString();
            if (!val.ToUpper().StartsWith("HTTP://WWW"))
            {
                ErrorMessage = "Url Formatı Hatalı";
                return false;
            }
            return true;
          
        }
    }
}
