using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodGateway.Entities;

namespace FoodGateway.Services
{
    public interface IRecipeData
    {
        IEnumerable<Ingredient> GetAll();
    }

    public class RecipeDataInMemory : IRecipeData
    {
        List<Ingredient> _ingredients;

        public RecipeDataInMemory()
        {
            _ingredients = new List<Ingredient>();
            _ingredients.Add(new Ingredient { ID = 1, Code = "CHK", Name = "Chicken", Price = 9 });
            _ingredients.Add(new Ingredient { ID = 2, Code = "RDP", Name = "Red Peppers", Price = 3 });
            _ingredients.Add(new Ingredient { ID = 3, Code = "TMT", Name = "Tomatoes", Price = 3 });
            _ingredients.Add(new Ingredient { ID = 4, Code = "PAP", Name = "Paprika", Price = 2 });
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return _ingredients;
        }
    }

    public class RecipeDataFromDatabase : IRecipeData
    {
        public IEnumerable<Ingredient> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
