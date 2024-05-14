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

            return View();
        }

        public ActionResult CreateTask()
        {
            Teachers _teachers = _context.Teachers.FirstOrDefault(m => m.Username == LoginSession.LoginUser);
            ViewBag.teacherId = _teachers.TeacherID;

            //List<Tasks> tasks = _context.Tasks.Where(m => m.CreatorID == _teachers.TeacherID).ToList();
            //List<TaskModel> _taskList = _task.ConvertTaskToTaskModel(tasks);
            //ViewBag.AllTask = _taskList;
            //Session["AllTask"] = _taskList;

            //List<StudentModel> _studentList = _task.NotAsignTask(id);
            //Session["AllStudent"] = _studentList;
            //ViewBag.AllStudent = _studentList;
            return View();
        }
        [HttpPost]
       
        public ActionResult CreateTask(TaskModel _taskModel)
        {
            if (ModelState.IsValid)
            {
                _task.AddTask(_taskModel);
                return RedirectToAction("Teacher");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult AsignTask(int TaskID, List<int> StudentID)
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
                            TaskID = TaskID,
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

        public ActionResult TotalCreateTask()
        {
            Teachers _teachers = _context.Teachers.FirstOrDefault(m => m.Username == LoginSession.LoginUser);
            List<TaskList> _TotalTask = _teacherinterface.TotalCreatTask(_teachers.TeacherID);
            return View(_TotalTask);
        }

        public ActionResult TotalCompleteTask()
        {
            Teachers _teachers = _context.Teachers.FirstOrDefault(m => m.Username == LoginSession.LoginUser);
            List<TaskList> _TotalTask = _teacherinterface.TeacherCompleteTask(_teachers.TeacherID);
            return View(_TotalTask);
        }

        public ActionResult TotalPendingTask()
        {
            Teachers _teachers = _context.Teachers.FirstOrDefault(m => m.Username == LoginSession.LoginUser);
            List<TaskList> _TotalTask = _teacherinterface.TeacherPendingTask(_teachers.TeacherID);
            return View(_TotalTask);
        }

        public ActionResult TotalAssignTask()
        {
            Teachers _teachers = _context.Teachers.FirstOrDefault(m => m.Username == LoginSession.LoginUser);
            List<TaskList> _TotalTask = _teacherinterface.TotalAssignTask(_teachers.TeacherID);
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

        public ActionResult AssignTasks(int id)
        {

            Teachers _teachers = _context.Teachers.FirstOrDefault(m => m.Username == LoginSession.LoginUser);

            List<Tasks> tasks = _context.Tasks.Where(m => m.CreatorID == _teachers.TeacherID).ToList();
            List<TaskModel> _taskList = _task.ConvertTaskToTaskModel(tasks);
            ViewBag.AllTask = _taskList;
            List<StudentModel> _studentList = _task.NotAsignTask(id);
            Session["AllTask"] = _studentList;
            ViewBag.AllStudent = _studentList;
            return PartialView("AssignTasks", _studentList);
        }
    }
}