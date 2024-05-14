using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;

namespace TaskManagement.Helper.Helper.StudentHelper
{
    public class StudentHelper
    {
        public static List<StudentModel> GetStudentList(List<Students> _studentsList)
        {
            List<StudentModel> _studentModelList = new List<StudentModel>();

            if (_studentsList != null)
            {
                foreach (Students student in _studentsList)
                {
                    StudentModel _tempstudent = new StudentModel
                    {
                        StudentID = student.StudentID,
                        Username = student.Username,
                        Email = student.Email,
                        Password = student.Password,
                        Address = student.Address,
                        ContactNumber = student.ContactNumber,
                        StateID = student.StateID,
                        CityID = student.CityID
                    };

                    _studentModelList.Add(_tempstudent);
                }
            }

            return _studentModelList;
        }
        public static Students ConvertStudentModelToStudentContext(StudentModel _studentModel)
        {
            Students _students = new Students();

            if (_studentModel != null)
            {
                _students.StudentID = _studentModel.StudentID;
                _students.Username = _studentModel.Username;
                _students.Email = _studentModel.Email;
                _students.Password = _studentModel.Password;
                _students.Address = _studentModel.Address;
                _students.ContactNumber = _studentModel.ContactNumber;
                _students.StateID = _studentModel.StateID;
                _students.CityID = _studentModel.CityID;
            }

            return _students;
        }
        public static StudentModel ConvertStudentContextToStudentModel(Students _students)
        {
            StudentModel _studentModel = new StudentModel();

            if (_students != null)
            {
                _studentModel.StudentID = _students.StudentID;
                _studentModel.Username = _students.Username;
                _studentModel.Email = _students.Email;
                _studentModel.Password = _students.Password;
                _studentModel.Address = _students.Address;
                _studentModel.ContactNumber = _students.ContactNumber;
                _studentModel.StateID = _students.StateID;
                _studentModel.CityID = _students.CityID;
            }

            return _studentModel;
        }

        public static List<StudentModel> ConvertStudentListToStudentModelList(List<Students> studentList)
        {
            try
            {
                List<StudentModel> studentModelList = new List<StudentModel>();
                if (studentList != null)
                {
                    foreach (var item in studentList)
                    {
                        StudentModel studentModel = new StudentModel();
                        studentModel.StudentID = item.StudentID;
                        studentModel.Username = item.Username;
                        studentModel.Password = item.Password;
                        studentModel.Email = item.Email;
                        studentModel.Address = item.Address;
                        studentModel.CityID = item.CityID;
                        studentModel.StateID = item.StateID;
                        studentModelList.Add(studentModel);
                    }
                }
                return studentModelList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Students ConvertRegisterModelToStudentContext(RegisterDetailsModel _RegisterDetailsModel)
        {
            Students _students = new Students();

            if (_RegisterDetailsModel != null)
            {

                _students.Username = _RegisterDetailsModel.Username;
                _students.Email = _RegisterDetailsModel.Email;
                _students.Password = _RegisterDetailsModel.Password;
                _students.Address = _RegisterDetailsModel.Address;
                _students.ContactNumber = _RegisterDetailsModel.ContactNumber;
                _students.StateID = _RegisterDetailsModel.StateID;
                _students.CityID = _RegisterDetailsModel.CityID;
            }

            return _students;
        }
        public static RegisterDetailsModel ConvertStudentContextToRegisterModel(Students _students)
        {
            RegisterDetailsModel _RegisterDetailsModel = new RegisterDetailsModel();

            if (_students != null)
            {
                _RegisterDetailsModel.Username = _students.Username;
                _RegisterDetailsModel.Email = _students.Email;
                _RegisterDetailsModel.Password = _students.Password;
                _RegisterDetailsModel.Address = _students.Address;
                _RegisterDetailsModel.ContactNumber = _students.ContactNumber;
                _RegisterDetailsModel.StateID = _students.StateID;
                _RegisterDetailsModel.CityID = _students.CityID;
            }

            return _RegisterDetailsModel;
        }

        public static Students ConvertLoginModelToStudentContext(LoginModel _RegisterDetailsModel)
        {
            Students _students = new Students();

            if (_RegisterDetailsModel != null)
            {

                _students.Username = _RegisterDetailsModel.Username;                
                _students.Password = _RegisterDetailsModel.Password;
            }

            return _students;
        }
        public static LoginModel ConvertStudentContextToLoginModel(Students _students)
        {
            LoginModel _RegisterDetailsModel = new LoginModel();

            if (_students != null)
            {
                _RegisterDetailsModel.Username = _students.Username;
                _RegisterDetailsModel.Password = _students.Password;
            }

            return _RegisterDetailsModel;
        }
    }
}
