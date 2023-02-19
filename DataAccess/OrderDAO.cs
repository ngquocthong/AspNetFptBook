using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
        public static List<Order> GetOrder()
        {
            var listsOrders = new List<Order>();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    listsOrders = context.Orders.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
            return listsOrders;
        }
        public static Order FindOrderById(int orderId)
        {
            Order p = new Order();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    p = context.Orders.SingleOrDefault(x => x.ID == orderId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
            return p;
        }
        public static void SaveOrder(Order p)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Orders.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }
        public static void UpdateOrder(Order p)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Entry<Order>(p).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }
        public static void DeleteOrder(Order p)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var p1 = context.Orders.SingleOrDefault(c => c.ID == p.ID);
                    context.Orders.Remove(p1);
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
