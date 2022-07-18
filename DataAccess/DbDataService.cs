using LibraryManagement.Core;
using LibraryManagement.DataAccess.Extension;
using LibraryManagement.Domain;
using LibraryManagement.Domain.Extensions;
using System.Data;
using System.Data.Common;

namespace LibraryManagement.DataAccess
{
    public class DbDataService : DataService
    {
        private const string sqlFileExtension = ".sql";

        public DbDataService(DbConnection connection, DirectoryInfo storage)
        {
            this.Connection = connection ?? throw new ArgumentNullException(nameof(Connection));
            this.Storage = storage ?? throw new ArgumentNullException(nameof(Storage));

            if (!Directory.Exists(Storage.FullName))
                throw new DirectoryNotFoundException(nameof(Storage));

            if (this.Connection.State != ConnectionState.Open)
                this.Connection.Open();
        }

        private DbConnection Connection { get; set; }
        private DirectoryInfo Storage { get; set; }

        public override void Insert(Book item)
        {
            base.Insert(item);

            using (DbCommand cmd = this.Connection.CreateCommand())
            {
                cmd.CommandText = string.Format(
                    File.ReadAllText(Path.Combine(this.Storage.ToString(), $"{nameof(Insert)}{sqlFileExtension}")),
                    $"{nameof(Book)}s",
                    nameof(Book.ISBN).ToUpper(),
                    nameof(Book.Title).ToUpper(),
                    nameof(Book.Author).ToUpper());

                cmd.Parameter(item);

                if (cmd.ExecuteNonQuery() != 1)
                    throw new MissingFieldException(nameof(Insert));
            }
        }

        public override void Update(int id, Book item)
        {
            base.Update(id, item);

            using (DbCommand cmd = this.Connection.CreateCommand())
            {
                cmd.CommandText = string.Format(
                    File.ReadAllText(Path.Combine(this.Storage.ToString(), $"{nameof(Update)}{sqlFileExtension}")),
                    $"{nameof(Book)}s",
                    nameof(Book.Title).ToUpper(),
                    nameof(Book.Author).ToUpper(),
                    nameof(Book.Id).ToUpper());

                cmd.Parameter(item);

                if (cmd.ExecuteNonQuery() != 1)
                    throw new MissingFieldException(nameof(Update));
            }
        }

        public override void Delete(int id)
        {
            base.Delete(id);

            using (DbCommand cmd = this.Connection.CreateCommand())
            {
                cmd.CommandText = string.Format(
                    File.ReadAllText(Path.Combine(this.Storage.ToString(), $"{nameof(Delete)}{sqlFileExtension}")),
                    $"{nameof(Book)}s",
                    nameof(Book.Id).ToUpper());

                cmd.Parameter(id);

                if (cmd.ExecuteNonQuery() != 1)
                    throw new MissingFieldException(nameof(Delete));
            }
        }

        public override List<Book> Get()
        {
            using (DbCommand cmd = Connection.CreateCommand())
            {
                cmd.CommandText = string.Format(
                    File.ReadAllText(Path.Combine(this.Storage.ToString(), $"{nameof(Get)}{sqlFileExtension}")),
                    nameof(Book.Id).ToUpper(),
                    nameof(Book.ISBN).ToUpper(),
                    nameof(Book.Title).ToUpper(),
                    nameof(Book.Author).ToUpper(),
                    $"{nameof(Book)}s");

                List<Book> books = new();

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new()
                        {
                            Id = int.Parse(reader[nameof(Book.Id)].ToString()),
                            ISBN = reader[nameof(Book.ISBN)].ToString().CreateISBNFromNumber(),
                            Title = reader[nameof(Book.Title)].ToString(),
                            Author = reader[nameof(Book.Author)].ToString()
                        });
                    }
                }
                return books;
            }
        }

        public override void Dispose() => this.Connection.Dispose();
    }
}
