using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;
using TaskManagement.Repository.Interface.ITeacherInterface;
using TaskManagement.Helper.Helper.TeacherHelper;

namespace TaskManagement.Repository.Services.TeacherServices
{
    public class TeacherServices : ITeachersInterface
    {
        TaskManagementEntities _registerTeacher = new TaskManagementEntities();

        public bool AddTeacher(TeacherModel newTeacher)
        {
            TeacherModel _teacherModel = new TeacherModel();
            try
            {
                Teachers _teacher = TeacherHelper.ConvertTeacherModelToTeacherContext(_teacherModel);
                _teacher = _registerTeacher.Teachers.FirstOrDefault();

                if (_teacher != null)
                {
                    _registerTeacher.Teachers.Add(_teacher);
                    _registerTeacher.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e) { throw e; }
        }

        public bool CheackTeacher(TeacherModel _teacherModel)
        {

            try
            {
                return true;
            }
            catch (Exception e) { throw e; }
        }

        public List<Assignment> AssignAssignment(List<AssignmentModel> assignments)
        {
            List<Assignment> assignedAssignments = new List<Assignment>();

            foreach (var db in assignments)
            {
                Assignment _AssignAssignment = TeacherHelper.ConvertAssigmentModelToAssignmentUSingObj(db);
                _registerTeacher.Assignment.Add(_AssignAssignment);
                assignedAssignments.Add(_AssignAssignment);
            }
            _registerTeacher.SaveChanges();
            return assignedAssignments;
        }
    }
}
