using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookRepository : IBookRepository
    {
        public List<Book> GetBooks() => BookDAO.GetBooks();
        public void AddBook(Book b) => BookDAO.SaveBook(b);
        public void DeleteBook(Book b) => BookDAO.DeleteBook(b);

        public Book GetBookByID(int id) => BookDAO.FindBookById(id);

        public void UpdateBook(Book b) => BookDAO.UpdateBook(b);
    }
}
