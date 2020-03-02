using System.Collections.Generic;
using src.Model.ModelFramework.Actionables;
using src.Model.ModelFramework.ActionFramework.ActionTurnModels;

namespace src.Model.ModelFramework.ActionFramework.ActionModels
{
    public class DroneModel: ActionModel
    {
        public readonly IEnumerable<DroneTurnModel> DroneTurnModel;
        
        public DroneModel(string actionName, ActionTime actionTime, int actionLevel, string description,
            string roomModel, IEnumerable<DroneTurnModel> droneTurnModel, ActionPriority priority) : base(actionName, actionTime, actionLevel, description, roomModel, priority)
        {
            DroneTurnModel = droneTurnModel;
        }
    }
}