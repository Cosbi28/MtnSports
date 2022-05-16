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
    }
}