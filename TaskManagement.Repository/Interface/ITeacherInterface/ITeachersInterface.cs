using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;

namespace TaskManagement.Repository.Interface.ITeacherInterface
{
    public interface ITeachersInterface
    {
        bool AddTeacher(TeacherModel loginDetails);
        //bool CheackTeacher(TeacherModel _teacherModel);

        List<TaskList> TeacherPendingTask(int id);
        List<TaskList> TeacherCompleteTask(int id);
        List<TaskList> TotalCreatTask(int id);
        List<TaskList> TotalAssignTask(int id);
        List<TaskList> TotalExpiredTask(int id);

        bool DeleteTask(int id);

        List<Assignment> AssignAssignment(List<AssignmentModel> assignments);
    }
}
