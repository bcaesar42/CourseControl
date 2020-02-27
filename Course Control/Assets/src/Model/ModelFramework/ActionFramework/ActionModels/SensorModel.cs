using src.Model.ModelFramework.Actionables.ActionTurnModels;

namespace src.Model.ModelFramework.Actionables.ActionModels
{
    public class SensorModel: ActionModel
    {
        public readonly SensorTurnModel[] SensorTurnModel;
        
        public SensorModel(string actionName, ActionTime actionTime, int actionLevel, string description, string roomModel, SensorTurnModel[] sensorTurnModel) : base(actionName, actionTime, actionLevel, description, roomModel)
        {
            SensorTurnModel = sensorTurnModel;
        }
    }
}