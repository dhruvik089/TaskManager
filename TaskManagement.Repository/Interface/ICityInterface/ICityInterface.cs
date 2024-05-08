using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.ViewModel;

namespace TaskManagement.Repository.Interface.ICityInterface
{
    public interface ICityInterface
    {
        List<CityModel> GetCityByStateId(int id);
    }
}
