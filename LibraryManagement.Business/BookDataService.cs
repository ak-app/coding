using LibraryManagement.Access.Interfaces;
using LibraryManagement.Models;

namespace LibraryManagement.Business
{
    public class BookDataService
    {
        private readonly IDataAccess<Book> _dataAccess;

        public BookDataService(IDataAccess<Book> dataAccess) => _dataAccess = dataAccess ?? throw new NullReferenceException(nameof(IDataAccess<Book>));

        public Book Current { get; set; }

        public void AddOrUpdate(Book book)
        {
            if (book.Id == 0)
            {
                _dataAccess.Create(book);

                return;
            }
            _dataAccess.Update(book.Id, book);
        }

        public void Remove(int id) => _dataAccess.Delete(id);

        public List<Book> Books => _dataAccess.Read();
    }
}