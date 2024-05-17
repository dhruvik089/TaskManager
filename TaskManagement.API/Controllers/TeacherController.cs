using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
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
                List<TaskList> assignmentLists = _context.Database.SqlQuery<TaskList>("exec TotalCreatTask @id", sqlParameters).ToList();
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
                List<TaskList> assignmentLists = _context.Database.SqlQuery<TaskList>("exec TeacherCompleteTask @id", sqlParameters).ToList();
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
                List<TaskList> assignmentLists = _context.Database.SqlQuery<TaskList>("exec TeacherPendingTask @id", sqlParameters).ToList();
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
                List<TaskList> assignmentLists = _context.Database.SqlQuery<TaskList>("exec TotalAssignTask @id", sqlParameters).ToList();
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
                List<TaskList> assignmentLists = _context.Database.SqlQuery<TaskList>("exec TeacherExpiredTask @id", sqlParameters).ToList();
                return assignmentLists;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

    }
}