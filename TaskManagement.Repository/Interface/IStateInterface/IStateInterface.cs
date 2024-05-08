using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.ViewModel;

namespace TaskManagement.Repository.Interface.IStateInterface
{
    public interface IStateInterface
    {
        List<StateModel> stateModelList();
    }
}
