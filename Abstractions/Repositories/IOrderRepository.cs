using DataModels;

namespace Abstractions.Repositories
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        Order GetOrderById(int id);
        List<Order> GetAllOrders();
    }
}
