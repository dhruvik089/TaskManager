using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskManagement.Helper.Helper.StudentHelper;
using TaskManagement.Helper.Helper.TeacherHelper;
using TaskManagement.Helper.Session;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;

namespace TaskManagement.CustomFilter
{

    public class StudentAuthorizeAttribute : AuthorizeAttribute
    {

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
           if (LoginSession.UserRole == "Student")
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