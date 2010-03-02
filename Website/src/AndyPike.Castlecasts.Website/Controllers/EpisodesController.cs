using AndyPike.Castlecasts.Website.Helpers;
using AndyPike.Castlecasts.Website.Models;
using Castle.MonoRail.ActiveRecordSupport;
using Castle.MonoRail.Framework;

namespace AndyPike.Castlecasts.Website.Controllers
{
    [Layout("Default"), Rescue("500")]
    [Helper(typeof(AntiXssHelper), "x")]
    [Helper(typeof(GravatarHelper), "gravatar")]
    public class EpisodesController : ARSmartDispatcherController
    {
        public void Index()
        {
            PropertyBag["episodes"] = Episode.GetLatestEpisodesPaged(1, 10);
        }

        public void Show([ARFetch]Episode episode)
        {
            PropertyBag["episode"] = episode;
        }
    }
}