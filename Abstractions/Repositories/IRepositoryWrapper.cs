using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions.Repositories
{
    public interface IRepositoryWrapper
    {
        IItemRepository ItemRepository { get; }
        IOrderRepository OrderRepository { get; }
        IItemOrderRepository ItemOrderRepository { get; }
        void Save();
    }
}
