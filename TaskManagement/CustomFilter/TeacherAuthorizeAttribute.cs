using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskManagement.Helper.Session;

namespace TaskManagement.CustomFilter
{
    public class TeacherAuthorizeAttribute : AuthorizeAttribute
    {

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (LoginSession.UserRole == "Teacher")
            {
                if (LoginSession.LoginUser != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!LoginSession.isUserLoggIn)
            {
                filterContext.Result = new RedirectResult("~/LoginSignup/Login");
            }
            else
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
        }
    }
}