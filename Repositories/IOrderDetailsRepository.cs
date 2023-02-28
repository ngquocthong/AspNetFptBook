using BusinessObjects;

namespace Repositories
{
	public interface IOrderDetailsRepository
	{
		List<OrderDetails> GetOrderDetails();
		/*void AddOrderDetails(OrderDetails o);
		void DeleteOrderDetails(OrderDetails o);*/
		List<OrderDetails> GetOrderDetailsByID(int id);
/*		void UpdateOrderDetails(OrderDetails temp);*/
	}
}