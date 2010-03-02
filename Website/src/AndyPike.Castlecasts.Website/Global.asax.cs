using System;
using System.Collections.Generic;
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
                var andy = new User
                               {
                                   FirstName = "Andy",
                                   LastName = "Pike",
                                   TwitterName = "andypike",
                                   Email = "andy@andypike.com"
                               };
                andy.Save();

                var ep1 = new Episode
                              {
                                  CreatedAt = DateTime.UtcNow,
                                  CreatedBy = andy,
                                  Title = "Getting started with MonoRail",
                                  Description = "Shows how to create your first Castle MonoRail application. Takes you through from downloading the required assemblies, creating a project, configuration and getting your first page showing in the browser.",
                                  MovieHTML = "<object width='640' height='480'><param name='allowfullscreen' value='true' /><param name='allowscriptaccess' value='always' /><param name='movie' value='http://vimeo.com/moogaloop.swf?clip_id=9802683&amp;server=vimeo.com&amp;show_title=1&amp;show_byline=1&amp;show_portrait=0&amp;color=00ADEF&amp;fullscreen=1' /><embed src='http://vimeo.com/moogaloop.swf?clip_id=9802683&amp;server=vimeo.com&amp;show_title=1&amp;show_byline=1&amp;show_portrait=0&amp;color=00ADEF&amp;fullscreen=1' type='application/x-shockwave-flash' allowfullscreen='true' allowscriptaccess='always' width='640' height='480'></embed></object>",
                                  Level = DifficultyLevel.Beginner,
                                  Tags = new List<Tag>
                                             {
                                                 new Tag{ Name = "MonoRail" }
                                             },
                                  Links = new List<Link>
                                             {
                                                 new Link{ Text = "Download Episode 1024x768 (52.24MB)", Url = "http://vimeo.com/download/video:16626583?v=2&e=1267492075&h=38072b1955b6b902631c60f9ef45508f&uh=a5175021d3ea5f2d2a373176f6c730af"},
                                                 new Link{ Text = "Episode Source", Url = "http://github.com/andypike/Castlecasts/tree/master/Episodes/src/Ep001-GettingStartedWithMonoRail/AndyPike.Castlecasts.GettingStartedWithMonoRail/" },
                                                 new Link{ Text = "MonoRail 2.0 Download", Url = "http://sourceforge.net/projects/castleproject/files/MonoRail/2.0/" },
                                                 new Link{ Text = "CastleProject Home", Url = "http://castleproject.org" }
                                             }
                              };
                ep1.Save();
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

        private static void InitializeActiveRecord()
        {
            IConfigurationSource config = ActiveRecordSectionHandler.Instance;

            ActiveRecordStarter.Initialize(Assembly.GetExecutingAssembly(), config);
            ActiveRecordStarter.CreateSchema();
        }

        private static void RegisterRoutes(IRoutingRuleContainer rules)
        {
            rules.Add(new PatternRoute("root", "/")
                          .DefaultForController().Is("Episodes")
                          .DefaultForAction().Is("Index"));

            rules.Add(new PatternRoute("episodes", "<controller>/<episode>/<action>")
                          .DefaultForController().Is("Episodes")
                          .Restrict("episode").ValidInteger
                          .DefaultForAction().Is("Index"));

            rules.Add(new PatternRoute("standard", "[controller]/[id]/[action]")
                          .DefaultForController().Is("Episodes")
                          .Restrict("id").ValidInteger
                          .DefaultForAction().Is("Index"));
        }
    }
}