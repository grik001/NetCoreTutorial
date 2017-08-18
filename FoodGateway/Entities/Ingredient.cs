using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodGateway.Entities
{
    public class Ingredient
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
