using src.Model.ModelFramework.Actionables.ActionTurnModels;

namespace src.Model.ModelFramework.Actionables.ActionModels
{
    public class DroneModel: ActionModel
    {
        public readonly DroneTurnModel[] DroneTurnModel;
        
        public DroneModel(string actionName, ActionTime actionTime, int actionLevel, string description, string roomModel, DroneTurnModel[] droneTurnModel) : base(actionName, actionTime, actionLevel, description, roomModel)
        {
            DroneTurnModel = droneTurnModel;
        }
    }
}