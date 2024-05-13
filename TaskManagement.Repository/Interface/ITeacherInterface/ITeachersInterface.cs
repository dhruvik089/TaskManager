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
        bool CheackTeacher(TeacherModel _teacherModel);

        int TeacherPendingTask(int id);
        int TeacherCompleteTask(int id);
        int TotalCreatTask(int id);
        int TotalAssignTask(int id);

        List<Assignment> AssignAssignment(List<AssignmentModel> assignments);
    }
}
