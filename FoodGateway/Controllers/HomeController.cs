using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodGateway.Entities;
using FoodGateway.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodGateway.Controllers
{
    public class HomeController : Controller
    {
        private IRecipeData _recipe;

        public HomeController(IRecipeData recipe)
        {
            _recipe = recipe;
        }

        public IActionResult Index()
        {
            return Content("Hello From Home!");
        }

        public IActionResult GetData()
        {
            return this.BadRequest();
        }

        public IActionResult GetObject()
        {
            return this.Json(new { name = "Keith", surname = "Grima" });
        }

        public IActionResult GetIngredient()
        {
            var ingredient = new Ingredient() { ID = 999, Code = "SFR", Name = "Saffron", Price = 7 };
            return new ObjectResult(ingredient);
        }

        public IActionResult GetIngredientView()
        {
            var ingredient = _recipe.GetAll(); //new Ingredient() { ID = 999, Code = "SFR", Name = "Saffron", Price = 7 };
            return View(ingredient);
        }


    }
}
