using BusinessObjects;
using DataAccess;

namespace Repositories
{
	public class OrderDetailsRepository : IOrderDetailsRepository
	{
		public List<OrderDetails> GetOrderDetails() => OrderDetailsDAO.GetOrderDetails();
		/*public void AddOrderDetails(OrderDetails o) => OrderDetailsDAO.SaveOrderDetails(o);
		public void DeleteOrderDetails(OrderDetails o) => OrderDetailsDAO.DeleteOrderDetails(o);
*/
		public List<OrderDetails> GetOrderDetailsByID(int id) => OrderDetailsDAO.FindOrderDetailsById(id);

		/*public void UpdateOrderDetails(OrderDetails o) => OrderDetailsDAO.UpdateOrderDetails(o);*/
	}
}