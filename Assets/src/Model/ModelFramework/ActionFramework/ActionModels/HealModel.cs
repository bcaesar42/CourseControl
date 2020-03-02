using System.Collections.Generic;
using src.Model.ModelFramework.Actionables;
using src.Model.ModelFramework.ActionFramework.ActionTurnModels;

namespace src.Model.ModelFramework.ActionFramework.ActionModels
{
    public class HealModel: ActionModel
    {
        public readonly IEnumerable<HealTurnModel> HealTurnModel;
        
        public HealModel(string actionName, ActionTime actionTime, int actionLevel, string description,
            string roomModel, IEnumerable<HealTurnModel> healTurnModel, ActionPriority priority) : base(actionName, actionTime, actionLevel, description, roomModel, priority)
        {
            HealTurnModel = healTurnModel;
        }
    }
}