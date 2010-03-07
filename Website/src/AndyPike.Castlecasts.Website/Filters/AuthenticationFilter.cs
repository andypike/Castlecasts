using System;
using System.Linq;
using AndyPike.Castlecasts.Website.Controllers;
using AndyPike.Castlecasts.Website.Models;
using Castle.ActiveRecord;
using Castle.MonoRail.Framework;

namespace AndyPike.Castlecasts.Website.Filters
{
    public class AuthenticationFilter : IFilter
    {
        public bool Perform(ExecuteWhen exec, IEngineContext context, IController controller, IControllerContext controllerContext)
        {
            var controllerBase = controller as ControllerBase;
            if (controllerBase == null) throw new InvalidOperationException("The controller must derive from ControllerBase to use the AuthenticationFilter.");

            var token = context.Session["token"] as Guid?;
            if(token.HasValue)
            {
                User user = ActiveRecordBase<User>.FindAllByProperty("Token", token).FirstOrDefault();
                if(user != null)
                {
                    controllerBase.CurrentUser = user;
                    controllerBase.PropertyBag["currentUser"] = user;
                    return true;
                }
            }

            context.Flash["notice"] = "You have been logged out due to inactivity.";
            context.Response.Redirect("Sessions", "New");
            return false;
        }
    }
}