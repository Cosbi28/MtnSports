using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions.Services
{
    public interface IItemOrderService
    {
        ItemOrder GetItemOrderByOrderId(int orderId);
        void CreateOrder(ItemOrder itemOrder);
        List<ItemOrder> GetAllItemOrders();
    }
}
