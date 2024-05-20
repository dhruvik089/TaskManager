using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TaskManagement.Common;
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

        public async Task<ActionResult> Student()
        {

            string username = LoginSession.LoginUser;
            int studentId = _context.Students.FirstOrDefault(x => x.Username == username).StudentID;

            List<AssignmentList> TotalTask = new List<AssignmentList>();
            TotalTask = await StudentWebHelper.StudentCallApi(studentId, "ShowTask");

            List<AssignmentList> TotalCompeteTask = new List<AssignmentList>();
            TotalCompeteTask = await StudentWebHelper.StudentCallApi(studentId, "ShowTotalComplete");

            List<AssignmentList> TotalPendingTask = new List<AssignmentList>();
            TotalPendingTask = await StudentWebHelper.StudentCallApi(studentId, "ShowPending");

            List<AssignmentList> TotalExpiredTask = new List<AssignmentList>();
            TotalExpiredTask = await StudentWebHelper.StudentCallApi(studentId, "ShowExpired");

            ViewBag.TotalTask = TotalTask.Count();
            ViewBag.TotalCompeteTask = TotalCompeteTask.Count();
            ViewBag.TotalPendingTask = TotalPendingTask.Count();
            ViewBag.TotalExpiredTask = TotalExpiredTask.Count();

            return View();
        }

        public async Task<ActionResult> ShowTask(int? pageNumber)
        {
            string username = LoginSession.LoginUser;
            int studentId = _context.Students.FirstOrDefault(x => x.Username == username).StudentID;
            List<AssignmentList> _assignments = new List<AssignmentList>();

            _assignments = await StudentWebHelper.StudentCallApi(studentId, "ShowTask");

            TempData["TotalTask"] = _assignments.Count();

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

        public async Task<ActionResult> ShowTotalComplete(int? pageNumber)
        {
            string username = LoginSession.LoginUser;
            int studentId = _context.Students.FirstOrDefault(x => x.Username == username).StudentID;
            List<AssignmentList> _assignments = new List<AssignmentList>();

            _assignments = await StudentWebHelper.StudentCallApi(studentId, "ShowTotalComplete");
            TempData["TotalCompeteTask"] = _assignments.Count();

            int page = pageNumber ?? 1;
            var PaginationList = Pager<AssignmentList>.Pagination(_assignments, page);

            ViewBag.totalCount = Pager<AssignmentList>.totalCount;
            ViewBag.page = Pager<AssignmentList>.page;
            ViewBag.pageSize = Pager<AssignmentList>.pageSize;
            ViewBag.totalPage = Pager<AssignmentList>.totalPage;

            return View(PaginationList);
        }

        public async Task<ActionResult> ShowPending(int? pageNumber)
        {
            string username = LoginSession.LoginUser;
            int studentId = _context.Students.FirstOrDefault(x => x.Username == username).StudentID;

            List<AssignmentList> _assignments = new List<AssignmentList>();

            _assignments = await StudentWebHelper.StudentCallApi(studentId, "ShowPending");
            TempData["TotalPendingTask"] = _assignments.Count();
            int page = pageNumber ?? 1;
            var PaginationList = Pager<AssignmentList>.Pagination(_assignments, page);

            ViewBag.totalCount = Pager<AssignmentList>.totalCount;
            ViewBag.page = Pager<AssignmentList>.page;
            ViewBag.pageSize = Pager<AssignmentList>.pageSize;
            ViewBag.totalPage = Pager<AssignmentList>.totalPage;

            return View(PaginationList);
        }

        public async Task<ActionResult> ShowExpired(int? pageNumber)
        {
            string username = LoginSession.LoginUser;
            int studentId = _context.Students.FirstOrDefault(x => x.Username == username).StudentID;

            List<AssignmentList> _assignments = new List<AssignmentList>();

            _assignments = await StudentWebHelper.StudentCallApi(studentId, "ShowExpired");
            TempData["TotalCompeteTask"] = _assignments.Count();

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