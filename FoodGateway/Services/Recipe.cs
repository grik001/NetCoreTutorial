using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace FoodGateway
{
    public interface IRecipe
    {
        string GetRecipe();
    }

    public class Recipe : IRecipe
    {
        private string _recipe;

        public Recipe(IConfiguration config)
        {
            _recipe = config["Recipe"];
        }

        public string GetRecipe()
        {
            return _recipe;
        }
    }
}
