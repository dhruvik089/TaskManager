using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManagement.Helper.Helper.SpHelper;
using TaskManagement.Helper.Session;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;
using TaskManagement.Repository.Interface.ITaskInterface;
using TaskManagement.Repository.Services.TaskServices;


namespace TaskManagement.API.Controllers
{
    public class StudentController : ApiController
    {

        TaskManagementEntities _context = new TaskManagementEntities();

        [Route("api/student/ShowTask")]
        [HttpGet]
        public List<AssignmentList> ShowTask(int id)
        {
            try
            {
                List<Assignment> _tasks = new List<Assignment>();

                SqlParameter[] _perameter = new SqlParameter[]
                {
                    new SqlParameter("@id",id)
                };
                List<AssignmentList> _taskView = _context.Database.SqlQuery<AssignmentList>(SpHelper.ShowAssignment, _perameter).ToList();

                return _taskView;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("api/student/ShowTotalComplete")]
        [HttpGet]
        public List<AssignmentList> ShowTotalComplete(int id)
        {

            try
            {
                int _totaltask;

                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                      new SqlParameter("@id",id)
                };

                List<AssignmentList> assignmentLists = _context.Database.SqlQuery<AssignmentList>("exec totalCompleteTask @id", sqlParameters).ToList();
                return assignmentLists;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [Route("api/student/ShowPending")]
        [HttpGet]
        public List<AssignmentList> ShowPending(int id)
        {

            try
            {

                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                      new SqlParameter("@id",id)
                };

                List<AssignmentList> assignmentLists = _context.Database.SqlQuery<AssignmentList>("exec totalPendingTask @id", sqlParameters).ToList();
                return assignmentLists;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [Route("api/student/ShowExpired")]
        [HttpGet]
        public List<AssignmentList> ShowExpired(int id)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@id",id)
                };
                List<AssignmentList> _assignmentLists = _context.Database.SqlQuery<AssignmentList>("exec StudentExpiredTask @id", sqlParameters).ToList();
                return _assignmentLists;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}