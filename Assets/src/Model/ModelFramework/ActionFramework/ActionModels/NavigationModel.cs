using src.Model.ModelFramework.Actionables.ActionTurnModels;

namespace src.Model.ModelFramework.Actionables.ActionModels
{
    public class NavigationModel: ActionModel
    {
        public readonly NavigationTurnModel[] NavigationTurnModel;
        
        public NavigationModel(string actionName, ActionTime actionTime, int actionLevel, string description, string roomModel, NavigationTurnModel[] navigationTurnModel) : base(actionName, actionTime, actionLevel, description, roomModel)
        {
            NavigationTurnModel = navigationTurnModel;
        }
    }
}