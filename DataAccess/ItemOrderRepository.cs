using Abstractions.Repositories;
using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ItemOrderRepository : RepositoryBase<ItemOrder>, IItemOrderRepository
    {
        public ItemOrderRepository(MtnSportsAppContext mtnSportsAppContext) : base(mtnSportsAppContext)
        {
        }

        public List<ItemOrder> GetAllItemOrders()
        {
            return _mtnSportsAppContext.ItemOrders.ToList();
        }

        public ItemOrder GetItemOrderByOrderId(int orderId)
        {
            return _mtnSportsAppContext.ItemOrders.Where(c => c.IdOrder == orderId).FirstOrDefault();
        }
    }
}