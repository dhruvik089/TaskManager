using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;

namespace TaskManagement.Helper.Helper.TaskHelper
{
    public class TaskHelper
    {
        public static List<TaskModel> GetTaskListByHelper(List<Tasks> taskList)
        {
            List<TaskModel> _taskModel = new List<TaskModel>();
            try
            {
                if (taskList != null && taskList.Count > 0)
                {
                    foreach (Tasks tasks in taskList)
                    {
                        TaskModel _task = new TaskModel();
                        _task.TaskName = tasks.TaskName;
                        _task.Description = tasks.Description;
                        _task.Deadline = tasks.Deadline;
                        _task.CreatorID = tasks.CreatorID;
                        //_task.Assignment = tasks.Assignment;
                        //_task.Teachers = tasks.Teachers;

                        _taskModel.Add(_task);
                    }
                }
                return _taskModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Tasks ConvertTaskModeltoTask(TaskModel taskModel)
        {
            try
            {
                Tasks _taskContext = new Tasks();

                if (taskModel != null)
                {
                    _taskContext.TaskID = taskModel.TaskID;
                    _taskContext.TaskName = taskModel.TaskName;
                    _taskContext.Description = taskModel.Description;
                    _taskContext.Deadline = taskModel.Deadline;
                    _taskContext.CreatorID = taskModel.CreatorID;
                    //_taskContext.Assignment = taskModel.Assignment;
                    //_taskContext.Teachers = taskModel.Teachers;
                }
                return _taskContext;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
