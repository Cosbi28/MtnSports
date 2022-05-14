using Abstractions.Services;
using DataModels;
using Microsoft.AspNetCore.Mvc;
using MtnSports.Models;
using System.Diagnostics;

namespace MtnSports.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemService _itemService;

        public HomeController(ILogger<HomeController> logger, IItemService itemService)
        {
            _logger = logger;
            _itemService = itemService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost] 
        public IActionResult Search([FromForm]SearchViewModel search)
        {
            if(ModelState.IsValid)
            {
                
                return RedirectToAction("Results","Item",search);
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}