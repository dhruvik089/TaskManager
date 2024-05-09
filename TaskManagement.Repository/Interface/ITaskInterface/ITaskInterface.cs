using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;

namespace TaskManagement.Repository.Interface.ITaskInterface
{
    public interface ITaskInterface
    {
        Tasks AddTask(TaskModel _task);
        List<TaskModel> ConvertTaskToTaskModel(List<Tasks> tasks);
        List<AssignmentModel> GetAssignmentTasks(int id);
        bool AssignmentStatus(int Id);
    }
}
