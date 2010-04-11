using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using Castle.ActiveRecord.Framework.Config;

namespace AndyPike.Castlecasts.ActiveRecord1
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationSource config = ActiveRecordSectionHandler.Instance;
            ActiveRecordStarter.Initialize(Assembly.GetExecutingAssembly(), config);
            ActiveRecordStarter.CreateSchema();

            using (new SessionScope())
            {
                var monorail = new Project { Name = "MonoRail" };
                monorail.Save();

                var windsor = new Project { Name = "Windsor" };
                windsor.Save();

                var activeRecord = new Project { Name = "ActiveRecord" };
                activeRecord.Save();

                var issue1 = new Issue
                {
                    Summary = "Something went wrong",
                    Description = "blah blah",
                    Project = monorail,
                    Type = IssueType.Bug
                };
                issue1.Save();

                var issue2 = new Issue
                {
                    Summary = "Here is a great idea",
                    Description = "blah blah",
                    Project = windsor,
                    Type = IssueType.NewFeature
                };
                issue2.Save();

                var issue3 = new Issue
                {
                    Summary = "Another thing went wrong",
                    Description = "blah blah",
                    Project = windsor,
                    Type = IssueType.Bug
                };
                issue3.Save();
            }

            using (new SessionScope())
            {
                var mr = Project.Find(1);
                mr.Name = "MonoRail 2.0";
                mr.Save();

                IList<Issue> bugs = Issue.FindAllBugs();
                foreach (var bug in bugs)
                {
                    Console.WriteLine("Bug found: " + bug.Summary + ", in project: " + bug.Project.Name);
                }
            }

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
