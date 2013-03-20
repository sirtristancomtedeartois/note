using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using endnote.Lib;
using System.Web.Security;

namespace endnote.Controllers
{
    public class HomeController : Controller
    {
        private endnoteEntities db = new endnoteEntities();
        Guid userId = Membership.GetUser() != null ? Guid.Parse(Membership.GetUser().ProviderUserKey.ToString()) : Guid.Empty;

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            if (this.userId != Guid.Empty)
            {
                ViewBag.User = db.aspnet_Users.Single(obj => obj.UserId == this.userId);
            }
            else
            {
                ViewBag.User = null;
            }
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
