using System.Collections.Generic;
using src.Model.ModelFramework.Actionables;
using src.Model.ModelFramework.ActionFramework.ActionTurnModels;

namespace src.Model.ModelFramework.ActionFramework.ActionModels
{
    public class ResearchModel: ActionModel
    {
        public readonly IEnumerable<ResearchTurnModel> ResearchTurnModel;
        
        public ResearchModel(string actionName, ActionTime actionTime, int actionLevel, string description,
            string roomModel, IEnumerable<ResearchTurnModel> researchTurnModel, ActionPriority priority) : base(actionName, actionTime, actionLevel, description, roomModel, priority)
        {
            ResearchTurnModel = researchTurnModel;
        }
    }
}