using Abstractions.Repositories;
using AppLogic;
using DataAccess;
using DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class OrderServiceTest
    {
        private Mock<IRepositoryWrapper> _repositoryWrapperMock = new Mock<IRepositoryWrapper>();
        private readonly int _orderId = 10;

        [TestInitialize]
        public void Initialize()
        {
            List<Order> orderList = new List<Order>()
            {
                new Order() { Id = 1, IdUser = "074e44bc-a24d-4f06-992f-0096ccf7aafc",  PickupDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(1), TotalPrice = 1,  IsReturned = false},
                new Order() { Id = 2, IdUser = "57b16c83-8449-472e-9e71-d4682c077de8",  PickupDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(1), TotalPrice = 1,  IsReturned = false},
                new Order() { Id = 3, IdUser = "074e44bc-a24d-4f06-992f-0096ccf7aafc",  PickupDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(1), TotalPrice = 1,  IsReturned = false},
                new Order() { Id = 4, IdUser = "57b16c83-8449-472e-9e71-d4682c077de8",  PickupDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(1), TotalPrice = 1,  IsReturned = false},
                new Order() { Id = 5, IdUser = "074e44bc-a24d-4f06-992f-0096ccf7aafc",  PickupDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(1), TotalPrice = 1,  IsReturned = false},
                new Order() { Id = 6, IdUser = "57b16c83-8449-472e-9e71-d4682c077de8",  PickupDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(1), TotalPrice = 1,  IsReturned = false}
                };

            _repositoryWrapperMock.Setup(orderRepo => orderRepo.OrderRepository.GetAllOrders())
                                    .Returns(orderList);
            _repositoryWrapperMock.Setup(orderRepo => orderRepo.OrderRepository.GetOrderById(6))
                                    .Returns(orderList.Last());
        }

        [TestMethod]
        public void GetAllOrders_ShouldReturnAllOrders()
        {
            var orderService = new OrderService(_repositoryWrapperMock.Object);
            var orderList=orderService.GetAllOrders();
            Assert.AreEqual(6, orderList.Count);
        }

        //[TestMethod] 
        //public void CreateOrder_ShouldInsertInDb()
        //{
        //    var orderService = new OrderService(_repositoryWrapperMock.Object);
        //    var order = new Order()
        //    {
        //        IdUser= "074e44bc-a24d-4f06-992f-0096ccf7aafc",
        //        PickupDate=DateTime.Now,
        //        ReturnDate=DateTime.Now.AddDays(1),
        //        TotalPrice=5
        //    };

        //    orderService.CreateOrder(order);

        //    var lastOrder = orderService.GetAllOrders().Last();
        //    Assert.AreEqual(order.IdUser, lastOrder.IdUser);
        //    Assert.AreEqual(order.PickupDate, lastOrder.PickupDate);
        //    Assert.AreEqual(order.ReturnDate, lastOrder.ReturnDate);
        //    Assert.AreEqual(order.TotalPrice, lastOrder.TotalPrice);
        //}

        //[TestMethod]
        //public void UpdateOrder_ShouldUpdateInDb()
        //{
        //    var orderService = new OrderService(_repositoryWrapper);
        //    var order = orderService.GetAllOrders().Last();
        //    order.ReturnDate = DateTime.Now.AddDays(1);
        //    orderService.UpdateOrder(order);

        //    var lastOrder = orderService.GetAllOrders().Last();
        //    Assert.AreEqual(order.IdUser, lastOrder.IdUser);
        //    Assert.AreEqual(order.PickupDate, lastOrder.PickupDate);
        //    Assert.AreEqual(order.ReturnDate, lastOrder.ReturnDate);
        //    Assert.AreEqual(order.TotalPrice, lastOrder.TotalPrice);
        //}

        [TestMethod]
       public void GetOrderById_ShouldReturnOrderWithSameId()
        {
            var orderService = new OrderService(_repositoryWrapperMock.Object);
            var order = orderService.GetAllOrders().Last();

            var secondOrder = orderService.GetOrderById(order.Id);
            Assert.AreEqual(order.Id, secondOrder.Id);
        }

        [TestMethod]
        public void GetUserOrders_ShouldReturnAllUserOrders()
        {
            var orderService = new OrderService(_repositoryWrapperMock.Object);
            var idUser = "074e44bc-a24d-4f06-992f-0096ccf7aafc";

            var orderList = orderService.GetUserOrders(idUser);
            
            foreach (var order in orderList)
            {
                Assert.AreEqual(order.IdUser, idUser);
            }            
        }

        //[TestMethod]
        //public void DeleteOrder_ShouldDeleteInDb()
        //{
        //    var orderService = new OrderService(_repositoryWrapper);
        //    var order = orderService.GetAllOrders().Last();
            
        //    orderService.DeleteOrder(order);

        //    var lastOrder = orderService.GetAllOrders().Last();
        //    Assert.AreNotEqual(order.Id, lastOrder.Id);
        //}
    }
}
