using LibraryManagement.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Book : BaseModel
    {
        // Texts for the error messages can be found under Properties -> BookResource.resx

        [Required(ErrorMessageResourceType = typeof(Properties.BookResource), ErrorMessageResourceName = nameof(Properties.BookResource.Required))]
        [StringLength(13, MinimumLength = 13, ErrorMessageResourceType = typeof(Properties.BookResource), ErrorMessageResourceName = nameof(Properties.BookResource.ISBN_Error))]
        [ISBN(ErrorMessageResourceType = typeof(Properties.BookResource), ErrorMessageResourceName = nameof(Properties.BookResource.ISBN_Error_Length))]
        public string ISBN { get; set; }

        [Required(ErrorMessageResourceType = typeof(Properties.BookResource), ErrorMessageResourceName = nameof(Properties.BookResource.Required))]
        [MinLength(2, ErrorMessageResourceType = typeof(Properties.BookResource), ErrorMessageResourceName = nameof(Properties.BookResource.MinLength))]
        [MaxLength(255, ErrorMessageResourceType = typeof(Properties.BookResource), ErrorMessageResourceName = nameof(Properties.BookResource.MaxLength))]
        public string Title { get; set; }

        [Required(ErrorMessageResourceType = typeof(Properties.BookResource), ErrorMessageResourceName = nameof(Properties.BookResource.Required))]
        [MinLength(2, ErrorMessageResourceType = typeof(Properties.BookResource), ErrorMessageResourceName = nameof(Properties.BookResource.MinLength))]
        [MaxLength(255, ErrorMessageResourceType = typeof(Properties.BookResource), ErrorMessageResourceName = nameof(Properties.BookResource.MaxLength))]
        [RegularExpression("[a-zA-Z ]+$")]
        public string Author { get; set; }
    }
}