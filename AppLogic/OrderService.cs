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
            return _repositoryWrapper.OrderRepository.FindAll().ToList();
        }

        public Order GetOrderById(int id)
        {
            return _repositoryWrapper.OrderRepository.FindByCondition(c => c.Id == id).FirstOrDefault();
        }

        public void UpdateOrder(Order order)
        {
            _repositoryWrapper.OrderRepository.Update(order);
            _repositoryWrapper.Save();
        }
    }
}
