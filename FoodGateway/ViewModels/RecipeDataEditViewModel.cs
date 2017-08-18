using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodGateway.Entities;

namespace FoodGateway.ViewModels
{
    public class RecipeDataEditViewModel
    {
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}

