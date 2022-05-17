using Abstractions.Services;
using DataModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MtnSports.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [Authorize(Roles="Admin")]
        public IActionResult Index()
        {
            return View(_itemService.GetAllItems());
        }

        public IActionResult Results(SearchViewModel search)
        {
            List<Item> searchResults = _itemService.GetSearchResults(search);
            TempData["ItemList"] = JsonConvert.SerializeObject(searchResults);
            return View(searchResults);
        }

        [HttpPost]
        
        public IActionResult Results(string sort)
        {
            var new_list = JsonConvert.DeserializeObject<List<Item>>(TempData["ItemList"].ToString());
            TempData["ItemList"] = JsonConvert.SerializeObject(new_list);
            List<Item> sortResults = _itemService.GetSortedResults(sort,new_list);
            return View(sortResults);
        }

        public IActionResult Details(int id)
        {
            var item = _itemService.GetItemById(id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Item item)
        {
            if (ModelState.IsValid)
            {
                _itemService.CreateItem(item);
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var item = _itemService.GetItemById(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id, Name, Type, Brand, Size, Price, Description, Photo, Stock")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _itemService.UpdateItem(item);
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var item = _itemService.GetItemById(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _itemService.DeleteItem(_itemService.GetItemById(id));
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public IActionResult Rent(int id)
        {
            var item = _itemService.GetItemById(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [Authorize(Roles = "User")]
        [HttpPost, ActionName("Rent")]
        [ValidateAntiForgeryToken]
        public IActionResult RentConfirmed(int id, int quantity, string userId)
        {           
            _itemService.RentItem(_itemService.GetItemById(id), quantity, userId, (DateTime)TempData["PickUpDate"], (DateTime)TempData["ReturnDate"]);
            return RedirectToAction("Index", "Home");
        }
    }
}
