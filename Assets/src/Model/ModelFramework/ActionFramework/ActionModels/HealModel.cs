using src.Model.ModelFramework.Actionables.ActionTurnModels;

namespace src.Model.ModelFramework.Actionables.ActionModels
{
    public class HealModel: ActionModel
    {
        public readonly HealTurnModel[] HealTurnModel;
        
        public HealModel(string actionName, ActionTime actionTime, int actionLevel, string description, string roomModel, HealTurnModel[] healTurnModel) : base(actionName, actionTime, actionLevel, description, roomModel)
        {
            HealTurnModel = healTurnModel;
        }
    }
}