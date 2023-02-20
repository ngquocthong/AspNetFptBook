using BusinessObjects;

namespace Repositories
{
    public interface IOrderRepository
    {
        List<Order> GetOrders();
        void AddOrder(Order o);
        void DeleteOrder(Order o);
        Order GetOrderByID(int id);
        void UpdateOrder(Order temp);
    }
}