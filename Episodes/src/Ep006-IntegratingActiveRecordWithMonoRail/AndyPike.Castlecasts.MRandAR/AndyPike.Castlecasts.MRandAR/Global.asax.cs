using System.Reflection;
using System.Web;
using AndyPike.Castlecasts.MRandAR.Models;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using Castle.ActiveRecord.Framework.Config;
using Castle.MonoRail.Framework.Routing;

namespace AndyPike.Castlecasts.MRandAR
{
    public class Global : HttpApplication
    {
        public void Application_OnStart()
        {
            InitialiseActiveRecord();
            RegisterRoutes(RoutingModuleEx.Engine);
        }

        private static void InitialiseActiveRecord()
        {
            IConfigurationSource config = ActiveRecordSectionHandler.Instance;
            ActiveRecordStarter.Initialize(Assembly.GetExecutingAssembly(), config);
            ActiveRecordStarter.CreateSchema();

            using (new SessionScope())
            {
                var monorail = new Project {Name = "MonoRail"};
                monorail.Save();

                var windsor = new Project {Name = "Windsor"};
                windsor.Save();

                var activeRecord = new Project {Name = "ActiveRecord"};
                activeRecord.Save();
            }
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
