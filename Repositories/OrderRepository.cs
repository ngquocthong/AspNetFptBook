using BusinessObjects;
using DataAccess;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public List<Order> GetOrders() => OrderDAO.GetOrder();
        public void AddOrder(Order o) => OrderDAO.SaveOrder(o);
        public void DeleteOrder(Order o) => OrderDAO.DeleteOrder(o);

        public Order GetOrderByID(int id) => OrderDAO.FindOrderById(id);

        public void UpdateOrder(Order o) => OrderDAO.UpdateOrder(o);
    }
}