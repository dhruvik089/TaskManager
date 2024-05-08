using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagement.CustomFilter;
using TaskManagement.Models.DBContext;

namespace TaskManagement.Controllers
{
    //[CustomeAuthorize]
    public class StudentController : Controller
    {
        TaskManagementEntities _context = new TaskManagementEntities();
        public ActionResult Student()
        {
            return View();
        }

        public ActionResult ShowTask()
        {
            
            return View();
        }
    }
}