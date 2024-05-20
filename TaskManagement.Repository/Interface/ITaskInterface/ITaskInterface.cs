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
        List<AssignmentList> GetAssignmentTasks(int id);
        bool AssignmentStatus(int Id);

        List<AssignmentList> TotalTask(int id);
        List<AssignmentList> CompleteTask(int id);
        List<AssignmentList> PendingTask(int id);
        List<AssignmentList> ExpiredTask(int id);     

        List<StudentModel> NotAsignTask(int id);

    }
}
