using System.Security;
using AndyPike.Castlecasts.Website.Models;
using Castle.MonoRail.Framework;

namespace AndyPike.Castlecasts.Website.Controllers
{
    public class SessionsController : ControllerBase
    {
        public void New()
        {
        }

        [AccessibleThrough(Verb.Post)]
        public void Create(string email, string password)
        {
            try
            {
                Session["token"] = User.Authenticate(email, password);

                Flash["success"] = "You have successfully logged in.";
                Redirect("Admin", "Dashboard");
            }
            catch (SecurityException)
            {
                Flash["error"] = "Invalid email or password.";
                RedirectToAction("New");
            }
        }

        public void Logout()
        {
            Session["token"] = null;

            Flash["success"] = "You have successfully logged out.";
            RedirectToAction("New");
        }
    }
}