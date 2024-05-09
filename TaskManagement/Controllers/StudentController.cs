using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagement.CustomFilter;
using TaskManagement.Helper.Session;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;
using TaskManagement.Repository.Interface.ITaskInterface;
using TaskManagement.Repository.Services.TaskServices;

namespace TaskManagement.Controllers
{
    [CustomeAuthorize]
    public class StudentController : Controller
    {
        TaskManagementEntities _context = new TaskManagementEntities();
        ITaskInterface _task = new TaskServices();

        public ActionResult Student()
        {
            return View();
        }

        public ActionResult ShowTask()
        {
            string username = LoginSession.LoginUser;
            int studentId =_context.Students.FirstOrDefault(x => x.Username == username).StudentID;
            List<TaskModel> _assignments = _task.GetAssignmentTasks(studentId);            
            return View(_assignments);
        }
    }
}