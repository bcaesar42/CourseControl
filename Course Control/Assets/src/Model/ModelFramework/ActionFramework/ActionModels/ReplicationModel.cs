using src.Model.ModelFramework.Actionables.ActionTurnModels;

namespace src.Model.ModelFramework.Actionables.ActionModels
{
    public class ReplicationModel: ActionModel
    {
        public readonly ReplicationTurnModel[] ReplicationTurnModel;
        
        public ReplicationModel(string actionName, ActionTime actionTime, int actionLevel, string description, string roomModel, ReplicationTurnModel[] replicationTurnModel) : base(actionName, actionTime, actionLevel, description, roomModel)
        {
            ReplicationTurnModel = replicationTurnModel;
        }
    }
}