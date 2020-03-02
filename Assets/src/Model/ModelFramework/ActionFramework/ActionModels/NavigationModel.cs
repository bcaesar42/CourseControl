using System.Collections.Generic;
using src.Model.ModelFramework.Actionables;
using src.Model.ModelFramework.ActionFramework.ActionTurnModels;

namespace src.Model.ModelFramework.ActionFramework.ActionModels
{
    public class NavigationModel: ActionModel
    {
        public readonly IEnumerable<NavigationTurnModel> NavigationTurnModel;
        
        public NavigationModel(string actionName, ActionTime actionTime, int actionLevel, string description,
            string roomModel, IEnumerable<NavigationTurnModel> navigationTurnModel, ActionPriority priority) : base(actionName, actionTime, actionLevel, description, roomModel, priority)
        {
            NavigationTurnModel = navigationTurnModel;
        }
    }
}