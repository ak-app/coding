using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Access.Extensions
{
    internal static class ValidationExtension
    {
        public static T Validate<T>(this T item)
        {
            ValidationContext context = new(item.IsNotNull());
            List<ValidationResult> results = new();

            if (!Validator.TryValidateObject(item, context, results, true))
            {
                foreach (ValidationResult result in results)
                {
                    throw new ArgumentException(result.ErrorMessage, result.MemberNames?.FirstOrDefault());
                }
            }
            return item;
        }

        public static T IsNotNull<T>(this T book)
        {
            _ = book ?? throw new NullReferenceException(nameof(T));

            return book;
        }
    }
}
