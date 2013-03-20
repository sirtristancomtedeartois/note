using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;

namespace Notenet.Authenticate.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string responseContent = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.myxyz.com/Account/IsAuthenticated?userName=sirtristan");

            request.CookieContainer = new CookieContainer();
            for (int i = 0; i < Request.Cookies.Count; i++)
            {
                HttpCookie cookie = Request.Cookies[i];
                Cookie sendCookie = new Cookie(cookie.Name, cookie.Value, cookie.Path, ".myxyz.com"); // Request.Url.Host
                sendCookie.Expires = cookie.Expires;
                sendCookie.Secure = cookie.Secure;
                sendCookie.HttpOnly = cookie.HttpOnly;
                request.CookieContainer.Add(sendCookie);
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                string encoding = response.ContentEncoding;
                if (encoding == null || encoding.Length < 1)
                {
                    encoding = "UTF-8"; //默认编码
                }
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding)))
                {
                    responseContent = reader.ReadToEnd();
                }
            }

            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
