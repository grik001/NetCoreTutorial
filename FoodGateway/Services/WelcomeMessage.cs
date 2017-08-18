using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace FoodGateway
{
    public interface IWelcomeMessage
    {
        string GetMessage();
    }

    public class WelcomeMessage : IWelcomeMessage
    {
        private string _message;

        public WelcomeMessage(IConfiguration config)
        {
            _message = config["WelcomeMessage"];
        }

        public string GetMessage()
        {
            return _message;
        }
    }
}
