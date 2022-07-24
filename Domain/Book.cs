using LibraryManagement.Domain.Attributes;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Domain
{
    public class Book : BaseModel
    {
        [Required(
            //ErrorMessage = "Darf nicht leer sein"
            ErrorMessageResourceType = typeof(Resource.ErrorResource),
            ErrorMessageResourceName = nameof(RequiredAttribute))]
        [ISBN(
            //ErrorMessage = "Ungültige ISBN"
            ErrorMessageResourceType = typeof(Resource.ErrorResource),
            ErrorMessageResourceName = nameof(ISBN))]
        [StringLength(
            //ErrorMessage = "Ungültige Länge"
            13,
            MinimumLength = 13,
            ErrorMessageResourceType = typeof(Resource.ErrorResource),
            ErrorMessageResourceName = nameof(StringLengthAttribute))]
        public string ISBN { get; set; }

        [Required(
            //ErrorMessage = "Darf nicht leer sein"
            ErrorMessageResourceType = typeof(Resource.ErrorResource),
            ErrorMessageResourceName = nameof(RequiredAttribute))]
        [MinLength(
            //ErrorMessage = "Eintrag zu kurz"
            2,
            ErrorMessageResourceType = typeof(Resource.ErrorResource),
            ErrorMessageResourceName = nameof(MinLengthAttribute))]
        [MaxLength(
            //ErrorMessage = "Eintrag zu lang"
            100,
            ErrorMessageResourceType = typeof(Resource.ErrorResource),
            ErrorMessageResourceName = nameof(MaxLengthAttribute))]
        public string Title { get; set; }

        [Required(
            //ErrorMessage = "Darf nicht leer sein"
            ErrorMessageResourceType = typeof(Resource.ErrorResource),
            ErrorMessageResourceName = nameof(RequiredAttribute))]
        [MinLength(
            //ErrorMessage = "Eintrag zu kurz"
            2,
            ErrorMessageResourceType = typeof(Resource.ErrorResource),
            ErrorMessageResourceName = nameof(MinLengthAttribute))]
        [MaxLength(
            //ErrorMessage = "Eintrag zu lang"
            100,
            ErrorMessageResourceType = typeof(Resource.ErrorResource),
            ErrorMessageResourceName = nameof(MaxLengthAttribute))]
        [RegularExpression(
            //ErrorMessage = "Eintrag darf nur Buchstaben enthalten"
            "[a-zA-Z ]+$",
            ErrorMessageResourceType = typeof(Resource.ErrorResource),
            ErrorMessageResourceName = $"{nameof(Author)}{nameof(RegularExpressionAttribute)}")]
        public string Author { get; set; }
    }
}
