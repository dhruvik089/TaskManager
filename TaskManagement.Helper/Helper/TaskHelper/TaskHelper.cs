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
                        //_task.CreatorID = tasks.CreatorID;
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

        //public static List<AssignmentList> ConvertTasksToTaskModelHelper(List<Assignment> _assignmentList)
        //{
        //    List<AssignmentList> _coustomModel = new List<AssignmentList>();
        //    try
        //    {
        //        if (_assignmentList != null && _assignmentList.Count > 0)
        //        {
        //            foreach (Assignment item in _assignmentList)
        //            {
        //                AssignmentList _new = new AssignmentList();
        //                _new.TaskID = item.TaskID;
        //                _new.TaskName = item.Tasks.TaskName;
        //                _new.Description = item.Tasks.Description;
        //                _new.Deadline = item.Tasks.Deadline;
        //                _new.CreatorID = item.Tasks.CreatorID;
        //                _coustomModel.Add(_new);
        //            }
        //        }
        //        return _coustomModel;
        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }
        //}

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
