﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodGateway.Entities
{
    public enum CuisineType
    {
        None,
        Italian,
        French,
        Japanese
    }

    public class Ingredient
    {
        public Guid ID { get; set; }
        public string Code { get; set; }
        [Display(Name="IngName")]
        public string Name { get; set; }
        public decimal Price { get; set; }

        public CuisineType Cuisine { get; set; }
    }
}
