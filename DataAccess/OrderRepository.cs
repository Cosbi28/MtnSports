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
    }
}
