using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodGateway.Entities;

namespace FoodGateway.Services
{
    public interface IIngredientData
    {
        IEnumerable<Ingredient> GetAll();
        Ingredient Get(Guid id);
        Ingredient Add(Ingredient ingredient);
    }

    public class IngredientDataInMemory : IIngredientData
    {
        static List<Ingredient> _ingredients;

        static IngredientDataInMemory()
        {
            _ingredients = new List<Ingredient>();
            _ingredients.Add(new Ingredient { ID = Guid.NewGuid(), Code = "CHK", Name = "Chicken", Price = 9 });
            _ingredients.Add(new Ingredient { ID = Guid.NewGuid(), Code = "RDP", Name = "Red Peppers", Price = 3 });
            _ingredients.Add(new Ingredient { ID = Guid.NewGuid(), Code = "TMT", Name = "Tomatoes", Price = 3 });
            _ingredients.Add(new Ingredient { ID = Guid.NewGuid(), Code = "PAP", Name = "Paprika", Price = 2 });
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return _ingredients;
        }

        public Ingredient Get(Guid id)
        {
            return _ingredients.FirstOrDefault(x => x.ID == id);
        }

        public Ingredient Add(Ingredient ingredient)
        {
            ingredient.ID = Guid.NewGuid();
            ingredient.Code = ingredient.Name;
            _ingredients.Add(ingredient);
            return ingredient;
        }
    }

    public class IngredientDataFromDatabase : IIngredientData
    {
        public Ingredient Add(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }

        public Ingredient Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ingredient> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
