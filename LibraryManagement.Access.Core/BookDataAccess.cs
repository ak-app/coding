using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Access.Core
{
    public class BookDataAccess : ValidateBookDataAccess
    {
        private readonly DataContext _context;

        public BookDataAccess(DataContext context) => _context = context ?? throw new NullReferenceException(nameof(DataContext));

        public override void Create(Book item)
        {
            base.Create(item);

            _context.Add(item);
            _context.SaveChanges();
        }

        public override void Update(int id, Book item)
        {
            base.Update(id, item);

            _context.Update(item);
            _context.SaveChanges();
        }

        public override void Delete(int id)
        {
            base.Delete(id);

            _context.Remove(_context.Books.Where(b => b.Id == id).FirstOrDefault());
            _context.SaveChanges();
        }

        public override List<Book> Read() => _context.Books.ToList();

        public override void Dispose() => _context?.Dispose();
    }
}
