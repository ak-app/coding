using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Domain.Attributes
{
    public class ISBNAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string isbn = value as string;

            if (isbn is null)
                return false;

            // Complicated calculation of ISBN

            return true;
        }
    }
}
