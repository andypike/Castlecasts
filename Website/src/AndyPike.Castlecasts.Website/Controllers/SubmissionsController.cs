using System;
using AndyPike.Castlecasts.Website.Models;
using Castle.MonoRail.Framework;

namespace AndyPike.Castlecasts.Website.Controllers
{
    public class SubmissionsController : ControllerBase
    {
        public void Index()
        {
            
        }

        public void Create([DataBind("submission")]Submission submission)
        {
            submission.CreatedAt = DateTime.Now;
            submission.Status = SubmissionStatus.Submitted;
            submission.Save();

            RedirectToAction("ThankYou");
        }

        public void ThankYou()
        {
            
        }
    }
}