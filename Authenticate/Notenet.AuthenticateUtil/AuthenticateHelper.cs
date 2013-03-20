using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Notenet.AuthenticateUtil
{
    public class AuthenticateHelper
    {
        public static void Authenticate(string cookie, string authenticateUri, Action logon)
        {
            string responseContent = null;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(authenticateUri);
            request.Headers.Add(HttpRequestHeader.Cookie, cookie);
            /*
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
             * */
            try
            {
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
            }
            catch (Exception e)
            {
                // should log e chuan
            }

            if (!(responseContent != null && responseContent.CompareTo("true") == 0))
            {
                logon();
            }
        }
    }
}
