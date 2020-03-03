using System.Collections.Generic;
using src.Model.ModelFramework.ActionFramework.ActionTurnModels;

namespace src.Model.ModelFramework.ActionFramework.ActionModels
{
    public class ScavengerModel : ActionModel
    {
        public readonly IEnumerable<ScavengerTurnModel> ScavengerTurnModel;

        public ScavengerModel(string actionName, ActionTime actionTime, int actionLevel, string description,
            string roomModel, IEnumerable<ScavengerTurnModel> scavengerTurnModel, ActionPriority priority) : base(
            actionName, actionTime, actionLevel, description, roomModel, priority)
        {
            ScavengerTurnModel = scavengerTurnModel;
        }
    }
}