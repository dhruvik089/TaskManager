using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TaskManagement.Helper.Helper.SpHelper;
using TaskManagement.Helper.Helper.TaskHelper;
using TaskManagement.Helper.Helper.TeacherHelper;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;

namespace TaskManagement.API.Controllers
{
    public class TeacherController : ApiController
    {

        TaskManagementEntities _context = new TaskManagementEntities();

        [Route("api/teacher/TotalCreateTask")]
        [HttpGet]
        public async Task<List<TaskList>> TotalCreateTask(int id)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                      new SqlParameter("@id",id)
                };
                List<TaskList> assignmentLists = _context.Database.SqlQuery<TaskList>(SpHelper.TotalCreatTask, sqlParameters).ToList();
                return assignmentLists;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [Route("api/teacher/TotalCompleteTask")]
        [HttpGet]
        public async Task<List<TaskList>> TotalCompleteTask(int id)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                      new SqlParameter("@id",id)
                };
                List<TaskList> assignmentLists = _context.Database.SqlQuery<TaskList>(SpHelper.TeacherCompleteTask, sqlParameters).ToList();
                return assignmentLists;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [Route("api/teacher/TotalPendingTask")]
        [HttpGet]
        public async Task<List<TaskList>> TotalPendingTask(int id)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                      new SqlParameter("@id",id)
                };
                List<TaskList> assignmentLists = _context.Database.SqlQuery<TaskList>(SpHelper.TeacherPendingTask, sqlParameters).ToList();
                return assignmentLists;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [Route("api/teacher/TotalAssignTask")]
        [HttpGet]
        public async Task<List<TaskList>> TotalAssignTask(int id)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                      new SqlParameter("@id",id)
                };
                List<TaskList> assignmentLists = _context.Database.SqlQuery<TaskList>(SpHelper.TotalAssignTask, sqlParameters).ToList();
                return assignmentLists;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [Route("api/teacher/TotalExpiredTask")]
        [HttpGet]
        public async Task<List<TaskList>> TotalExpiredTask(int id)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                      new SqlParameter("@id",id)
                };
                List<TaskList> assignmentLists = _context.Database.SqlQuery<TaskList>(SpHelper.TeacherExpiredTask, sqlParameters).ToList();
                return assignmentLists;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [Route("api/teacher/DeleteTask")]
        [HttpGet]
        public async Task<int> DeleteTask(int id)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
           {
                new SqlParameter("@id",id)
           };

            int a = _context.Database.SqlQuery<TaskList>(SpHelper.DeleteTask, sqlParameters).ToList().Count();
            return a;
        }

        [Route("api/teacher/NotAsignTask")]
        [HttpGet]
        public async Task<List<StudentModel>> NotAsignTask(int id)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                      new SqlParameter("@id",id)
                };

                List<StudentModel> _students = _context.Database.SqlQuery<StudentModel>(SpHelper.GetStudentByTaskNotAssign, sqlParameters).ToList();

                return _students;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [Route("api/teacher/AsignTask")]
        [HttpPost]

        public List<Assignment> AssignAssignment(List<AssignmentModel> assignments)
        {
            List<Assignment> assignedAssignments = new List<Assignment>();

            foreach (var db in assignments)
            {
                Assignment _AssignAssignment = TeacherHelper.ConvertAssigmentModelToAssignmentUSingObj(db);
                _context.Assignment.Add(_AssignAssignment);
                assignedAssignments.Add(_AssignAssignment);
            }
            _context.SaveChanges();
            return assignedAssignments;
        }

        [Route("api/teacher/CrateTask")]
        [HttpPost]
        public Tasks CrateTask(TaskModel _taskModel)
        {
            Tasks tasks = new Tasks();

            try
            {
                tasks = TaskHelper.ConvertTaskModeltoTask(_taskModel);

                _context.Tasks.Add(tasks);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

            return tasks;
        }
    }
}