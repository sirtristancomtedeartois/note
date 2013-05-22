using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Notenet.Web.Desktop.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to " + User.Identity.Name + " home page!";

            // return PartialView();
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [Authorize]
        public ActionResult Main()
        {
            return View();
        }
    }
}
