using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccess
{
	public class OrderDetailsDAO
	{
		public static List<OrderDetails> GetOrderDetails()
		{
			var listOrderDetailses = new List<OrderDetails>();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					listOrderDetailses = context.OrderDetailses.ToList();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);

			}
			return listOrderDetailses;
		}
		public static List<OrderDetails> FindOrderDetailsById(int orderId)
		{
			List<OrderDetails> p = new List<OrderDetails>();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					 p = context.OrderDetailses.Where(x => x.order_id == orderId).ToList();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);

			}
			return p;
		}
		/*public static void SaveOrderDetails(OrderDetails p)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					context.OrderDetailses.Add(p);
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);

			}
		}*/
		/*public static void UpdateOrderDetails(OrderDetails p)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					context.Entry<OrderDetails>(p).State =
						Microsoft.EntityFrameworkCore.EntityState.Modified;
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);

			}
		}
		public static void DeleteOrderDetails(OrderDetails p)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					var p1 = context.Orders.SingleOrDefault(c => c.ID == p.order_id);
					context.Orders.Remove(p1);
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);

			}
		}*/
	}
}
