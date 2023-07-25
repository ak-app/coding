using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Access.File.Extensions
{
    internal static class FileExtension
    {
        public static string ToString(this Book book, char seperator) => $"{book.Id}{seperator}{book.ISBN}{seperator}{book.Title}{seperator}{book.Author}";
    }
}
