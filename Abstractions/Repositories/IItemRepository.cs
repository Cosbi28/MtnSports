using DataModels;

namespace Abstractions.Repositories
{
    public interface IItemRepository : IRepositoryBase<Item>
    {
        void UpdateItemStock(int itemId, int returnedQuantity);
        Item GetItemById(int itemId);
        List<Item> GetAllItems();
    }
}