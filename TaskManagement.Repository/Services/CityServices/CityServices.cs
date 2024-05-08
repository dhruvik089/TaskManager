using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Helper.Helper.CityHelper;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;
using TaskManagement.Repository.Interface.ICityInterface;

namespace TaskManagement.Repository.Services.CityServices
{
    public class CityServices : ICityInterface
    {
        public List<CityModel> GetCityByStateId(int id)
        {
        TaskManagementEntities _context=new TaskManagementEntities();
            try
            {
                List<CityModel> cityModelList = new List<CityModel>();
                List<Cities> cityList = _context.Cities.Where(m => m.StateID == id).ToList();

                cityModelList = CityHelper.ConvertCityToCityModel(cityList);
                return cityModelList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
