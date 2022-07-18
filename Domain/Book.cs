using LibraryManagement.Domain.Attributes;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Domain
{
    public class Book : BaseModel
    {
        [Required(
            ErrorMessageResourceType = typeof(Resource.ErrorResource),
            ErrorMessageResourceName = nameof(ISBN))]
        [ISBN(
            ErrorMessageResourceType = typeof(Resource.ErrorResource),
            ErrorMessageResourceName = nameof(ISBN))]
        [StringLength(
            13,
            MinimumLength = 13,
            ErrorMessageResourceType = typeof(Resource.ErrorResource),
            ErrorMessageResourceName = nameof(StringLengthAttribute))]
        public string ISBN { get; set; }

        [Required(
            ErrorMessageResourceType = typeof(Resource.ErrorResource),
            ErrorMessageResourceName = nameof(Title))]
        [MinLength(
            2,
            ErrorMessageResourceType = typeof(Resource.ErrorResource),
            ErrorMessageResourceName = nameof(MinLengthAttribute))]
        [MaxLength(
            100,
            ErrorMessageResourceType = typeof(Resource.ErrorResource),
            ErrorMessageResourceName = nameof(MaxLengthAttribute))]
        public string Title { get; set; }

        [Required(
            ErrorMessageResourceType = typeof(Resource.ErrorResource),
            ErrorMessageResourceName = nameof(Author))]
        [MinLength(
            2,
            ErrorMessageResourceType = typeof(Resource.ErrorResource),
            ErrorMessageResourceName = nameof(MinLengthAttribute))]
        [MaxLength(
            100,
            ErrorMessageResourceType = typeof(Resource.ErrorResource),
            ErrorMessageResourceName = nameof(MaxLengthAttribute))]
        [RegularExpression(
            "[a-zA-Z ]+$",
            ErrorMessageResourceType = typeof(Resource.ErrorResource),
            ErrorMessageResourceName = $"{nameof(Author)}{nameof(RegularExpressionAttribute)}")]
        public string Author { get; set; }
    }
}
