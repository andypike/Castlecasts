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
            PropertyBag["comments"] = Comment.FindAll(new Order("CreatedAt", false));
            PropertyBag["submissions"] = Submission.FindAll(new Order("CreatedAt", false));
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

        public void EditEpisode([ARFetch("id")]Episode episode)
        {
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

        public void DeleteComment([ARFetch("id")]Comment comment)
        {
            comment.Delete();

            Flash["success"] = "The Castlecast was successfully deleted.";
            RedirectToAction("Dashboard");
        }

        public void ViewSubmission([ARFetch("id")]Submission submission)
        {
            PropertyBag["submission"] = submission;
        }

        public void ApproveSubmission([ARFetch("id")]Submission submission)
        {
            submission.Status = SubmissionStatus.Accepted;
            submission.Save();

            Flash["success"] = "The Castlecast was approved.";
            RedirectToAction("Dashboard");
        }

        public void RejectSubmission([ARFetch("id")]Submission submission)
        {
            submission.Status = SubmissionStatus.Rejected;
            submission.Save();

            Flash["success"] = "The Castlecast was rejected.";
            RedirectToAction("Dashboard");
        }
    }
}