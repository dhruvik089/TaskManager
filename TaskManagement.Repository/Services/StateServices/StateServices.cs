using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Helper.Helper.StateHelper;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;
using TaskManagement.Repository.Interface.IStateInterface;

namespace TaskManagement.Repository.Services.StateServices
{
    public class StateServices : IStateInterface
    {
        private readonly TaskManagementEntities _context;

        public StateServices()
        {
            _context = new TaskManagementEntities();
        }

        public List<StateModel> stateModelList()
        {
            List<StateModel> stateModelList = new List<StateModel>();
            List<States> states = _context.States.ToList();

            stateModelList = StateHelper.ConvertStateToStateModel(states);
            return stateModelList;
        }
    }
}
