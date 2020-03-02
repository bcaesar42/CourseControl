using System.Collections.Generic;
using src.Model.ModelFramework.Actionables;
using src.Model.ModelFramework.ActionFramework.ActionTurnModels;

namespace src.Model.ModelFramework.ActionFramework.ActionModels
{
    public class ShieldModel: ActionModel
    {
        public readonly IEnumerable<ShieldTurnModel> ShieldTurnModel;

        public ShieldModel(string actionName, ActionTime actionTime, int actionLevel, string description, string roomModel, IEnumerable<ShieldTurnModel> shieldTurnModel) : base(actionName, actionTime, actionLevel, description, roomModel)
        {
            ShieldTurnModel = shieldTurnModel;
        }
    }
}