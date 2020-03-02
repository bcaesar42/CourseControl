using src.Model.ModelFramework.Actionables.ActionTurnModels;

namespace src.Model.ModelFramework.Actionables.ActionModels
{
    public class ScavengerModel: ActionModel
    {
        public readonly ScavengerTurnModel[] ScavengerTurnModel;
        
        public ScavengerModel(string actionName, ActionTime actionTime, int actionLevel, string description, string roomModel, ScavengerTurnModel[] scavengerTurnModel) : base(actionName, actionTime, actionLevel, description, roomModel)
        {
            ScavengerTurnModel = scavengerTurnModel;
        }
    }
}