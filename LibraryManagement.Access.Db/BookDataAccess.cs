using LibraryManagement.Access.Db.Extensions;
using LibraryManagement.Models;
using System.Data;
using System.Data.Common;

namespace LibraryManagement.Access.Db
{
    public class BookDataAccess : ValidateBookDataAccess
    {
        private readonly DbConnection _connection;

        public BookDataAccess(DbConnection connection)
        {
            _connection = connection ?? throw new NullReferenceException(nameof(DbConnection));

            if (_connection.State is not ConnectionState.Open)
                _connection.Open();
        }

        public override void Create(Book item)
        {
            base.Create(item);

            using (DbCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = $"INSERT INTO {nameof(Book)}s ({nameof(Book.ISBN)}, {nameof(Book.Title)}, {nameof(Book.Author)}) VALUES (@ISBN, @TITLE, @AUTHOR);";
                cmd.AddParameter("ISBN", item.ISBN, DbType.String)
                   .AddParameter("TITLE", item.Title, DbType.String)
                   .AddParameter("AUTHOR", item.Author, DbType.String);

                if (cmd.ExecuteNonQuery() != 1)
                    throw new MissingFieldException(nameof(Create));
            }
        }

        public override void Update(int id, Book item)
        {
            base.Update(id, item);

            using (DbCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = $"UPDATE {nameof(Book)}s SET {nameof(Book.ISBN)}=@ISBN, {nameof(Book.Title)}=@TITLE, {nameof(Book.Author)}=@AUTHOR WHERE {nameof(Book.Id)}=@ID";
                cmd.AddParameter("ID", id, DbType.Int32)
                   .AddParameter("ISBN", item.ISBN, DbType.String)
                   .AddParameter("TITLE", item.Title, DbType.String)
                   .AddParameter("AUTHOR", item.Author, DbType.String);

                if (cmd.ExecuteNonQuery() != 1)
                    throw new MissingFieldException(nameof(Update));
            }
        }

        public override void Delete(int id)
        {
            base.Delete(id);

            using (DbCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = $"DELETE FROM {nameof(Book)}s WHERE {nameof(Book.Id).ToLower()}=@ID";
                cmd.AddParameter("ID", id, DbType.Int32);

                if (cmd.ExecuteNonQuery() != 1)
                    throw new ArgumentException(nameof(Update), string.Empty);
            }
        }

        public override List<Book> Read()
        {
            List<Book> books = new();

            using (DbCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = $"SELECT {nameof(Book.Id)}, {nameof(Book.ISBN)}, {nameof(Book.Title)}, {nameof(Book.Author)} FROM {nameof(Book).ToLower()}s;";

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new()
                        {
                            Id = reader.GetInt32(nameof(Book.Id)),
                            ISBN = reader.GetString(nameof(Book.ISBN)),
                            Title = reader.GetString(nameof(Book.Title)),
                            Author = reader.GetString(nameof(Book.Author))
                        });
                    }
                }
            }

            return books;
        }

        public void Close() => _connection?.Close();

        public override void Dispose() => Close();
    }
}