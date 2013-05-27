using System;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Notenet.Security.DataContract;
using Notenet.Web.Desktop.Models;

namespace Notenet.Web.Desktop.Controllers
{
    public class AccountController : Controller
    {
        private static string authDomain;

        static AccountController()
        {
            AccountController.authDomain = ConfigurationManager.AppSettings["DomainToAuthenticate"];
        }

        //
        // GET: /Account/LogOn

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    // FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    this.SetAuthCookie(model.UserName, model.RememberMe);

                    if (returnUrl != null && returnUrl.Length > 1)
                    {
                        return Redirect(returnUrl); // Url.IsLocalUrl(returnUrl) && returnUrl != null && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\")
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult Authenticate()
        {
            if (Request.IsAuthenticated)
            {
                return Json(new NotenetIdentity(this.User.Identity.Name, (Guid)System.Web.Security.Membership.GetUser().ProviderUserKey, NotenetIdentity.AuthType, this.User.Identity.IsAuthenticated), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new NotenetIdentity(this.User.Identity.Name, Guid.Empty, NotenetIdentity.AuthType, this.User.Identity.IsAuthenticated), JsonRequestBehavior.AllowGet);
            }
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            // FormsAuthentication.SignOut();
            HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                cookie.Domain = AccountController.authDomain;
                this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
            }

            return RedirectToAction("LogOn", "Account");
        }

        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus;
                Membership.CreateUser(model.UserName, model.Password, model.Email, null, null, true, null, out createStatus);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    //FormsAuthentication.SetAuthCookie(model.UserName, false /* createPersistentCookie */);
                    this.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePassword

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        private void SetAuthCookie(string userName, bool createPersistentCookie)
        {
            HttpCookie auth = FormsAuthentication.GetAuthCookie(userName, createPersistentCookie /* createPersistentCookie */);
            /*
            string domains = ConfigurationManager.AppSettings["DomainToAuthenticate"];
            foreach (string domain in domains.Split('|'))
            {
                HttpCookie domainAuth = new HttpCookie(auth.Name, auth.Value); //Should implement a clone method later
                domainAuth.Path = auth.Path;
                domainAuth.Domain = domain;
                domainAuth.Expires = auth.Expires;
                domainAuth.Secure = auth.Secure;
                domainAuth.HttpOnly = auth.HttpOnly;
                HttpContext.Response.AppendCookie(domainAuth);
            }
             * */
            auth.Domain = AccountController.authDomain;
            HttpContext.Response.AppendCookie(auth);
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
