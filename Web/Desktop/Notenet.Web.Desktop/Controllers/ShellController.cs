using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Notenet.Web.Desktop.Controllers
{
    public class ShellController : Controller
    {
        //
        // GET: /Shell/

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

    }
}
