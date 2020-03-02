using src.Model.ModelFramework.Actionables.ActionTurnModels;

namespace src.Model.ModelFramework.Actionables.ActionModels
{
    public class ShieldModel: ActionModel
    {
        public readonly ShieldTurnModel[] ShieldTurnModel;

        public ShieldModel(string actionName, ActionTime actionTime, int actionLevel, string description, string roomModel, ShieldTurnModel[] shieldTurnModel) : base(actionName, actionTime, actionLevel, description, roomModel)
        {
            ShieldTurnModel = shieldTurnModel;
        }
    }
}