using Abstractions.Services;
using DataModels;
using Microsoft.AspNetCore.Mvc;

namespace MtnSports.Controllers
{
    public class ItemOrderController : Controller
    {
        IItemOrderService _itemOrderService;

        public ItemOrderController(IItemOrderService itemOrderService)
        {
            _itemOrderService = itemOrderService;
        }

        public IActionResult Index()
        {
            return View(_itemOrderService.GetAllItemOrders());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] ItemOrder itemOrder, string userId)
        {
            if (ModelState.IsValid)
            {
                _itemOrderService.CreateOrder(itemOrder);
                return RedirectToAction("Index", new { userId = userId });
            }
            return View(itemOrder);
        }
    }
}
