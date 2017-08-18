using Microsoft.AspNetCore.Mvc;

namespace FoodGateway.Controllers
{
    [Route("v1/[controller]/[action]")]
    public class AboutController
    {
        public string Phone()
        {
            return "+3569911002233";
        }
            
        public string Address()
        {
            return "2 Cardboard Box, Subway Lane 3";
        }
    }
}
