using Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private MtnSportsAppContext _mtnSportsAppContext;

        public RepositoryWrapper(MtnSportsAppContext mtnSportsAppContext)
        {
            _mtnSportsAppContext = mtnSportsAppContext;
        }

        public void Save()
        {
            _mtnSportsAppContext.SaveChanges();
        }

        private IItemRepository? _itemRepository;

        public IItemRepository ItemRepository
        {
            get
            {
                if (_itemRepository == null)
                {
                    _itemRepository = new ItemRepository(_mtnSportsAppContext);
                }

                return _itemRepository;
            }
        }
        private IOrderRepository? _orderRepository;

        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(_mtnSportsAppContext);
                }

                return _orderRepository;
            }
        }

        private IItemOrderRepository? _itemOrderRepository;

        public IItemOrderRepository ItemOrderRepository
        {
            get
            {
                if (_itemOrderRepository == null)
                {
                    _itemOrderRepository = new ItemOrderRepository(_mtnSportsAppContext);
                }

                return _itemOrderRepository;
            }
        }

    }
}