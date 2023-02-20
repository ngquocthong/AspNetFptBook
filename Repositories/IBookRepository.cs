using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
        void AddBook(Book b);
        void DeleteBook(Book b);
        Book GetBookByID(int id);
        void UpdateBook(Book temp);
    }
}
