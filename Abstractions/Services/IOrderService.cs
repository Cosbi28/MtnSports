using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions.Services
{
    public interface IOrderService
    {
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
        Order GetOrderById(int id);
        List<Order> GetAllOrders();
    }
}
