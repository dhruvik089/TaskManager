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
    [StudentAuthorize]
    public class StudentController : Controller
    {
        TaskManagementEntities _context = new TaskManagementEntities();
        ITaskInterface _task = new TaskServices();

        public ActionResult Student()
        {

            string username = LoginSession.LoginUser;
            int studentId = _context.Students.FirstOrDefault(x => x.Username == username).StudentID;

            ViewBag.TotalTask = _task.TotalTask(studentId).Count();
            ViewBag.TotalCompeteTask = _task.CompleteTask(studentId).Count();
            ViewBag.TotalPendingTask = _task.PendingTask(studentId).Count();

            //Session["TotalTask"] = _task.TotalTask(studentId);
            //Session["TotalCompeteTask"] = _task.CompleteTask(studentId);
            //Session["TotalPendingTask"] = _task.PendingTask(studentId);

            return View();
        }

        public ActionResult ShowTask()
        {
            string username = LoginSession.LoginUser;
            int studentId = _context.Students.FirstOrDefault(x => x.Username == username).StudentID;
            List<AssignmentList> _assignments = _task.GetAssignmentTasks(studentId);

            return View(_assignments);
        }

        public ActionResult SetAssignmentStatus(int id)
        {
            bool setStatus = _task.AssignmentStatus(id);

            if (setStatus)
            {
                return RedirectToAction("ShowTask", "Student");
            }

            return RedirectToAction("ShowTask");
        }

        public ActionResult Logout()
        {
            LoginSession.Logout();
            return RedirectToAction("Login");
        }

        public ActionResult ShowTotalComplete()
        {
            string username = LoginSession.LoginUser;
            int studentId = _context.Students.FirstOrDefault(x => x.Username == username).StudentID;
            List<AssignmentList> _completeTask=_task.CompleteTask(studentId);
            return View(_completeTask);
        }

        public ActionResult ShowPending()
        {
            string username = LoginSession.LoginUser;
            int studentId = _context.Students.FirstOrDefault(x => x.Username == username).StudentID;
            List<AssignmentList> _pendingtask = _task.PendingTask(studentId);
            return View(_pendingtask);
        }
    }
}