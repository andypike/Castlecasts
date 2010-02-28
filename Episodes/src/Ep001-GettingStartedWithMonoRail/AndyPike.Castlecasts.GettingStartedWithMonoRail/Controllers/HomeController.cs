using Castle.MonoRail.Framework;

namespace AndyPike.Castlecasts.GettingStartedWithMonoRail.Controllers
{
    public class HomeController : SmartDispatcherController
    {
        public void Index()
        {
            PropertyBag["messages"] = new[]
                                         {
                                             "Hello everyone!",
                                             "This is my first screencast.",
                                             "Welcome to castlecasts!"
                                         };
        }
    }
}
