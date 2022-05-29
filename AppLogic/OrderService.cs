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
    public class OrderService : IOrderService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public OrderService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public void CreateOrder(Order order)
        {
            _repositoryWrapper.OrderRepository.Create(order);
            _repositoryWrapper.Save();
        }

        public void DeleteOrder(Order order)
        {
            _repositoryWrapper.OrderRepository.Delete(order);
            _repositoryWrapper.Save();
        }

        public List<Order> GetAllOrders()
        {
            //return _repositoryWrapper.OrderRepository.FindAll().ToList();
            return _repositoryWrapper.OrderRepository.GetAllOrders();  
        }

        public Order GetOrderById(int id)
        {
            //return _repositoryWrapper.OrderRepository.FindByCondition(c => c.Id == id).FirstOrDefault();
            return _repositoryWrapper.OrderRepository.GetOrderById(id);
        }

        public List<Order> GetUserOrders(string userId)
        {
            return _repositoryWrapper.OrderRepository.FindByCondition(c => c.IdUser == userId).ToList();
        }

        public void ReturnOrder(Order order)
        {
            order.IsReturned = true;
            _repositoryWrapper.OrderRepository.Update(order);

            var itemOrder = _repositoryWrapper.ItemOrderRepository.FindByCondition(c => c.IdOrder == order.Id).FirstOrDefault();
            _repositoryWrapper.ItemRepository.UpdateItemStock(itemOrder.IdItem, itemOrder.Quantity);

            _repositoryWrapper.Save();
        }

        public void UpdateOrder(Order order)
        {
            _repositoryWrapper.OrderRepository.Update(order);
            _repositoryWrapper.Save();
        }
    }
}
