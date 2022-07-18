using LibraryManagement.Domain;
using LibraryManagement.Domain.Extensions;

namespace LibraryManagement.Core
{
    public abstract class DataService : IDataService<Book>
    {
        public virtual void Insert(Book item) => item
            .RemoveCharsFromISBN()
            .Validate()
            .Duplicate(this.Get());

        public virtual void Update(int id, Book item)
        {
            if(!id.Exists(this.Get()))
                throw new Exception(nameof(Update));
            item.Validate();
        }

        public virtual void Delete(int id)
        {
            if (!id.Exists(this.Get()))
                throw new Exception(nameof(Delete));
        }

        public abstract List<Book> Get();

        public abstract void Dispose();
    }
}
