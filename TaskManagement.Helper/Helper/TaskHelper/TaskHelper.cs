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

        public static List<TaskModel> ConvertTasksToTaskModelHelper(List<Tasks> autocreatemodel)
        {
            List<TaskModel> _coustomModel = new List<TaskModel>();
            try
            {
                if (autocreatemodel != null && autocreatemodel.Count > 0)
                {
                    foreach (Tasks item in autocreatemodel)
                    {
                        TaskModel _new = new TaskModel();
                        _new.TaskID = item.TaskID;
                        _new.TaskName = item.TaskName;
                        _new.Description = item.Description;
                        _new.Deadline = item.Deadline;
                        _new.CreatorID = item.CreatorID;
                        _coustomModel.Add(_new);
                    }
                }
                return _coustomModel;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static List<AssignmentModel> ConvertTasksToTaskModelHelper(List<Assignment> _assignmentList)
        {
            List<AssignmentModel> _coustomModel = new List<AssignmentModel>();
            try
            {
                if (_assignmentList != null && _assignmentList.Count > 0)
                {
                    foreach (Assignment item in _assignmentList)
                    {
                        AssignmentModel _new = new AssignmentModel();
                        _new.TaskID = item.TaskID;
                        _new.Tasks.TaskName = item.Tasks.TaskName;
                        _new.Tasks.Description = item.Tasks.Description;
                        _new.Tasks.Deadline = item.Tasks.Deadline;
                        _new.Tasks.CreatorID = item.Tasks.CreatorID;
                        _coustomModel.Add(_new);
                    }
                }
                return _coustomModel;
            }
            catch (Exception e)
            {

                throw e;
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
