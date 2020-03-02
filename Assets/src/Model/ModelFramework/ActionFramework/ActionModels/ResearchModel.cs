using src.Model.ModelFramework.Actionables.ActionTurnModels;

namespace src.Model.ModelFramework.Actionables.ActionModels
{
    public class ResearchModel: ActionModel
    {
        public readonly ResearchTurnModel[] ResearchTurnModel;
        
        public ResearchModel(string actionName, ActionTime actionTime, int actionLevel, string description, string roomModel, ResearchTurnModel[] researchTurnModel) : base(actionName, actionTime, actionLevel, description, roomModel)
        {
            ResearchTurnModel = researchTurnModel;
        }
    }
}