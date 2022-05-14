using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions.Services
{
    public interface IItemService
    {
        void CreateItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Item item);
        Item GetItemById(int id);
        List<Item> GetAllItems();
        List<Item> GetSearchResults(SearchViewModel search);
        List<Item> GetSortedResults(string sort, List<Item> items);


    }
}
