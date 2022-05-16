using Abstractions.Services;
using DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MtnSports.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index(string userId)
        {
            return View(_orderService.GetUserOrders(userId));
        }

        public IActionResult Details(int id)
        {
            var item = _orderService.GetOrderById(id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Order order, string userId)
        {
            if (ModelState.IsValid)
            {
                _orderService.CreateOrder(order);
                return RedirectToAction("Index", new { userId = userId });
            }
            return View(order);
        }

        public IActionResult Edit(int id)
        {
            var item = _orderService.GetOrderById(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id, IdUser, PickupDate, ReturnDate, TotalPrice")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _orderService.UpdateOrder(order);
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        public IActionResult Delete(int id)
        {
            var item = _orderService.GetOrderById(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id, string userId)
        {
            _orderService.DeleteOrder(_orderService.GetOrderById(id));
            return RedirectToAction("Index", new { userId = userId });
        }

        public IActionResult Return(int id)
        {
            var item = _orderService.GetOrderById(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost, ActionName("Return")]
        [ValidateAntiForgeryToken]
        public IActionResult ReturnConfirmed(int id, string userId)
        {
            _orderService.ReturnOrder(_orderService.GetOrderById(id));
            return RedirectToAction("Index", new { userId = userId });
        }
    }
}

