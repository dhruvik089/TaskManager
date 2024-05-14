using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models;
using TaskManagement.Models.ViewModel;

namespace TaskManagement.Repository.Interface.IRegisterInterface
{
    public interface IRegisterDetailsInterface
    {

        bool AddUser(RegisterDetailsModel _registerDetailsModel);
        List<RegisterDetailsModel> GetCity();
        bool CheckUserLogin(LoginModel _login);
    }
}
