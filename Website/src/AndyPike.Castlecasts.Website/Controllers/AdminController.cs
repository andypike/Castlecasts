using System;
using System.Linq;
using AndyPike.Castlecasts.Website.Filters;
using AndyPike.Castlecasts.Website.Models;
using Castle.MonoRail.ActiveRecordSupport;
using Castle.MonoRail.Framework;
using NHibernate.Criterion;

namespace AndyPike.Castlecasts.Website.Controllers
{
    [Filter(ExecuteWhen.BeforeAction, typeof(AuthenticationFilter))]
    public class AdminController : ControllerBase
    {
        public void Dashboard()
        {
            PropertyBag["episodes"] = Episode.FindAll(new Order("CreatedAt", false));
        }

        public void NewEpisode()
        {
            
        }

        public void CreateEpisode([DataBind("episode")] Episode episode, string tags)
        {
            episode.UpdateTags(tags, ' ');
            episode.CreatedAt = DateTime.Now;
            episode.CreatedBy = CurrentUser;
            episode.Save();

            Flash["success"] = "The Castlecast was successfully added.";
            RedirectToAction("Dashboard");
        }

        public void EditEpisode(int id)
        {
            Episode episode = Episode.Find(id);

            PropertyBag["episode"] = episode;
            PropertyBag["tags"] = string.Join(" ", episode.Tags.Select(t => t.Name).ToArray());
        }

        public void UpdateEpisode([ARDataBind("episode", AutoLoadBehavior.Always)] Episode episode, string tags)
        {
            episode.UpdateTags(tags, ' ');
            episode.Save();

            Flash["success"] = "The Castlecast was successfully updated.";
            RedirectToAction("Dashboard");
        }
    }
}