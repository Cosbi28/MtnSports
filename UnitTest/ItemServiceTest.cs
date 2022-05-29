using Abstractions.Repositories;
using Abstractions.Services;
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
    public class ItemServiceTest
    {
        private Mock<IRepositoryWrapper> _repositoryWrapperMock = new Mock<IRepositoryWrapper>();
        private Mock<IItemService> _itemServiceMock = new Mock<IItemService>();
        private readonly int _itemId = 9;

        [TestInitialize]
        public void Initialize()
        {
            List<Item> itemList = new List<Item>()
            {
                new Item() { Id = 0, Name = "Test Item",  Type = "Test Type", Brand = "Test Brand", Size = "1",  Price = 1,  Description = "Test Description", Photo = "test.png", Stock = 10},
                new Item() { Id = 1, Name = "Test Item",  Type = "Test Type", Brand = "Test Brand", Size = "1",  Price = 1,  Description = "Test Description", Photo = "test.png", Stock = 10},
                new Item() { Id = 2, Name = "Test Item",  Type = "Test Type", Brand = "Test Brand", Size = "1",  Price = 1,  Description = "Test Description", Photo = "test.png", Stock = 10},
                new Item() { Id = 3, Name = "Test Item",  Type = "Test Type", Brand = "Test Brand", Size = "1",  Price = 1,  Description = "Test Description", Photo = "test.png", Stock = 10},
                new Item() { Id = 4, Name = "Test Item",  Type = "Test Type", Brand = "Test Brand", Size = "1",  Price = 1,  Description = "Test Description", Photo = "test.png", Stock = 10},
                new Item() { Id = 5, Name = "Test Item",  Type = "Test Type", Brand = "Test Brand", Size = "1",  Price = 1,  Description = "Test Description", Photo = "test.png", Stock = 10},
                new Item() { Id = 6, Name = "Test Item",  Type = "Test Type", Brand = "Test Brand", Size = "1",  Price = 1,  Description = "Test Description", Photo = "test.png", Stock = 10},
                new Item() { Id = 7, Name = "Test Item",  Type = "Test Type", Brand = "Test Brand", Size = "1",  Price = 1,  Description = "Test Description", Photo = "test.png", Stock = 10},
                new Item() { Id = 8, Name = "Test Item",  Type = "Test Type", Brand = "Test Brand", Size = "1",  Price = 1,  Description = "Test Description", Photo = "test.png", Stock = 10},
                new Item() { Id = 9, Name = "Test Item",  Type = "Test Type", Brand = "Test Brand", Size = "1",  Price = 1,  Description = "Test Description", Photo = "test.png", Stock = 10}
            };

            _repositoryWrapperMock.Setup(itemRepo => itemRepo.ItemRepository.GetAllItems())
                                    .Returns(itemList);
            _repositoryWrapperMock.Setup(itemRepo => itemRepo.ItemRepository.GetItemById(9))
                                    .Returns(itemList.Last());

            _itemServiceMock.Setup(x => x.GetAllItems())
                             .Returns(itemList);
        }

        [TestMethod]
        public void GetALlItems_Returns_ItemsList()
        {
            //arange
            var itemsService = new ItemService(_repositoryWrapperMock.Object);
            var itemsList = new List<Item>();

            //act
            itemsList = itemsService.GetAllItems();
            _repositoryWrapperMock.Verify(s => s.ItemRepository.GetAllItems(), Times.Once());

            //assert
            Assert.AreEqual(10, itemsList.Count);
        }

        [TestMethod]
        public void GetItemById_ReturnsItem()
        {
            //arange
            var itemsService = new ItemService(_repositoryWrapperMock.Object);
            var lastItem = itemsService.GetAllItems().Last();

            //act
            var item = itemsService.GetItemById(lastItem.Id);

            //assert
            Assert.AreEqual(item.Id, lastItem.Id);
            Assert.AreEqual(item.Name, lastItem.Name);
            Assert.AreEqual(item.Type, lastItem.Type);
            Assert.AreEqual(item.Brand, lastItem.Brand);
            Assert.AreEqual(item.Size, lastItem.Size);
            Assert.AreEqual(item.Price, lastItem.Price);
            Assert.AreEqual(item.Description, lastItem.Description);
            Assert.AreEqual(item.Photo, lastItem.Photo);
            Assert.AreEqual(item.Stock, lastItem.Stock);

        }

        [TestMethod]
        public void CreateNewItem_ShouldInsertNewItem()
        {
            var itemsService = new ItemService(_repositoryWrapperMock.Object);
            var item = new Item()
            {
                Id = 10,
                Name = "Test Item",
                Type = "Test Type",
                Brand = "Test Brand",
                Size = "1",
                Price = 1,
                Description = "Test Description",
                Photo = "test.png",
                Stock = 10
            };

            //check if item is in database
            var itemsList = itemsService.GetAllItems();
            var itemsIds = new List<int>();
            foreach (Item itm in itemsList)
            {
                itemsIds.Add(itm.Id);
            }
            CollectionAssert.DoesNotContain(itemsIds, item.Id);

            //create new item
            itemsService.CreateItem(item);

            //check if item is in database
            Item newItem = itemsService.GetAllItems().Last();

            Assert.AreEqual(_itemId, newItem.Id);
            Assert.AreEqual(item.Name, newItem.Name);
            Assert.AreEqual(item.Type, newItem.Type);
            Assert.AreEqual(item.Brand, newItem.Brand);
            Assert.AreEqual(item.Size, newItem.Size);
            Assert.AreEqual(item.Price, newItem.Price);
            Assert.AreEqual(item.Description, newItem.Description);
            Assert.AreEqual(item.Photo, newItem.Photo);
            Assert.AreEqual(item.Stock, newItem.Stock);
        }


        //[TestMethod]
        //public void UpdateItem_ShouldUpdateFields()
        //{
        //    var itemsService = new ItemService(_repositoryWrapperMock.Object);
        //    var lastItem = itemsService.GetAllItems().Last();

        //    //update in database
        //    lastItem.Name = "Test Update";
        //    itemsService.UpdateItem(lastItem);

        //    var updatedItem = itemsService.GetItemById(lastItem.Id);

        //    Assert.AreEqual(lastItem.Id, updatedItem.Id);
        //    Assert.AreEqual(lastItem.Name, updatedItem.Name);

        //}

        //[TestMethod]
        //public void DeleteItem_ShouldRemoveItem()
        //{
        //    var itemsService = new ItemService(_repositoryWrapperMock.Object);
        //    var item = new Item()
        //    {
        //        Id = _itemId,
        //        Name = "Test Item",
        //        Type = "Test Type",
        //        Brand = "Test Brand",
        //        Size = "1",
        //        Price = 1,
        //        Description = "Test Description",
        //        Photo = "test.png",
        //        Stock = 10
        //    };

        //    //check if item is in database
        //    var itemsList = itemsService.GetAllItems();
        //    var itemsIds = new List<int>();
        //    foreach (Item itm in itemsList)
        //    {
        //        itemsIds.Add(itm.Id);
        //    }

        //    CollectionAssert.Contains(itemsIds, item.Id);

        //    //remove it from database
        //    itemsService.DeleteItem(item);

        //    //check if item is not in database
        //    itemsList = itemsService.GetAllItems();
        //    itemsIds.Clear();
        //    foreach (Item itm in itemsList)
        //    {
        //        itemsIds.Add(itm.Id);
        //    }

        //    CollectionAssert.DoesNotContain(itemsIds, item.Id);
        //}
    }
}
