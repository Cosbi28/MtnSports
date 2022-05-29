using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions.Repositories
{
    public interface IItemOrderRepository : IRepositoryBase<ItemOrder>
    {
        ItemOrder GetItemOrderByOrderId(int orderId);
        List<ItemOrder> GetAllItemOrders();
    }
}
