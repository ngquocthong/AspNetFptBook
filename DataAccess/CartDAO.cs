using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CartDAO
    {
        public static List<Cart> GetCarts()
        {
            var listCarts = new List<Cart>();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    listCarts = context.Carts.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
            return listCarts;
        }
        public static Cart FindCartById(int cartId)
        {
            Cart p = new Cart();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    p = context.Carts.SingleOrDefault(x => x.ID == cartId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
            return p;
        }

        public static void UpdateCart(Cart p)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Entry<Cart>(p).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }
        public static void DeleteCart(Cart p)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var p1 = context.Carts.SingleOrDefault(c => c.ID == p.ID);
                    context.Carts.Remove(p1);
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
