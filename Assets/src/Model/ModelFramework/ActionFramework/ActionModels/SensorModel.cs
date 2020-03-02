using System.Collections.Generic;
using src.Model.ModelFramework.Actionables;
using src.Model.ModelFramework.ActionFramework.ActionTurnModels;

namespace src.Model.ModelFramework.ActionFramework.ActionModels
{
    public class SensorModel: ActionModel
    {
        public readonly IEnumerable<SensorTurnModel> SensorTurnModel;
        
        public SensorModel(string actionName, ActionTime actionTime, int actionLevel, string description,
            string roomModel, IEnumerable<SensorTurnModel> sensorTurnModel, ActionPriority priority) : base(actionName, actionTime, actionLevel, description, roomModel, priority)
        {
            SensorTurnModel = sensorTurnModel;
        }
    }
}