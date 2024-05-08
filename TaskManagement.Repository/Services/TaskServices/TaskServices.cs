using System;
using System.Collections.Generic;
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
    }
}
