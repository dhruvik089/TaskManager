using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TaskManagement.CustomFilter;
using TaskManagement.Helper.Helper.StudentHelper;
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
        ITaskInterface _task = new TaskServices();
        ITeachersInterface _teacherinterface = new TeacherServices();
        TaskManagementEntities _context = new TaskManagementEntities();

        public ActionResult Teacher()
        {
            Teachers _teachers = _context.Teachers.FirstOrDefault(m => m.Username == LoginSession.LoginUser);

            ViewBag.PendingTask = _teacherinterface.TeacherPendingTask(_teachers.TeacherID);
            ViewBag.CompleteTask = _teacherinterface.TeacherCompleteTask(_teachers.TeacherID);
            ViewBag.TotalTask = _teacherinterface.TotalCreatTask(_teachers.TeacherID);
            ViewBag.TotalAssignTask = _teacherinterface.TotalAssignTask(_teachers.TeacherID);

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
                _task.AddTask(_taskModel);
                return RedirectToAction("Teacher");
            }
            else
            {
                return View();
            }
        }

        public ActionResult AsignTask()
        {
            List<Students> _students = _context.Students.ToList();
            List<StudentModel> _studentModelList = StudentHelper.ConvertStudentListToStudentModelList(_students);
            //ViewBag.AllStudent = _studentModelList;
            Session["AllTask"] = _studentModelList;

            Teachers _teachers = _context.Teachers.FirstOrDefault(m => m.Username == LoginSession.LoginUser);

            List<Tasks> tasks = _context.Tasks.Where(m => m.CreatorID == _teachers.TeacherID).ToList();
            List<TaskModel> _taskList = _task.ConvertTaskToTaskModel(tasks);
            ViewBag.AllTask = _taskList;

            return View();
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

    }
}