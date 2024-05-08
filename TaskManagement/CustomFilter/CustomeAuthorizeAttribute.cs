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

    public class CustomeAuthorizeAttribute : AuthorizeAttribute
    {
        //TaskManagementEntities _context = new TaskManagementEntities();

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            //RegisterDetailsModel _registerDetailsModel = new RegisterDetailsModel();
            if (LoginSession.UserRole == "Teacher")
            {
                //Teachers _teachers = TeacherHelper.ConvertRegisterDetailsModelToTeacherContext(_registerDetailsModel);
                //_teachers = _context.Teachers.FirstOrDefault(m => m.Username == LoginSession.LoginUser);
                if (LoginSession.LoginUser != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (LoginSession.UserRole == "Student")
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
                // Not access Other page without login using forbidden
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
        }
    }
}