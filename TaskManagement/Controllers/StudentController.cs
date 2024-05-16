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
            ViewBag.TotalExpiredTask = _task.ExpiredTask(studentId).Count();

            return View();
        }

        public ActionResult ShowTask(int? pageNumber)
        {
            string username = LoginSession.LoginUser;
            int studentId = _context.Students.FirstOrDefault(x => x.Username == username).StudentID;
            List<AssignmentList> _assignments = _task.GetAssignmentTasks(studentId);

            int page = pageNumber ?? 1;
            var PaginationList = Pager<AssignmentList>.Pagination(_assignments, page);

            ViewBag.totalCount = Pager<AssignmentList>.totalCount;
            ViewBag.page = Pager<AssignmentList>.page;
            ViewBag.pageSize = Pager<AssignmentList>.pageSize;
            ViewBag.totalPage = Pager<AssignmentList>.totalPage;

            return View(PaginationList);
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

        public ActionResult ShowTotalComplete(int? pageNumber)
        {
            string username = LoginSession.LoginUser;
            int studentId = _context.Students.FirstOrDefault(x => x.Username == username).StudentID;
            List<AssignmentList> _assignments = _task.CompleteTask(studentId);

            int page = pageNumber ?? 1;
            var PaginationList = Pager<AssignmentList>.Pagination(_assignments, page);

            ViewBag.totalCount = Pager<AssignmentList>.totalCount;
            ViewBag.page = Pager<AssignmentList>.page;
            ViewBag.pageSize = Pager<AssignmentList>.pageSize;
            ViewBag.totalPage = Pager<AssignmentList>.totalPage;

            return View(PaginationList);
        }

        public ActionResult ShowPending(int? pageNumber)
        {
            string username = LoginSession.LoginUser;
            int studentId = _context.Students.FirstOrDefault(x => x.Username == username).StudentID;
            List<AssignmentList> _assignments = _task.PendingTask(studentId);

            int page = pageNumber ?? 1;
            var PaginationList = Pager<AssignmentList>.Pagination(_assignments, page);

            ViewBag.totalCount = Pager<AssignmentList>.totalCount;
            ViewBag.page = Pager<AssignmentList>.page;
            ViewBag.pageSize = Pager<AssignmentList>.pageSize;
            ViewBag.totalPage = Pager<AssignmentList>.totalPage;

            return View(PaginationList);
        }

        public ActionResult ShowExpired(int? pageNumber)
        {
            string username = LoginSession.LoginUser;
            int studentId = _context.Students.FirstOrDefault(x => x.Username == username).StudentID;
            List<AssignmentList> _assignments = _task.ExpiredTask(studentId);

            int page = pageNumber ?? 1;
            var PaginationList = Pager<AssignmentList>.Pagination(_assignments, page);

            ViewBag.totalCount = Pager<AssignmentList>.totalCount;
            ViewBag.page = Pager<AssignmentList>.page;
            ViewBag.pageSize = Pager<AssignmentList>.pageSize;
            ViewBag.totalPage = Pager<AssignmentList>.totalPage;

            return View(PaginationList);
        }
    }
}