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

        List<Assignment> AssignAssignment(List<AssignmentModel> assignments);
    }
}
