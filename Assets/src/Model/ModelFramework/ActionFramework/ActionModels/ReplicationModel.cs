using System.Collections.Generic;
using src.Model.ModelFramework.Actionables;
using src.Model.ModelFramework.ActionFramework.ActionTurnModels;

namespace src.Model.ModelFramework.ActionFramework.ActionModels
{
    public class ReplicationModel: ActionModel
    {
        public readonly IEnumerable<ReplicationTurnModel> ReplicationTurnModel;
        
        public ReplicationModel(string actionName, ActionTime actionTime, int actionLevel, string description,
            string roomModel, IEnumerable<ReplicationTurnModel> replicationTurnModel, ActionPriority priority) : base(actionName, actionTime, actionLevel, description, roomModel, priority)
        {
            ReplicationTurnModel = replicationTurnModel;
        }
    }
}