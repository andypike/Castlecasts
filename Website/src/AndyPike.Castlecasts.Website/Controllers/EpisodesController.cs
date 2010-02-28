using AndyPike.Castlecasts.Website.Helpers;
using Castle.MonoRail.ActiveRecordSupport;
using Castle.MonoRail.Framework;

namespace AndyPike.Castlecasts.Website.Controllers
{
    [Layout("Default"), Rescue("500"), Helper(typeof(AntiXssHelper), "x")]
    public class EpisodesController : ARSmartDispatcherController
    {
        public void Index()
        {
            
        }

        public void Show(int id)
        {
            
        }
    }
}