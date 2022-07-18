using LibraryManagement.Core;
using LibraryManagement.Domain;
using System.Data;
using System.Data.SQLite;

namespace LibraryManagement.DataAccess
{
    public class SQLiteDataService : DataService
    {
        public SQLiteDataService(SQLiteConnection connection)
        {
            this.Connection = connection ?? throw new ArgumentNullException(nameof(Connection));

            if (this.Connection.State != ConnectionState.Open)
                this.Connection.Open();
        }

        public SQLiteConnection Connection { get; private set; }

        public override void Insert(Book item)
        {
            base.Insert(item);

            using (SQLiteCommand cmd = new(this.Connection))
            {
                cmd.CommandText = $"INSERT INTO Books ({nameof(Book.ISBN)}, {nameof(Book.Title)}, {nameof(Book.Author)}) VALUES (@ISBN, @TITLE, @AUTHOR)";

                cmd.Parameters.AddWithValue("@ISBN", item.ISBN);
                cmd.Parameters.AddWithValue("@TITLE", item.Title);
                cmd.Parameters.AddWithValue("@AUTHOR", item.Author);

                if(cmd.ExecuteNonQuery() != 1)
                    throw new MissingFieldException(nameof(Insert));
            }
        }

        public override void Update(int id, Book item)
        {
            base.Update(id, item);

            using (SQLiteCommand cmd = new(this.Connection))
            {
                cmd.CommandText = $"UPDATE Books SET {nameof(Book.Title)}=@TITLE, {nameof(Book.Author)}=@AUTHOR WHERE {nameof(Book.Id)}=@ID";

                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@TITLE", item.Title);
                cmd.Parameters.AddWithValue("@AUTHOR", item.Author);

                if (cmd.ExecuteNonQuery() != 1)
                    throw new MissingFieldException(nameof(Update));
            }
        }

        public override void Delete(int id)
        {
            base.Delete(id);

            using (SQLiteCommand cmd = new(this.Connection))
            {
                cmd.CommandText = $"DELETE FROM Books WHERE {nameof(Book.Id)}=@ID";

                cmd.Parameters.AddWithValue("@ID", id);

                if (cmd.ExecuteNonQuery() != 1)
                    throw new MissingFieldException(nameof(Delete));
            }
        }

        public override List<Book> Get()
        {
            using (SQLiteCommand cmd = new(this.Connection))
            {
                cmd.CommandText = $"SELECT {nameof(Book.Id)}, {nameof(Book.ISBN)}, {nameof(Book.Title)}, {nameof(Book.Author)} FROM Books ORDER BY Id";

                List<Book> books = new();

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new()
                        {
                            Id = int.Parse(reader[nameof(Book.Id)].ToString()),
                            ISBN = reader[nameof(Book.ISBN)].ToString(),
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
