using AndyPike.Castlecasts.MRandAR.Models;
using Castle.MonoRail.Framework;
using NHibernate.Criterion;

namespace AndyPike.Castlecasts.MRandAR.Controllers
{
    public class HomeController : SmartDispatcherController
    {
        public void Index()
        {
            PropertyBag["issues"] = Issue.FindAll(new Order("Id", false));
        }
    }
}