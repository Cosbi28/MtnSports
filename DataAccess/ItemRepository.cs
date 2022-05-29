using Abstractions.Repositories;
using DataModels;

namespace DataAccess
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(MtnSportsAppContext mtnSportsAppContext) : base(mtnSportsAppContext)
        {
        }

        public List<Item> GetAllItems()
        {
            return _mtnSportsAppContext.Items.ToList();
        }

        public Item GetItemById(int itemId)
        {
            return _mtnSportsAppContext.Items.Where(c => c.Id == itemId).FirstOrDefault();
        }

        public void UpdateItemStock(int itemId, int returnedQuantity)
        {
            var item = _mtnSportsAppContext.Items.Where(c => c.Id == itemId).FirstOrDefault();
            item.Stock += returnedQuantity;

            _mtnSportsAppContext.SaveChanges();
        }
    }
}