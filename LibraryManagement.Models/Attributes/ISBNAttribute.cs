using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models.Attributes
{
    public class ISBNAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string isbn = value as string;

            // ISBN Nummer prüfen!

            if (string.IsNullOrWhiteSpace(isbn))
                return false;

            return true;
        }
    }
}
