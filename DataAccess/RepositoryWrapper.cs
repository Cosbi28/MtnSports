using Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private MtnSportsAppContext _mtnSportsAppContext;

        public RepositoryWrapper(MtnSportsAppContext mtnSportsAppContext)
        {
            _mtnSportsAppContext = mtnSportsAppContext;
        }

        public void Save()
        {
            _mtnSportsAppContext.SaveChanges();
        }

        private IItemRepository? _itemRepository;

        public IItemRepository ItemRepository
        {
            get
            {
                if (_itemRepository == null)
                {
                    _itemRepository = new ItemRepository(_mtnSportsAppContext);
                }

                return _itemRepository;
            }
        }

      
    }
}