using System.Web;
using Castle.MonoRail.Framework.Routing;

namespace AndyPike.Castlecasts.Website
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
                          .DefaultForController().Is("Episodes")
                          .DefaultForAction().Is("Index"));

            rules.Add(new PatternRoute("standard", "[controller]/[id]/[action]")
                          .DefaultForController().Is("Episodes")
                          .Restrict("id").ValidInteger
                          .DefaultForAction().Is("Index"));
        }
    }
}