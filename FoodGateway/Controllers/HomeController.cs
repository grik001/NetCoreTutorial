using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodGateway.Entities;
using FoodGateway.Services;
using FoodGateway.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodGateway.Controllers
{
    public class HomeController : Controller
    {
        private IIngredientData _recipe;
        private IWelcomeMessage _welcome;

        public HomeController(IIngredientData recipe, IWelcomeMessage welcome)
        {
            _recipe = recipe;
            _welcome = welcome;
        }

        public IActionResult Index()
        {
            HomePageViewModel model = new HomePageViewModel();
            model.CurrentMessage = _welcome.GetMessage();
            model.Ingredients = _recipe.GetAll();
            return View(model);
        }

        public IActionResult Details(Guid id)
        {
            var Ingredient = _recipe.Get(id);

            if (Ingredient == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(Ingredient);
            }
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
            var ingredient = new Ingredient() { ID = Guid.NewGuid(), Code = "SFR", Name = "Saffron", Price = 7 };
            return new ObjectResult(ingredient);
        }

        public IActionResult GetIngredientView()
        {
            var ingredient = _recipe.GetAll(); //new Ingredient() { ID = 999, Code = "SFR", Name = "Saffron", Price = 7 };
            return View(ingredient);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Create(RecipeDataEditViewModel model)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.Name = model.Name;
            ingredient.Cuisine = model.Cuisine;

            ingredient = _recipe.Add(ingredient);
            return RedirectToAction("Details", new { id = ingredient.ID });
        }
    }
}
