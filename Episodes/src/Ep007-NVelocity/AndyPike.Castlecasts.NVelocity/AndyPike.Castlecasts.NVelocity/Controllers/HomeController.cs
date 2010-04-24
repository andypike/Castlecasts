using System;
using AndyPike.Castlecasts.NVelocity.Models;
using Castle.MonoRail.Framework;
using NHibernate.Criterion;

namespace AndyPike.Castlecasts.NVelocity.Controllers
{
    [Layout("Default"), Rescue("Default")]
    public class HomeController : SmartDispatcherController
    {
        public void Index()
        {
            PropertyBag["issues"] = Issue.FindAll(new Order("Id", false));
        }
    }
}