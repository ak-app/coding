using LibraryManagement.Access.File.Extensions;
using LibraryManagement.Models;

namespace LibraryManagement.Access.File
{
    public class BookDataAccess : ValidateBookDataAccess
    {
        private const char SEPERATOR = '|';
        private string _fileName;

        private static List<Book> _books = new();

        public BookDataAccess(string fileName)
        {
            _fileName = fileName;
            _ = !System.IO.File.Exists(fileName) ? System.IO.File.Create(fileName) : null;
        }

        public override void Create(Book item)
        {
            base.Create(item);

            item.Id = _books.Count > 0 ? _books.Max(u => u.Id) + 1 : 1;

            using (StreamWriter writer = new(_fileName, true))
            {
                writer.WriteLine(item.ToString(SEPERATOR));
            }
        }

        public override void Update(int id, Book item)
        {
            base.Update(id, item);

            List<Book> list = Read();
            Book book = list.FirstOrDefault(b => b.Id == id);

            book.Title = item.Title;
            book.Author = item.Author;

            System.IO.File.Copy(_fileName, $"{_fileName}.{DateTime.Now:hhmmss_ddMMyyyy}.old");

            using (StreamWriter writer = new(_fileName, false))
            {
                list.ForEach(e => writer.WriteLine(e.ToString(SEPERATOR)));
            }
        }

        public override void Delete(int id)
        {
            base.Delete(id);

            List<Book> list = Read();
            list.Remove(list.FirstOrDefault(b => b.Id == id));

            System.IO.File.Copy(_fileName, $"{_fileName}.{DateTime.Now:hhmmss_ddMMyyyy}.old");

            using (StreamWriter writer = new(_fileName, false))
            {
                list.ForEach(e => writer.WriteLine(e.ToString(SEPERATOR)));
            }
        }

        public override List<Book> Read()
        {
            _books.Clear();

            using (StreamReader reader = new(_fileName))
            {
                while (!reader.EndOfStream)
                {
                    string[] data = reader?.ReadLine()?.Split(SEPERATOR);

                    if (data is not null)
                    {
                        _books.Add(new()
                        {
                            Id = int.Parse(data[0]),
                            ISBN = data[1],
                            Title = data[2],
                            Author = data[3],
                        });
                    }
                }
            }

            return _books;
        }

        public override void Dispose() { }
    }
}