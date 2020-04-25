using System;
using System.Collections.Generic;
using src.Model.ModelFramework.ActionFramework;
using src.Model.ModelFramework.Targetables;
using Action = src.Model.ModelFramework.ActionFramework.GameAction;

namespace src.Model.ModelConcrete.GameActions
{
    public class Drone : Action
    {
        public Drone(ActionModel actionModel, Guid actionId, Guid selfId, Guid teamId) :
            base(actionModel, actionId, selfId, teamId)
        {
        }

        public override ActionModel GetActionModel()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<ITargetable> AvailableTargets()
        {
            throw new NotImplementedException();
        }

        protected override void DoAction(int roundNum, IEnumerable<ITargetable> targets)
        {
            throw new NotImplementedException();
        }
    }
}
