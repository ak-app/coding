using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LibraryManagement.Access.Core
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}