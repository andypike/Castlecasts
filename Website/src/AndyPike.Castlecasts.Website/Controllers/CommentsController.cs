using System;
using System.Collections.Generic;
using AndyPike.Castlecasts.Website.Models;
using Castle.MonoRail.ActiveRecordSupport;
using Castle.MonoRail.Framework;

namespace AndyPike.Castlecasts.Website.Controllers
{
    public class CommentsController : ControllerBase
    {
        [AccessibleThrough(Verb.Post)]
        public void Create([ARDataBind("comment", AutoLoadBehavior.OnlyNested)]Comment comment)
        {
            comment.CreatedAt = DateTime.Now;
            comment.Save();
            
            var routeParams = new Dictionary<string, object>
                                  {
                                      {"action", "Show"},
                                      {"episode", comment.Episode.Id},
                                      {"title", comment.Episode.SeoTitle}
                                  };

            RedirectUsingNamedRoute("episodes", routeParams);
        }
    }
}
