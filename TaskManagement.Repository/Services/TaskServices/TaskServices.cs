using System;
using System.Collections.Generic;
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
                return null;
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
                    return null;

                }
            }
        }

        public List<TaskModel> GetAssignmentTasks(int id)
        {

            try
            {
                //Students _student = new Students();
                List<Tasks> _tasks = new List<Tasks>();
                //_student = _context.Students.FirstOrDefault(x => x.Username == Username);
                SqlParameter[] _perameter = new SqlParameter[]
                {
                    new SqlParameter("@id",id)
                };
                _tasks = _context.Tasks.SqlQuery("Exec ShowAssignment @id", _perameter).ToList();
                TaskHelper.ConvertTasksToTaskModelHelper(_tasks);
                //int id = _student.StudentID;
                //List<Assignment> _assignmentList = _context.Assignment.Where(u => u.StudentID == id).ToList();
                List<TaskModel> _assignmentList = TaskHelper.ConvertTasksToTaskModelHelper(_tasks);

                return _assignmentList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
