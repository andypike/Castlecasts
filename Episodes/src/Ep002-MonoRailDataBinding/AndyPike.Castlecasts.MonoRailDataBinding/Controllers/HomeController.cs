using System.Collections.Generic;
using Castle.MonoRail.Framework;

namespace AndyPike.Castlecasts.MonoRailDataBinding.Controllers
{
    public class HomeController : SmartDispatcherController
    {
        public void Index(string greeting)
        {
            PropertyBag["greeting"] = greeting;
        }

        public void Index(int number)
        {
            PropertyBag["number"] = number;
        }

        public void Index(int number, string greeting)
        {
            PropertyBag["number"] = number;
            PropertyBag["greeting"] = greeting;
        }

        public void DisplayMessages(List<string> messages)
        {
            PropertyBag["messages"] = messages;
        }

        public void DisplayUser([DataBind("user")]User user)
        {
            PropertyBag["user"] = user;
        }
    }

    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Country> Countries { get; set; }
    }

    public class Country
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}