using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookDAO
    {
        public static List<Book> GetBooks()
        {
            var listProducts = new List<Book>();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    listProducts = context.Books.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
            return listProducts;
        }
        public static Book FindBookById(int bookId)
        {
            Book p = new Book();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    p = context.Books.SingleOrDefault(x => x.ID == bookId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
            return p;
        }
        public static void SaveBook(Book p)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Books.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }
        public static void UpdateBook(Book p)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Entry<Book>(p).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }
        public static void DeleteBook(Book p)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var p1 = context.Books.SingleOrDefault(c => c.ID == p.ID);
                    context.Books.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }
    }
}
