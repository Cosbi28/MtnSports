using Abstractions.Repositories;
using Abstractions.Services;
using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class ItemOrderService : IItemOrderService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ItemOrderService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateOrder(ItemOrder itemOrder)
        {
            _repositoryWrapper.ItemOrderRepository.Create(itemOrder);
            _repositoryWrapper.Save();
        }

        public List<ItemOrder> GetAllItemOrders()
        {
            return _repositoryWrapper.ItemOrderRepository.FindAll().ToList();
        }

        public ItemOrder GetItemOrderByOrderId(int orderId)
        {
            return _repositoryWrapper.ItemOrderRepository.FindByCondition(c => c.IdOrder == orderId).FirstOrDefault();
        }
    }
}
