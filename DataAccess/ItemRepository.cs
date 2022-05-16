using Abstractions.Repositories;
using DataModels;

namespace DataAccess
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(MtnSportsAppContext mtnSportsAppContext) : base(mtnSportsAppContext)
        {
        }

        public void UpdateItemStock(int itemId, int returnedQuantity)
        {
            var item = _mtnSportsAppContext.Items.Where(c => c.Id == itemId).FirstOrDefault();
            item.Stock += returnedQuantity;

            _mtnSportsAppContext.SaveChanges();
        }
    }
}