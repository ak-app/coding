using LibraryManagement.Models;

namespace LibraryManagement.Access.Interfaces
{
    public interface IDataAccess<T> : IDisposable
    {
        void Create(T item);
        void Delete(int id);
        void Update(int id, T item);
        List<T> Read();
    }
}