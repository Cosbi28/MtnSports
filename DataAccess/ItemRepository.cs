using Abstractions.Repositories;
using DataModels;

namespace DataAccess
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(MtnSportsAppContext mtnSportsAppContext) : base(mtnSportsAppContext)
        {
        }
    }
}