using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Helper.Helper.StateHelper;
using TaskManagement.Helper.Helper.StudentHelper;
using TaskManagement.Helper.Helper.TeacherHelper;
using TaskManagement.Models;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;
using TaskManagement.Repository.Interface.IRegisterInterface;

namespace TaskManagement.Repository.Services
{
    public class RegisterDetailsServices : IRegisterDetailsInterface
    {
        TaskManagementEntities _context = new TaskManagementEntities();

        public bool AddUser(RegisterDetailsModel _registerDetailsModel)
        {

            RegisterDetailsModel _registerUser = _registerDetailsModel;

            try
            {

                if (_registerDetailsModel.UserRole == "Teacher")
                {
                    Teachers _newTeacher = TeacherHelper.ConvertRegisterDetailsModelToTeacherContext(_registerUser);

                    Teachers _teachers = TeacherHelper.ConvertRegisterDetailsModelToTeacherContext(_registerDetailsModel);
                    _teachers = _context.Teachers.FirstOrDefault(m => m.Email == _registerDetailsModel.Email);

                    if (_teachers == null)
                    {
                        _context.Teachers.Add(_newTeacher);
                        _context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (_registerDetailsModel.UserRole == "Student")
                {
                    Students newStudents = StudentHelper.ConvertRegisterModelToStudentContext(_registerDetailsModel);
                    Students _students = StudentHelper.ConvertRegisterModelToStudentContext(_registerUser);
                    _students = _context.Students.FirstOrDefault(m => m.Email == _registerDetailsModel.Email);

                    if (_students == null)
                    {
                        _context.Students.Add(newStudents);
                        _context.SaveChanges();
                        return true;
                    }

                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex) { throw ex; }
        }


        public List<RegisterDetailsModel> GetCity()
        {
            List<RegisterDetailsModel> _city = new List<RegisterDetailsModel>();

            return _city;
        }

        public bool CheckUserLogin(LoginModel _login)
        {
            try
            {
                if (_login.UserRole == "Teacher")
                {
                    Teachers _teachers = new Teachers();
                    _teachers = TeacherHelper.ConvertLoginModelToTeacherContext(_login);
                    _teachers = _context.Teachers.Where(x => x.Username == _login.Username && x.Password == _login.Password).FirstOrDefault();
                    if (_teachers != null)
                    {
                        return true;
                    }
                }
                else if (_login.UserRole == "Student")
                {
                    Students _students = new Students();
                    _students = StudentHelper.ConvertLoginModelToStudentContext(_login);
                    _students = _context.Students.Where(x => x.Username == _login.Username && x.Password == _login.Password).FirstOrDefault();

                    if (_students != null)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex) { throw ex; }

        }
    }
}
