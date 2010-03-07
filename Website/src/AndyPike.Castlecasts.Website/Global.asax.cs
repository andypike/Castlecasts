using System.IO;
using System.Reflection;
using System.Web;
using AndyPike.Castlecasts.Website.Models;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using Castle.ActiveRecord.Framework.Config;
using Castle.MicroKernel.Registration;
using Castle.MonoRail.Framework.Routing;
using Castle.MonoRail.WindsorExtension;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;

namespace AndyPike.Castlecasts.Website
{
    public class Global : HttpApplication, IContainerAccessor
    {
        protected static IWindsorContainer container;

        public void Application_OnStart()
        {
            InitializeWindsor();
            InitializeActiveRecord();
            PopulateDefaultData();
            RegisterRoutes(RoutingModuleEx.Engine);
        }

        private static void PopulateDefaultData()
        {
            using(new SessionScope())
            {
                User[] users = ActiveRecordBase<User>.FindAll();
                if (users.Length != 0) return;
                
                var defaultUser = new User
                               {
                                   FirstName = "Andy",
                                   LastName = "Pike",
                                   Email = "andy@andypike.com",
                                   PasswordSalt = "a5cdbd8d-b160-4249-b726-034d16f4c762",
                                   PasswordHash = "2F884D20EBE8F4F8CA1BB79DAE1250F5"
                               };
                defaultUser.Save();
            }
        }

        private static void InitializeWindsor()
        {
            container = new WindsorContainer(new XmlInterpreter());

            RegisterFacilities();
            RegisterControllers();
        }

        private static void RegisterFacilities()
        {
            container.AddFacility<MonoRailFacility>();
        }

        private static void RegisterControllers()
        {
            container
                .Register(AllTypes.Pick().FromAssembly(Assembly.GetExecutingAssembly())
                            .Configure(c => c.LifeStyle.Transient)
                            .If(c => c.Name.Contains("Controller")));
        }

        public IWindsorContainer Container
        {
            get { return container; }
        }

        private void InitializeActiveRecord()
        {
            IConfigurationSource config = ActiveRecordSectionHandler.Instance;
            ActiveRecordStarter.Initialize(Assembly.GetExecutingAssembly(), config);

            MigrateDatabase();
        }

        private void MigrateDatabase()
        {
            //Run migrations to keep the db up-to-date.
            //Currently migration files will be run multiple times and errors are 
            //swallowed by AR, need to clean this up
            string migrationsFolder = Server.MapPath("/Migrations");
            string[] migrationFiles = Directory.GetFiles(migrationsFolder, "*.sql");
            foreach (var migrationFile in migrationFiles)
            {
                ActiveRecordStarter.CreateSchemaFromFile(migrationFile);
            }
        }

        private static void RegisterRoutes(IRoutingRuleContainer rules)
        {
            rules.Add(new PatternRoute("root", "/")
                          .DefaultForController().Is("Episodes")
                          .DefaultForAction().Is("Index"));

            rules.Add(new PatternRoute("episodes", "Episodes/<episode>/<action>/<title>")
                          .DefaultForController().Is("Episodes")
                          .Restrict("episode").ValidInteger
                          .DefaultForAction().Is("Index"));

            rules.Add(new PatternRoute("standard", "[controller]/[action]/[id]")
                          .DefaultForController().Is("Episodes")
                          .Restrict("id").ValidInteger
                          .DefaultForAction().Is("Index"));
        }
    }
}