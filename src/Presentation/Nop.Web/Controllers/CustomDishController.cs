using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.CustomDish;
using Nop.Services.CustomDish;
using System.Collections.Generic;

namespace Nop.Web.Controllers
{
    public class CustomDishController : Controller
    {
        private readonly ICustomDishService _customDishService;

        public CustomDishController(ICustomDishService customDishService)
        {
            _customDishService = customDishService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var ingredients = _customDishService.GetAllIngredients();
            return View(ingredients);
        }

        [HttpPost]
        public IActionResult CreateDish(string name, List<int> ingredientIds)
        {
            var dish = _customDishService.CreateDish(name, ingredientIds);
            return RedirectToAction("Cart");
        }

        [HttpGet]
        public IActionResult Cart()
        {
            return View(); // Hiển thị danh sách món ăn đã chọn
        }
    }
}
