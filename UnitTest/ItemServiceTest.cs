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
        private IRepositoryWrapper _repositoryWrapper;
        private readonly int _itemId = 10;

        [TestInitialize]
        public void Initialize()
        {
            DbContextOptionsBuilder<MtnSportsAppContext> optionsBuilder = new DbContextOptionsBuilder<MtnSportsAppContext>();
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MtnSportsDb");


            MtnSportsAppContext _mtnSportsAppContext = new MtnSportsAppContext(optionsBuilder.Options);
            _repositoryWrapper= new RepositoryWrapper(_mtnSportsAppContext);
        }

        [TestMethod]
        public void GetALlItems_Returns_ItemsList()
        {
            //arange
            var itemsService = new ItemService(_repositoryWrapper);
            var itemsList = new List<Item>();

            //act
            itemsList = itemsService.GetAllItems();

            //assert
            Assert.AreEqual(7, itemsList.Count);
        }

        [TestMethod]
        public void CreateNewItem_ShouldInsertNewItem()
        {
            var itemsService = new ItemService(_repositoryWrapper);
            var item = new Item()
            {
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


        [TestMethod]
        public void UpdateItem_ShouldUpdateFields()
        {
            var itemsService = new ItemService(_repositoryWrapper);
            var lastItem = itemsService.GetAllItems().Last();

            //update in database
            lastItem.Name = "Test Update";
            itemsService.UpdateItem(lastItem);

            var updatedItem = itemsService.GetItemById(lastItem.Id);

            Assert.AreEqual(lastItem.Id, updatedItem.Id);
            Assert.AreEqual(lastItem.Name, updatedItem.Name);

        }

        [TestMethod]
        public void DeleteItem_ShouldRemoveItem()
        {
            var itemsService = new ItemService(_repositoryWrapper);
            var item = new Item()
            {
                Id = _itemId,
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
            foreach(Item itm in itemsList)
            {
                itemsIds.Add(itm.Id);
            }

            CollectionAssert.Contains(itemsIds, item.Id);

            //remove it from database
            itemsService.DeleteItem(item);

            //check if item is not in database
            itemsList = itemsService.GetAllItems();
            itemsIds.Clear();
            foreach (Item itm in itemsList)
            {
                itemsIds.Add(itm.Id);
            }

            CollectionAssert.DoesNotContain(itemsIds, item.Id);
        }
    }
}
