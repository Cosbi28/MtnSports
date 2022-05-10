using Abstractions.Services;
using DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MtnSports.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        public IActionResult Index()
        {
            return View(_itemService.GetAllItems());
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

        public IActionResult Create()
        {
            //ViewData["AvatarId"] = new SelectList(_userService.GetAvatars(), "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Item item)
        {
            if (ModelState.IsValid)
            {
                _itemService.CreateItem(item);
                return RedirectToAction(nameof(Index));
            }
            //ViewData["AvatarId"] = new SelectList(_userService.GetAvatars(), "Id", "Id", user.AvatarId);
            return View(item);
        }

        public IActionResult Edit(int id)
        {
            var item = _itemService.GetItemById(id);
            if (item == null)
            {
                return NotFound();
            }
            //ViewData["AvatarId"] = new SelectList(_userService.GetAvatars(), "Id", "Id", user.AvatarId);
            return View(item);
        }

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
            //ViewData["AvatarId"] = new SelectList(_userService.GetAvatars(), "Id", "Id", user.AvatarId);
            return View(item);
        }

        public IActionResult Delete(int id)
        {
            var item = _itemService.GetItemById(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _itemService.DeleteItem(_itemService.GetItemById(id));
            return RedirectToAction(nameof(Index));
        }
    }
}
