using LibraryManagement.Models;

namespace LibraryManagement.Access.Memory
{
    public class BookDataAccess : ValidateBookDataAccess
    {
        private static List<Book> _books = new()
        {
            new()
            {
                Id = 1,
                ISBN = "1234567890123",
                Title = "Gregs Tagebuch",
                Author = "Greg Heffley"
            },
            new()
            {
                Id = 2,
                ISBN = "3210987654321",
                Title = "Eine Geschichte der Zeit",
                Author = "Steven Hawking"
            }
        };

        public override void Create(Book item)
        {
            base.Create(item);

            item.Id = _books.Count > 0 ? _books.Max(u => u.Id) + 1 : 1;

            _books.Add(item);
        }

        public override void Update(int id, Book item)
        {
            base.Update(id, item);

            Book b = _books.FirstOrDefault(b => b.Id == id) ?? throw new NullReferenceException();

            b.Title = item.Title;
            b.Author = item.Author;
        }

        public override void Delete(int id)
        {
            base.Delete(id);

            _books.Remove(_books.FirstOrDefault(b => b.Id == id));
        }

        public override List<Book> Read() => _books;

        public override void Dispose() => _books.Clear();
    }
}