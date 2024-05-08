using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;

namespace TaskManagement.Helper.Helper.StateHelper
{
    public class StateHelper
    {
        public static List<StateModel> GetStateList(List<States> _statesList)
        {
            List<StateModel> _stateModelsList = new List<StateModel>();

            try
            {
                if (_statesList != null)
                {
                    foreach (States state in _statesList)
                    {

                        StateModel _tempStateModels = new StateModel
                        {
                            StateID = state.StateID,
                            StateName = state.StateName
                        };
                        _stateModelsList.Add(_tempStateModels);
                    }
                }
                return _stateModelsList;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static StateModel ConvertModelToContext(States _state)
        {
            try
            {
                StateModel _stateModel = new StateModel();
                if (_state != null)
                {
                    _stateModel.StateID = _state.StateID;
                    _stateModel.StateName = _state.StateName;
                }
                return _stateModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static States ConvertContextToModel(StateModel _stateModel)
        {
            try
            {
                States _states = new States();
                if (_stateModel != null)
                {
                    _states.StateID = _stateModel.StateID;
                    _states.StateName = _stateModel.StateName;
                }
                return _states;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<StateModel> ConvertStateToStateModel(List<States> stateList)
        {
            try
            {
                List<StateModel> stateModelList = new List<StateModel>();
                if (stateList != null)
                {
                    foreach (States state in stateList)
                    {
                        StateModel stateModel = new StateModel();
                        stateModel.StateID = state.StateID;
                        stateModel.StateName = state.StateName;
                        stateModelList.Add(stateModel);
                    }
                }
                return stateModelList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
