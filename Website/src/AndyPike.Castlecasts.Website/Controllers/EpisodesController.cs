using AndyPike.Castlecasts.Website.Models;
using Castle.MonoRail.ActiveRecordSupport;

namespace AndyPike.Castlecasts.Website.Controllers
{
    public class EpisodesController : ControllerBase
    {
        public void Index(int page)
        {
            PropertyBag["episodes"] = Episode.GetLatestEpisodesPaged(page, 10);
        }

        public void Show([ARFetch]Episode episode)
        {
            PropertyBag["episode"] = episode;
        }
    }
}