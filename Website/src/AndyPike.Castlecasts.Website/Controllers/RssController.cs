using AndyPike.Castlecasts.Website.Models;

namespace AndyPike.Castlecasts.Website.Controllers
{
    public class RssController : ControllerBase
    {
        public void Episodes()
        {
            Response.ContentType = "application/rss+xml";

            Episode[] episodes = Episode.FindAllLatestFirst();
            PropertyBag["episodes"] = episodes;
            PropertyBag["channelPubDate"] = episodes[0].RssPubDate;

            CancelLayout();
        }
    }
}