using Abstractions.Repositories;
using AppLogic;
using DataAccess;
using DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        private IRepositoryWrapper _repositoryWrapper;

        [TestInitialize]
        public void Initialize()
        {
            DbContextOptionsBuilder<MtnSportsAppContext> optionsBuilder = new DbContextOptionsBuilder<MtnSportsAppContext>();
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MtnSportsDb");


            MtnSportsAppContext _mtnSportsAppContext = new MtnSportsAppContext(optionsBuilder.Options);
            _repositoryWrapper = new RepositoryWrapper(_mtnSportsAppContext);
        }

        [TestMethod]
        public void GetItemOrderByOrderId_ShouldReturnItem()
        {
            var itemsOrderService = new ItemOrderService(_repositoryWrapper);
            var itemOrder = itemsOrderService.GetAllItemOrders().Last();

            var secondItemOrder = itemsOrderService.GetItemOrderByOrderId(itemOrder.IdOrder);

            Assert.AreEqual(itemOrder.Id, secondItemOrder.Id);       
        }

        [TestMethod]
        public void CreateOrder_ShouldCreateOrder()
        {
            var itemsOrderService = new ItemOrderService(_repositoryWrapper);
            var itemOrder = new ItemOrder()
            {
                IdOrder = 1000,
                IdItem = 1,
                Quantity = 1               
            };

            itemsOrderService.CreateOrder(itemOrder);

            var lastItemOrder = itemsOrderService.GetAllItemOrders().Last();

            Assert.AreEqual(itemOrder.Id, lastItemOrder.Id);
            Assert.AreEqual(itemOrder.IdOrder, lastItemOrder.IdOrder);
            Assert.AreEqual(itemOrder.IdItem, lastItemOrder.IdItem);
            Assert.AreEqual(itemOrder.Quantity, lastItemOrder.Quantity);
        }

        [TestMethod]
        public void UpdateOrder_ShouldUpdateOrder()
        {
            var itemsOrderService = new ItemOrderService(_repositoryWrapper);
            var itemOrder = itemsOrderService.GetAllItemOrders().Last();

            itemOrder.Quantity = 100;

            itemsOrderService.UpdateOrder(itemOrder);

            var lastItemOrder = itemsOrderService.GetAllItemOrders().Last();

            Assert.AreEqual(itemOrder.Id, lastItemOrder.Id);
            Assert.AreEqual(itemOrder.IdOrder, lastItemOrder.IdOrder);
            Assert.AreEqual(itemOrder.IdItem, lastItemOrder.IdItem);
            Assert.AreEqual(itemOrder.Quantity, lastItemOrder.Quantity);
        }

        [TestMethod]
        public void DeleteOrder_ShouldDeleteInDb()
        {
            var itemsOrderService = new ItemOrderService(_repositoryWrapper);
            var itemOrder = itemsOrderService.GetAllItemOrders().Last();

            itemsOrderService.DeleteOrder(itemOrder);

            var lastItemOrder = itemsOrderService.GetAllItemOrders().Last();

            Assert.AreNotEqual(itemOrder.Id, lastItemOrder.Id);
        }


    }
}
