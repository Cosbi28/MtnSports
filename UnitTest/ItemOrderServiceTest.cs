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
    public class ItemOrderServiceTest
    {
        private Mock<IRepositoryWrapper> _repositoryWrapperMock = new Mock<IRepositoryWrapper>();


        [TestInitialize]
        public void Initialize()
        {
            List<ItemOrder> itemOrders = new List<ItemOrder>()
            {
                new ItemOrder() { Id = 1, IdItem = 1, IdOrder = 1, Quantity = 10 },
                new ItemOrder() { Id = 2, IdItem = 1, IdOrder = 2, Quantity = 20 },
                new ItemOrder() { Id = 3, IdItem = 2, IdOrder = 3, Quantity = 30 },
                new ItemOrder() { Id = 4, IdItem = 2, IdOrder = 4, Quantity = 40 },
                new ItemOrder() { Id = 5, IdItem = 3, IdOrder = 5, Quantity = 50 },
                new ItemOrder() { Id = 6, IdItem = 3, IdOrder = 6, Quantity = 60 },
                new ItemOrder() { Id = 7, IdItem = 3, IdOrder = 7, Quantity = 70 }
            };

            _repositoryWrapperMock.Setup(repo => repo.ItemOrderRepository.GetAllItemOrders()).Returns(itemOrders);
            _repositoryWrapperMock.Setup(repo => repo.ItemOrderRepository.GetItemOrderByOrderId(7)).Returns(itemOrders.Last());
        }

        [TestMethod]
        public void GetItemOrderByOrderId_ShouldReturnItem()
        {
            var itemsOrderService = new ItemOrderService(_repositoryWrapperMock.Object);
            var itemOrder = itemsOrderService.GetAllItemOrders().Last();

            var secondItemOrder = itemsOrderService.GetItemOrderByOrderId(itemOrder.IdOrder);

            Assert.AreEqual(itemOrder.Id, secondItemOrder.Id);       
        }
        
        [TestMethod]
        public void GetAllItemOrders_ShouldReturnAllItem()
        {
            var itemsOrderService = new ItemOrderService(_repositoryWrapperMock.Object);
            var itemOrderList = itemsOrderService.GetAllItemOrders();

            Assert.AreEqual(7, itemOrderList.Count());
        }

        [TestMethod]
        public void CreateOrder_ShouldCreateOrder()
        {
            var itemsOrderService = new ItemOrderService(_repositoryWrapperMock.Object);
            var itemOrder = new ItemOrder()
            {
                Id = 7,
                IdOrder = 7,
                IdItem = 3,
                Quantity = 70,
            };

            itemsOrderService.CreateOrder(itemOrder);

            var lastItemOrder = itemsOrderService.GetAllItemOrders().Last();

            Assert.AreEqual(itemOrder.Id, lastItemOrder.Id);
            Assert.AreEqual(itemOrder.IdOrder, lastItemOrder.IdOrder);
            Assert.AreEqual(itemOrder.IdItem, lastItemOrder.IdItem);
            Assert.AreEqual(itemOrder.Quantity, lastItemOrder.Quantity);
        }



        //[TestMethod]
        //public void UpdateOrder_ShouldUpdateOrder()
        //{
        //    var itemsOrderService = new ItemOrderService(_repositoryWrapper);
        //    var itemOrder = itemsOrderService.GetAllItemOrders().Last();

        //    itemOrder.Quantity = 100;

        //    itemsOrderService.UpdateOrder(itemOrder);

        //    var lastItemOrder = itemsOrderService.GetAllItemOrders().Last();

        //    Assert.AreEqual(itemOrder.Id, lastItemOrder.Id);
        //    Assert.AreEqual(itemOrder.IdOrder, lastItemOrder.IdOrder);
        //    Assert.AreEqual(itemOrder.IdItem, lastItemOrder.IdItem);
        //    Assert.AreEqual(itemOrder.Quantity, lastItemOrder.Quantity);
        //}

        //[TestMethod]
        //public void DeleteOrder_ShouldDeleteInDb()
        //{
        //    var itemsOrderService = new ItemOrderService(_repositoryWrapper);
        //    var itemOrder = itemsOrderService.GetAllItemOrders().Last();

        //    itemsOrderService.DeleteOrder(itemOrder);

        //    var lastItemOrder = itemsOrderService.GetAllItemOrders().Last();

        //    Assert.AreNotEqual(itemOrder.Id, lastItemOrder.Id);
        //}

    }
}
