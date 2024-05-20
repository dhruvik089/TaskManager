using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;
using TaskManagement.Repository.Interface.ITeacherInterface;
using TaskManagement.Helper.Helper.TeacherHelper;
using System.Data.SqlClient;

namespace TaskManagement.Repository.Services.TeacherServices
{
    public class TeacherServices : ITeachersInterface
    {
        TaskManagementEntities _registerTeacher = new TaskManagementEntities();

        public bool AddTeacher(TeacherModel newTeacher)
        {
            TeacherModel _teacherModel = new TeacherModel();
            try
            {
                Teachers _teacher = TeacherHelper.ConvertTeacherModelToTeacherContext(_teacherModel);
                _teacher = _registerTeacher.Teachers.FirstOrDefault();

                if (_teacher != null)
                {
                    _registerTeacher.Teachers.Add(_teacher);
                    _registerTeacher.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e) { throw e; }
        }

        public List<Assignment> AssignAssignment(List<AssignmentModel> assignments)
        {
            List<Assignment> assignedAssignments = new List<Assignment>();

            foreach (var db in assignments)
            {
                Assignment _AssignAssignment = TeacherHelper.ConvertAssigmentModelToAssignmentUSingObj(db);
                _registerTeacher.Assignment.Add(_AssignAssignment);
                assignedAssignments.Add(_AssignAssignment);
            }
            _registerTeacher.SaveChanges();
            return assignedAssignments;
        }

        public List<TaskList> TeacherPendingTask(int id)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                      new SqlParameter("@id",id)
                };
                List<TaskList> assignmentLists = _registerTeacher.Database.SqlQuery<TaskList>("exec TeacherPendingTask @id", sqlParameters).ToList();
                return assignmentLists;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<TaskList> TeacherCompleteTask(int id)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                      new SqlParameter("@id",id)
                };
                List<TaskList> assignmentLists = _registerTeacher.Database.SqlQuery<TaskList>("exec TeacherCompleteTask @id", sqlParameters).ToList();
                return assignmentLists;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<TaskList> TotalCreatTask(int id)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                      new SqlParameter("@id",id)
                };
                List<TaskList> assignmentLists = _registerTeacher.Database.SqlQuery<TaskList>("exec TotalCreatTask @id", sqlParameters).ToList();
                return assignmentLists;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<TaskList> TotalAssignTask(int id)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                      new SqlParameter("@id",id)
                };
                List<TaskList> assignmentLists = _registerTeacher.Database.SqlQuery<TaskList>("exec TotalAssignTask @id", sqlParameters).ToList();
                return assignmentLists;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<TaskList> TotalExpiredTask(int id)
        {
            try
            {
                SqlParameter[] _sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@id",id)
                };

                List<TaskList> _taskList = _registerTeacher.Database.SqlQuery<TaskList>("exec TeacherExpiredTask @id", _sqlParameters).ToList();
                return _taskList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteTask(int id)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };

            int a = _registerTeacher.Database.SqlQuery<TaskList>("exec DeleteTask @id", sqlParameters).ToList().Count();

            if (a == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}