using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TaskManagement.Helper.Session
{
    public class LoginSession
    {
        public static string LoginUser
        {
            get
            {
                return HttpContext.Current.Session["Username"] == null ? "" : (string)HttpContext.Current.Session["Username"];
            }
            set
            {
                HttpContext.Current.Session["Username"] = value;
            }
        }

        public static bool isUserLoggIn
        {
            get
            {
                if (HttpContext.Current.Session["Email"] == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public static string UserRole
        {
            get
            {
                return HttpContext.Current.Session["Role"] == null ? "" : (string)HttpContext.Current.Session["Role"];
            }
            set
            {
                HttpContext.Current.Session["Role"] = value;
            }

        }

        public static void Logout()
        {
            HttpContext.Current.Session.Abandon();
        }
    }
}
