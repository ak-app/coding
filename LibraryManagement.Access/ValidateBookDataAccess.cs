using LibraryManagement.Access.Extensions;
using LibraryManagement.Access.Interfaces;
using LibraryManagement.Models;

namespace LibraryManagement.Access
{
    public abstract class ValidateBookDataAccess : IDataAccess<Book>
    {
        public virtual void Create(Book item)
        {
            item.RemoveCharsFromISBN()
                .Validate()
                .Duplicate(Read());
        }

        public virtual void Update(int id, Book item)
        {
            if (!item.RemoveCharsFromISBN()
                     .Validate()
                     .IdExists(Read()))
                throw new Exception(nameof(Update));
        }

        public virtual void Delete(int id)
        {
            if (!id.IdExists(Read()))
                throw new Exception(nameof(Delete));
        }

        public abstract List<Book> Read();

        public abstract void Dispose();
    }
}
