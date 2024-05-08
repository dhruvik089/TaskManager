using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;

namespace TaskManagement.Helper.Helper.CityHelper
{
    public class CityHelper
    {
        public static List<CityModel> ConvertCityToCityModel(List<Cities> cityList)
        {
            try
            {
                List<CityModel> cityModelList = new List<CityModel>();
                if (cityList != null)
                {
                    foreach (var city in cityList)
                    {
                        CityModel cityModel = new CityModel();
                        cityModel.CityID = city.CityID;
                        cityModel.CityName = city.CityName;
                        cityModel.StateID = city.StateID;
                        cityModelList.Add(cityModel);
                    }
                }

                return cityModelList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}



