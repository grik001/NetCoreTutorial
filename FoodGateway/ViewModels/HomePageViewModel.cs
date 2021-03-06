﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodGateway.Entities;

namespace FoodGateway.ViewModels
{
    public class HomePageViewModel
    {
        public string CurrentMessage { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
    }
}

