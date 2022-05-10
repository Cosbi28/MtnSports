using Abstractions.Repositories;
using Abstractions.Services;
using DataModels;

namespace AppLogic
{
    public class ItemService : IItemService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ItemService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateItem(Item item)
        {
            _repositoryWrapper.ItemRepository.Create(item);
            _repositoryWrapper.Save();
        }

        public void DeleteItem(Item item)
        {
            _repositoryWrapper.ItemRepository.Delete(item);
            _repositoryWrapper.Save();
        }

        public List<Item> GetAllItems()
        {
            return _repositoryWrapper.ItemRepository.FindAll().ToList();
        }

        public Item GetItemById(int id)
        {
            return _repositoryWrapper.ItemRepository.FindByCondition(c => c.Id == id).FirstOrDefault();
        }

        public void UpdateItem(Item item)
        {
            _repositoryWrapper.ItemRepository.Update(item);
            _repositoryWrapper.Save();
        }
    }
}
