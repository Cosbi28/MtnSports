using Abstractions.Repositories;
using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(MtnSportsAppContext mtnSportsAppContext) : base(mtnSportsAppContext)
        {
        }

        public List<Order> GetAllOrders()
        {
            return _mtnSportsAppContext.Orders.ToList();
        }

        public Order GetOrderById(int id)
        {
            return _mtnSportsAppContext.Orders.Where(o => o.Id == id).FirstOrDefault();
        }
    }
}
