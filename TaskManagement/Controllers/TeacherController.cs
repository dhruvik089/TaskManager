using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
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

        public ActionResult Teacher()
        {
            Teachers _teachers = _context.Teachers.FirstOrDefault(m => m.Username == LoginSession.LoginUser);

            ViewBag.PendingTask = _teacherinterface.TeacherPendingTask(_teachers.TeacherID).Count();
            ViewBag.CompleteTask = _teacherinterface.TeacherCompleteTask(_teachers.TeacherID).Count();
            ViewBag.TotalTask = _teacherinterface.TotalCreatTask(_teachers.TeacherID).Count();
            ViewBag.TotalAssignTask = _teacherinterface.TotalAssignTask(_teachers.TeacherID).Count();
            ViewBag.TotalExpiredTask = _teacherinterface.TotalExpiredTask(_teachers.TeacherID).Count();

            return View();
        }

        public ActionResult CreateTask()
        {
            Teachers _teachers = _context.Teachers.FirstOrDefault(m => m.Username == LoginSession.LoginUser);
            ViewBag.teacherId = _teachers.TeacherID;

            return View();
        }
        [HttpPost]

        public ActionResult CreateTask(TaskModel _taskModel, int TaskID)
        {
            if (ModelState.IsValid)
            {
                _task.AddTask(_taskModel);
                Session["TaskID"] = TaskID;
                return RedirectToAction("Teacher");
            }
            else
            {
                return View();
            }
        }


        public ActionResult AssignTasks(int id)
        {

            Teachers _teachers = _context.Teachers.FirstOrDefault(m => m.Username == LoginSession.LoginUser);
            ViewBag.TaskID = id;
            Session["TaskID"] = id;
            List<Tasks> tasks = _context.Tasks.Where(m => m.CreatorID == _teachers.TeacherID).ToList();
            List<TaskModel> _taskList = _task.ConvertTaskToTaskModel(tasks);
            ViewBag.AllTask = _taskList;
            List<StudentModel> _studentList = _task.NotAsignTask(id);
            Session["AllTask"] = _studentList;
            ViewBag.AllStudent = _studentList;
            return PartialView("AssignTasks", _studentList);
        }

        [HttpPost]
        public ActionResult AssignTasks(List<int> StudentID)
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

                    _teacherinterface.AssignAssignment(assignments);
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

        public ActionResult TotalCreateTask(int? pageNumber)
        {
            Teachers _teachers = _context.Teachers.FirstOrDefault(m => m.Username == LoginSession.LoginUser);
            List<TaskList> _TotalTask = _teacherinterface.TotalCreatTask(_teachers.TeacherID);

            int page = pageNumber ?? 1;
            var PaginationList = Pager<TaskList>.Pagination(_TotalTask, page);

            ViewBag.totalCount = Pager<TaskList>.totalCount;
            ViewBag.page = Pager<TaskList>.page;
            ViewBag.pageSize = Pager<TaskList>.pageSize;
            ViewBag.totalPage = Pager<TaskList>.totalPage;

            return View(_TotalTask);
        }

        public ActionResult TotalCompleteTask(int? pageNumber)
        {
            Teachers _teachers = _context.Teachers.FirstOrDefault(m => m.Username == LoginSession.LoginUser);
            List<TaskList> _TotalTask = _teacherinterface.TeacherCompleteTask(_teachers.TeacherID);

            int page = pageNumber ?? 1;
            var PaginationList = Pager<TaskList>.Pagination(_TotalTask, page);

            ViewBag.totalCount = Pager<TaskList>.totalCount;
            ViewBag.page = Pager<TaskList>.page;
            ViewBag.pageSize = Pager<TaskList>.pageSize;
            ViewBag.totalPage = Pager<TaskList>.totalPage;

            return View(PaginationList);
        }

        public ActionResult TotalPendingTask(int? pageNumber)
        {
            Teachers _teachers = _context.Teachers.FirstOrDefault(m => m.Username == LoginSession.LoginUser);
            List<TaskList> _TotalTask = _teacherinterface.TeacherPendingTask(_teachers.TeacherID);


            int page = pageNumber ?? 1;
            var PaginationList = Pager<TaskList>.Pagination(_TotalTask, page);

            ViewBag.totalCount = Pager<TaskList>.totalCount;
            ViewBag.page = Pager<TaskList>.page;
            ViewBag.pageSize = Pager<TaskList>.pageSize;
            ViewBag.totalPage = Pager<TaskList>.totalPage;

            return View(_TotalTask);
        }

        public ActionResult TotalAssignTask(int? pageNumber)
        {
            Teachers _teachers = _context.Teachers.FirstOrDefault(m => m.Username == LoginSession.LoginUser);
            List<TaskList> _TotalTask = _teacherinterface.TotalAssignTask(_teachers.TeacherID);


            int page = pageNumber ?? 1;
            var PaginationList = Pager<TaskList>.Pagination(_TotalTask, page);

            ViewBag.totalCount = Pager<TaskList>.totalCount;
            ViewBag.page = Pager<TaskList>.page;
            ViewBag.pageSize = Pager<TaskList>.pageSize;
            ViewBag.totalPage = Pager<TaskList>.totalPage;

            return View(_TotalTask);
        }
        public ActionResult TotalExpiredTask(int? pageNumber)
        {
            Teachers _teachers = _context.Teachers.FirstOrDefault(m => m.Username == LoginSession.LoginUser);
            List<TaskList> _TotalTask = _teacherinterface.TotalExpiredTask(_teachers.TeacherID);


            int page = pageNumber ?? 1;
            var PaginationList = Pager<TaskList>.Pagination(_TotalTask, page);

            ViewBag.totalCount = Pager<TaskList>.totalCount;
            ViewBag.page = Pager<TaskList>.page;
            ViewBag.pageSize = Pager<TaskList>.pageSize;
            ViewBag.totalPage = Pager<TaskList>.totalPage;

            return View(_TotalTask);
        }

        public ActionResult DeleteTask(int id)
        {
            if (_teacherinterface.DeleteTask(id))
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