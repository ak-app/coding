using LibraryManagement.Models;

namespace LibraryManagement.Access.Extensions
{
    internal static class BookExtension
    {

        public static Book Duplicate(this Book book, IEnumerable<Book> books)
        {
            if (books.Any(b => b.ISBN == book.ISBN))
                throw new ArgumentException("ISBN exisitert bereits", nameof(Book.ISBN));

            return book;
        }

        public static Book RemoveCharsFromISBN(this Book book)
        {
            book.ISBN = new(book.ISBN.Where(char.IsDigit).ToArray());
            return book;
        }

        public static bool IdExists(this int id, IEnumerable<Book> books) => books.Any(b => b.Id == id);

        public static bool IdExists(this Book book, IEnumerable<Book> books) => books.Any(b => b.Id == book.Id);
    }
}
