using System;
using AndyPike.Castlecasts.MRandAR.Models;
using Castle.MonoRail.ActiveRecordSupport;
using Castle.MonoRail.Framework;

namespace AndyPike.Castlecasts.MRandAR.Controllers
{
    public class IssuesController : ARSmartDispatcherController
    {
        public void New()
        {
            PropertyBag["projects"] = Project.FindAll();
            PropertyBag["types"] = Enum.GetNames(typeof(IssueType));
        }

        public void Create([DataBind("issue")]Issue issue)
        {
            issue.Save();

            Redirect("Home", "Index");
        }

        public void Edit([ARFetch("id")]Issue issue)
        {
            PropertyBag["issue"] = issue;
            PropertyBag["projects"] = Project.FindAll();
            PropertyBag["types"] = Enum.GetNames(typeof(IssueType));
        }

        public void Update([ARDataBind("issue", AutoLoadBehavior.Always)]Issue issue)
        {
            issue.Save();

            Redirect("Home", "Index");
        }
    }
}