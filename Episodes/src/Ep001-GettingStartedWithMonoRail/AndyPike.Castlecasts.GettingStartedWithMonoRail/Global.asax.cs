using System.Web;
using Castle.MonoRail.Framework.Routing;

namespace AndyPike.Castlecasts.GettingStartedWithMonoRail
{
    public class Global : HttpApplication
    {
        public void Application_OnStart()
        {
            RegisterRoutes(RoutingModuleEx.Engine);
        }

        private static void RegisterRoutes(IRoutingRuleContainer rules)
        {
            rules.Add(new PatternRoute("root", "/")
                          .DefaultForController().Is("Home")
                          .DefaultForAction().Is("Index"));

            rules.Add(new PatternRoute("standard", "[controller]/[action]/[id]")
                          .DefaultForController().Is("Home")
                          .DefaultForAction().Is("Index"));
        }
    }
}