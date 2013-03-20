using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using Notenet.Security.DataContract;

namespace Notenet.Security
{
    public class AuthenticationModule : IHttpModule
    {
        public static string authCookieName = ".ASPXAUTH";

        public static string authSuperDomain;

        private static string authenticateURL;

        private HttpApplication app = null;

        static AuthenticationModule()
        {
            AuthenticationModule.authSuperDomain = ConfigurationManager.AppSettings["AuthSuperDomain"];
            AuthenticationModule.authenticateURL = ConfigurationManager.AppSettings["AuthenticateUrl"];
        }

        /// <summary>
        /// Initializes the module derived from IHttpModule when called by the HttpRuntime . 
        /// </summary>
        /// <param name="httpapp">The HttpApplication module</param>
        public void Init(HttpApplication httpapp)
        {
            this.app = httpapp;
            app.AuthenticateRequest += new EventHandler(this.OnAuthenticate);
        }

        private void OnAuthenticate(object sender, EventArgs e)
        {
            NotenetIdentity identity = null;

            app = (HttpApplication)sender;
            HttpRequest request = app.Request;
            HttpResponse response = app.Response;
            HttpCookie authCookie = request.Cookies[AuthenticationModule.authCookieName];
            if (authCookie != null)
            {
                // see if can get from session state
                if (HttpRuntime.Cache[authCookie.Value] == null)
                {
                    HttpWebRequest authRequest = (HttpWebRequest)WebRequest.Create(AuthenticationModule.authenticateURL);
                    authRequest.CookieContainer = new CookieContainer();
                    Cookie sendCookie = new Cookie(authCookie.Name, authCookie.Value, authCookie.Path, AuthenticationModule.authSuperDomain); // Request.Url.Host
                    sendCookie.Expires = authCookie.Expires;
                    sendCookie.Secure = authCookie.Secure;
                    sendCookie.HttpOnly = authCookie.HttpOnly;
                    authRequest.CookieContainer.Add(sendCookie);

                    try
                    {
                        using (HttpWebResponse authResponse = (HttpWebResponse)authRequest.GetResponse())
                        {
                            string encoding = authResponse.ContentEncoding;
                            if (encoding == null || encoding.Length < 1)
                            {
                                encoding = "UTF-8"; //默认编码
                            }

                            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(NotenetIdentity));
                            using (Stream stream = authResponse.GetResponseStream())
                            {
                                identity = jsonSerializer.ReadObject(stream) as NotenetIdentity;
                                HttpRuntime.Cache[authCookie.Value] = identity;
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        // should log e chuan
                    }
                }
                else
                {
                    identity = HttpRuntime.Cache[authCookie.Value] as NotenetIdentity;
                    if (identity == null)
                    {
                        identity = new NotenetIdentity(string.Empty, Guid.Empty, NotenetIdentity.AuthType, false);
                    }
                }
            }
            else
            {
                identity = new NotenetIdentity(string.Empty, Guid.Empty, NotenetIdentity.AuthType, false);
            }

            GenericPrincipal principal = new GenericPrincipal(identity, null);
            app.Context.User = principal;
            Thread.CurrentPrincipal = principal;
        }

        //public static void LogOn(HttpRequest request, HttpResponse response)
        //{
        //    response.StatusCode = 302;
        //    response.RedirectLocation = String.Format(AuthenticationModule.logonURL,
        //        request.Url.Scheme,
        //        request.Url.Authority,
        //        request.Url.PathAndQuery.Remove(request.Url.Segments[0].Length, request.Url.Segments[1].Length));
        //}

        public void Dispose()
        {
        }
    }
}
