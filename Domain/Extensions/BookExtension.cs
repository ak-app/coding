using LibraryManagement.Domain.Exeptions;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Domain.Extensions
{
    public static class BookExtension
    {
        public static Book Validate(this Book book)
        {
            ValidationContext context = new(book);
            List<ValidationResult> results = new();

            if(!Validator.TryValidateObject(book, context, results, true))
            {
                foreach (ValidationResult result in results)
                {
                    throw new BookException(result.MemberNames?.FirstOrDefault(), result.ErrorMessage);
                }
            }
            return book;
        }

        public static Book Duplicate(this Book book, IEnumerable<Book> books)
        {
            if(books.Any(b => b.ISBN == book.ISBN))
                throw new BookException(nameof(Book.ISBN), Resource.ErrorResource.ISBNDuplicate);
            return book;
        }

        public static bool Exists(this int id, IEnumerable<Book> books)
        {
            if(books.Any(b => b.Id == id))
                return true;
            return false;
        }

        public static Book RemoveCharsFromISBN(this Book book)
        {
            book.ISBN = new(book.ISBN.Where(char.IsDigit).ToArray());
            return book;
        }

        public static string CreateISBNFromNumber(this string isbn)
        {
            isbn = isbn.Insert(3, "-");
            isbn = $"ISBN{isbn}";
            return isbn;
        }

        public static void Clone(this Book book, Book copy)
        {
            book.ISBN = copy.ISBN;
            book.Title = copy.Title;
            book.Author = copy.Author;
        }
    }
}
