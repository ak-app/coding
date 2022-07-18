namespace LibraryManagement.Core
{
    public interface IDataService<T> : IDisposable
    {
        void Insert(T item);
        void Update(int id, T item);
        void Delete(int id);
        List<T> Get();
    }
}
