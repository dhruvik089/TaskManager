using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;
using TaskManagement.Repository.Interface.ICityInterface;
using TaskManagement.Repository.Interface.IRegisterInterface;
using TaskManagement.Repository.Interface.IStateInterface;
using TaskManagement.Repository.Services;
using TaskManagement.Repository.Services.CityServices;
using TaskManagement.Repository.Services.StateServices;
using TaskManagement.Helper.Session;

namespace TaskManagement.Controllers.LoginSignup
{
    public class LoginSignupController : Controller
    {
        private readonly IRegisterDetailsInterface _registerData;
        private readonly ICityInterface _city;
        private readonly IStateInterface _state;
        private readonly TaskManagementEntities _context;

        public LoginSignupController()
        {
            this._registerData = new RegisterDetailsServices();
            this._city = new CityServices();
            this._state = new StateServices();
            this._context = new TaskManagementEntities();
        }


        public ActionResult Login()
        {
            LoginSession.Logout();
            return View();
        }

        [HttpPost]
        public ActionResult Login( LoginModel loginDetails)
        {
            if (ModelState.IsValid)
            {
                if (_registerData.CheckUserLogin(loginDetails))
                {
                    if (loginDetails.UserRole == "Teacher")
                    {
                        Teachers _teacher = _context.Teachers.FirstOrDefault(m => m.Username == loginDetails.Username);
                        LoginSession.LoginUser = loginDetails.Username;
                        LoginSession.UserRole = loginDetails.UserRole;
                        ViewBag.username = loginDetails.Username;
                        string name = loginDetails.Username;
                        Session["Teachername"] = LoginSession.LoginUser;

                        TempData["SuccessLogin"] = "Login SuccessFully";
                        return RedirectToAction("Teacher", "Teacher");
                    }
                    else if (loginDetails.UserRole == "Student")
                    {
                        Students _student = _context.Students.FirstOrDefault(m => m.Username == loginDetails.Username);
                        LoginSession.LoginUser = loginDetails.Username;
                        LoginSession.UserRole = loginDetails.UserRole;
                        ViewBag.username = loginDetails.Username;
                        Session["username"] = LoginSession.LoginUser;

                        TempData["SuccessLogin"] = "Login SuccessFully";
                        return RedirectToAction("Student", "Student");
                    }
                    else
                    {
                        TempData["selectRole"] = "Select Role";
                        return View();
                    }
                }
                else
                {
                    TempData["LoginFail"] = "Invalid Email or Password";
                    return View();
                }
            }

            else
            {
                //TempData["LoginFail"] = "Invalid Email or Password";
                return View();
            }
        }

        public ActionResult RegistrationPage()
        {
            ViewBag.States = _state.stateModelList();
            return View();
        }

        [HttpPost]
        public ActionResult RegistrationPage(RegisterDetailsModel registerDetailsModel)
        {
            if (ModelState.IsValid)
            {
                if (_registerData.AddUser(registerDetailsModel))
                {
                    _registerData.AddUser(registerDetailsModel);
                    TempData["RegistrationSuccess"] = "Registration Successfully";

                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.States = _state.stateModelList();
                    TempData["Error"] = "Something Wrong";
                    ModelState.AddModelError("Email", "Email already exist");
                    return View();
                }
            }
            ViewBag.States = _state.stateModelList();
            return View();

        }

        public JsonResult CitiesByState(int id)
        {
            List<CityModel> list = _city.GetCityByStateId(id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}