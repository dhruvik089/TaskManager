using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using TaskManagement.Common;
using TaskManagement.CustomFilter;
using TaskManagement.Helper.Session;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;
using TaskManagement.Repository.Interface.ITaskInterface;
using TaskManagement.Repository.Interface.ITeacherInterface;
using TaskManagement.Repository.Services.TaskServices;
using TaskManagement.Repository.Services.TeacherServices;

namespace TaskManagement.Controllers
{
    [TeacherAuthorize]
    public class TeacherController : Controller
    {
        ITaskInterface _task;
        ITeachersInterface _teacherinterface;
        TaskManagementEntities _context;

        public TeacherController()
        {
            _task = new TaskServices();
            _teacherinterface = new TeacherServices();
            _context = new TaskManagementEntities();
        }

        public async Task<ActionResult> Teacher()
        {
            Teachers _teachers = _context.Teachers.FirstOrDefault(m => m.Username == LoginSession.LoginUser);

            List<TaskList> PendingTask = new List<TaskList>();
            List<TaskList> CompleteTask = new List<TaskList>();
            List<TaskList> TotalTask = new List<TaskList>();
            List<TaskList> TotalAssignTask = new List<TaskList>();
            List<TaskList> TotalExpiredTask = new List<TaskList>();

            PendingTask = await TeacherWebHelper.TeacherCallApi(_teachers.TeacherID, "TotalPendingTask");
            CompleteTask = await TeacherWebHelper.TeacherCallApi(_teachers.TeacherID, "TotalCompleteTask");
            TotalTask = await TeacherWebHelper.TeacherCallApi(_teachers.TeacherID, "TotalCreateTask");
            TotalAssignTask = await TeacherWebHelper.TeacherCallApi(_teachers.TeacherID, "TotalAssignTask");
            TotalExpiredTask = await TeacherWebHelper.TeacherCallApi(_teachers.TeacherID, "TotalExpiredTask");

            ViewBag.PendingTask = PendingTask.Count();
            ViewBag.CompleteTask = CompleteTask.Count();
            ViewBag.TotalTask = TotalTask.Count();
            ViewBag.TotalAssignTask = TotalAssignTask.Count();
            ViewBag.TotalExpiredTask = TotalExpiredTask.Count();

            return View();
        }

        public ActionResult CreateTask()
        {
            Teachers _teachers = _context.Teachers.FirstOrDefault(m => m.Username == LoginSession.LoginUser);
            ViewBag.teacherId = _teachers.TeacherID;

            return View();
        }

        [HttpPost]
        public ActionResult CreateTask(TaskModel _taskModel)
        {
            if (ModelState.IsValid)
            {
                TeacherWebHelper.CreateTask(_taskModel, "CrateTask");
                return RedirectToAction("Teacher");
            }
            else
            {
                return View();
            }
        }

        public async Task<ActionResult> AssignTasks(int id)
        {

            Teachers _teachers = _context.Teachers.FirstOrDefault(m => m.Username == LoginSession.LoginUser);
            ViewBag.TaskID = id;
            Session["TaskID"] = id;
            List<Tasks> tasks = _context.Tasks.Where(m => m.CreatorID == _teachers.TeacherID).ToList();
            List<TaskModel> _taskList = _task.ConvertTaskToTaskModel(tasks);
            ViewBag.AllTask = _taskList;
            List<StudentModel> _studentList = await TeacherWebHelper.NotAssignTask(id, "NotAsignTask");
            Session["AllTask"] = _studentList;
            ViewBag.AllStudent = _studentList;
            return PartialView("AssignTasks", _studentList);
        }

        [HttpPost]
        public async Task<ActionResult> AssignTasks(List<int> StudentID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<AssignmentModel> assignments = new List<AssignmentModel>();

                    foreach (int studentId in StudentID)
                    {
                        AssignmentModel assignment = new AssignmentModel
                        {
                            TaskID = (int?)Session["TaskID"],
                            StudentID = studentId
                        };
                        assignments.Add(assignment);
                    }
                    await TeacherWebHelper.AssignTask(assignments, "AsignTask");
                    return RedirectToAction("Teacher", "Teacher");
                }
                return View();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public ActionResult Logout()
        {
            LoginSession.Logout();
            return RedirectToAction("Login");
        }

        public async Task<ActionResult> TotalCreateTask(int? pageNumber)
        {
            int TeacherID = _context.Teachers.FirstOrDefault(m => m.Username == LoginSession.LoginUser).TeacherID;

            List<TaskList> _TotalTask = new List<TaskList>();
            _TotalTask = await TeacherWebHelper.TeacherCallApi(TeacherID, "TotalCreateTask");

            int page = pageNumber ?? 1;
            var PaginationList = Pager<TaskList>.Pagination(_TotalTask, page);

            ViewBag.totalCount = Pager<TaskList>.totalCount;
            ViewBag.page = Pager<TaskList>.page;
            ViewBag.pageSize = Pager<TaskList>.pageSize;
            ViewBag.totalPage = Pager<TaskList>.totalPage;

            return View(PaginationList);
        }

        public async Task<ActionResult> TotalCompleteTask(int? pageNumber)
        {
            int TeacherID = _context.Teachers.FirstOrDefault(m => m.Username == LoginSession.LoginUser).TeacherID;

            List<TaskList> _TotalTask = new List<TaskList>();
            _TotalTask = await TeacherWebHelper.TeacherCallApi(TeacherID, "TotalCompleteTask");

            int page = pageNumber ?? 1;
            var PaginationList = Pager<TaskList>.Pagination(_TotalTask, page);

            ViewBag.totalCount = Pager<TaskList>.totalCount;
            ViewBag.page = Pager<TaskList>.page;
            ViewBag.pageSize = Pager<TaskList>.pageSize;
            ViewBag.totalPage = Pager<TaskList>.totalPage;

            return View(PaginationList);
        }

        public async Task<ActionResult> TotalPendingTask(int? pageNumber)
        {
            int TeacherID = _context.Teachers.FirstOrDefault(m => m.Username == LoginSession.LoginUser).TeacherID;

            List<TaskList> _TotalTask = new List<TaskList>();
            _TotalTask = await TeacherWebHelper.TeacherCallApi(TeacherID, "TotalPendingTask");

            int page = pageNumber ?? 1;
            var PaginationList = Pager<TaskList>.Pagination(_TotalTask, page);

            ViewBag.totalCount = Pager<TaskList>.totalCount;
            ViewBag.page = Pager<TaskList>.page;
            ViewBag.pageSize = Pager<TaskList>.pageSize;
            ViewBag.totalPage = Pager<TaskList>.totalPage;

            return View(PaginationList);
        }

        public async Task<ActionResult> TotalAssignTask(int? pageNumber)
        {
            int TeacherID = _context.Teachers.FirstOrDefault(m => m.Username == LoginSession.LoginUser).TeacherID;

            List<TaskList> _TotalTask = new List<TaskList>();
            _TotalTask = await TeacherWebHelper.TeacherCallApi(TeacherID, "TotalAssignTask");


            int page = pageNumber ?? 1;
            var PaginationList = Pager<TaskList>.Pagination(_TotalTask, page);

            ViewBag.totalCount = Pager<TaskList>.totalCount;
            ViewBag.page = Pager<TaskList>.page;
            ViewBag.pageSize = Pager<TaskList>.pageSize;
            ViewBag.totalPage = Pager<TaskList>.totalPage;
          

            return View(PaginationList);
        }

        public async Task<ActionResult> TotalExpiredTask(int? pageNumber)
        {
            int TeacherID = _context.Teachers.FirstOrDefault(m => m.Username == LoginSession.LoginUser).TeacherID;

            List<TaskList> _TotalTask = new List<TaskList>();
            _TotalTask = await TeacherWebHelper.TeacherCallApi(TeacherID, "TotalExpiredTask");

            int page = pageNumber ?? 1;
            var PaginationList = Pager<TaskList>.Pagination(_TotalTask, page);

            ViewBag.totalCount = Pager<TaskList>.totalCount;
            ViewBag.page = Pager<TaskList>.page;
            ViewBag.pageSize = Pager<TaskList>.pageSize;
            ViewBag.totalPage = Pager<TaskList>.totalPage;

            return View(PaginationList);
        }

        public async Task<ActionResult> DeleteTask(int id)
        {
            int check = await TeacherWebHelper.DeleteTask(id);
            if (check == 0)
            {
                TempData["deleteTask"] = "Task Delete successfully";
            }
            else
            {
                TempData["notdeleteTask"] = "Task already assign to student so can't delete";
            }
            return RedirectToAction("TotalCreateTask");
        }
    }
}