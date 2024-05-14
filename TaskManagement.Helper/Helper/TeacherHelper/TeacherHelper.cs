using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;

namespace TaskManagement.Helper.Helper.TeacherHelper
{
    public class TeacherHelper
    {
        public static List<TeacherModel> GetTeacherList(List<Teachers> _TeachersList)
        {

            List<TeacherModel> _TeacherModelList = new List<TeacherModel>();

            try
            {

                if (_TeachersList != null)
                {
                    foreach (Teachers Teacher in _TeachersList)
                    {
                        TeacherModel _tempTeacher = new TeacherModel
                        {
                            TeacherID = Teacher.TeacherID,
                            Username = Teacher.Username,
                            Email = Teacher.Email,
                            Password = Teacher.Password,
                            Address = Teacher.Address,
                            ContactNumber = Teacher.ContactNumber,
                            StateID = Teacher.StateID,
                            CityID = Teacher.CityID
                        };

                        _TeacherModelList.Add(_tempTeacher);
                    }
                }

                return _TeacherModelList;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static Teachers ConvertTeacherModelToTeacherContext(TeacherModel _teacherModel)
        {
            Teachers _teachers = new Teachers();

            if (_teacherModel != null)
            {
                _teachers.TeacherID = _teacherModel.TeacherID;
                _teachers.Username = _teacherModel.Username;
                _teachers.Email = _teacherModel.Email;
                _teachers.Password = _teacherModel.Password;
                _teachers.Address = _teacherModel.Address;
                _teachers.ContactNumber = _teacherModel.ContactNumber;
                _teachers.StateID = _teacherModel.StateID;
                _teachers.CityID = _teacherModel.CityID;
            }

            return _teachers;
        }
        public static TeacherModel ConvertStudentContextToStudentModel(Teachers _teachers)
        {
            TeacherModel _teacherModel = new TeacherModel();

            if (_teachers != null)
            {
                _teacherModel.TeacherID = _teachers.TeacherID;
                _teacherModel.Username = _teachers.Username;
                _teacherModel.Email = _teachers.Email;
                _teacherModel.Password = _teachers.Password;
                _teacherModel.Address = _teachers.Address;
                _teacherModel.ContactNumber = _teachers.ContactNumber;
                _teacherModel.StateID = _teachers.StateID;
                _teacherModel.CityID = _teachers.CityID;
            }

            return _teacherModel;
        }
       
        public static Teachers ConvertRegisterDetailsModelToTeacherContext(RegisterDetailsModel _RegisterDetailsModel)

        {
            Teachers _teachers = new Teachers();

            if (_RegisterDetailsModel != null)
            {
                _teachers.Username = _RegisterDetailsModel.Username;
                _teachers.Email = _RegisterDetailsModel.Email;
                _teachers.Password = _RegisterDetailsModel.Password;
                _teachers.Address = _RegisterDetailsModel.Address;
                _teachers.ContactNumber = _RegisterDetailsModel.ContactNumber;
                _teachers.StateID = _RegisterDetailsModel.StateID;
                _teachers.CityID = _RegisterDetailsModel.CityID;
            }

            return _teachers;
        }
        public static RegisterDetailsModel ConvertRegisterDetailsModelContextToStudentModel(Teachers _teachers)
        {
            RegisterDetailsModel _RegisterDetailsModel = new RegisterDetailsModel();

            if (_teachers != null)
            {

                _RegisterDetailsModel.Username = _teachers.Username;
                _RegisterDetailsModel.Email = _teachers.Email;
                _RegisterDetailsModel.Password = _teachers.Password;
                _RegisterDetailsModel.Address = _teachers.Address;
                _RegisterDetailsModel.ContactNumber = _teachers.ContactNumber;
                _RegisterDetailsModel.StateID = _teachers.StateID;
                _RegisterDetailsModel.CityID = _teachers.CityID;
            }

            return _RegisterDetailsModel;
        }

        public static Teachers ConvertLoginModelToTeacherContext(LoginModel _RegisterDetailsModel)

        {
            Teachers _teachers = new Teachers();

            if (_RegisterDetailsModel != null)
            {
                _teachers.Username = _RegisterDetailsModel.Username;
                _teachers.Password = _RegisterDetailsModel.Password;
            }

            return _teachers;
        }
        public static LoginModel ConvertContextToLoginModel(Teachers _teachers)
        {
            LoginModel _RegisterDetailsModel = new LoginModel();

            if (_teachers != null)
            {

                _RegisterDetailsModel.Username = _teachers.Username;
                _RegisterDetailsModel.Password = _teachers.Password;
            }

            return _RegisterDetailsModel;
        }

        public static Assignment ConvertAssigmentModelToAssignmentUSingObj(AssignmentModel user)
        {
            Assignment _AssignmentModel = new Assignment();

            _AssignmentModel.AssignmentID = user.AssignmentID;
            _AssignmentModel.TaskID = user.TaskID;
            _AssignmentModel.StudentID = user.StudentID;

            return _AssignmentModel;
        }
    }
}
