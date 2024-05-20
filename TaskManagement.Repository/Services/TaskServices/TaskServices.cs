using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Helper.Helper.TaskHelper;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;
using TaskManagement.Repository.Interface.ITaskInterface;

namespace TaskManagement.Repository.Services.TaskServices
{
    public class TaskServices : ITaskInterface
    {
        TaskManagementEntities _context = new TaskManagementEntities();

        public Tasks AddTask(TaskModel _taskModel)
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

        public List<TaskModel> ConvertTaskToTaskModel(List<Tasks> tasks)
        {
            {
                try
                {
                    List<TaskModel> taskModelList = new List<TaskModel>();

                    if (tasks != null)
                    {
                        foreach (var task in tasks)
                        {
                            TaskModel taskModel = new TaskModel();
                            taskModel.TaskID = task.TaskID;
                            taskModel.TaskName = task.TaskName;
                            taskModel.Description = task.Description;
                            taskModel.Deadline = task.Deadline;
                            taskModel.CreatorID = task.CreatorID;
                            taskModelList.Add(taskModel);
                        }
                    }

                    return taskModelList;
                }
                catch (Exception ex)
                {
                    throw ex;

                }
            }
        }

        public List<AssignmentList> GetAssignmentTasks(int id)
        {
            List<AssignmentList> _text =new List<AssignmentList>();

            //try
            //{
            //    List<Assignment> _tasks = new List<Assignment>();

            //    SqlParameter[] _perameter = new SqlParameter[]
            //    {
            //        new SqlParameter("@id",id)
            //    };
            //    List<AssignmentList> _taskView = _context.Database.SqlQuery<AssignmentList>("Exec ShowAssignment @id", _perameter).ToList();

            //    return _taskView;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            return _text;
        }

        public bool AssignmentStatus(int id)
        {
            try
            {
                Assignment assignments = new Assignment();

                assignments = _context.Assignment.FirstOrDefault(m => m.AssignmentID == id);

                int isUpdateSaveOrNot = 0;

                if (assignments.Task_complete != Convert.ToBoolean(1))

                {

                    assignments.Task_complete = Convert.ToBoolean(1);

                    _context.Entry(assignments).State = EntityState.Modified;

                    isUpdateSaveOrNot = _context.SaveChanges();

                }

                if (isUpdateSaveOrNot > 0)

                {
                    return true;
                }

                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AssignmentList> TotalTask(int id)
        {
            List<AssignmentList> assignmentLists = new List<AssignmentList>();
            try
            {

                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                      new SqlParameter("@id",id)
                };
                assignmentLists = _context.Database.SqlQuery<AssignmentList>("exec totalTask @id", sqlParameters).ToList();
                return assignmentLists;
            }
            catch (Exception e)
            {
                throw e;
            }
            return assignmentLists;
        }

        public List<AssignmentList> CompleteTask(int id)
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

        public List<AssignmentList> PendingTask(int id)
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

        public List<StudentModel> NotAsignTask(int id)
        {
            try
            {

                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                      new SqlParameter("@id",id)
                };

                List<StudentModel> _students = _context.Database.SqlQuery<StudentModel>("exec GetStudentByTaskNotAssign @id", sqlParameters).ToList();

                return _students;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<AssignmentList> ExpiredTask(int id)
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
