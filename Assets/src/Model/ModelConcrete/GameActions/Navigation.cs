using System;
using System.Collections.Generic;
using src.Controller.TargetManager;
using src.Model.ModelFramework.ActionFramework;
using src.Model.ModelFramework.Targetables;

namespace src.Model.ModelConcrete.GameActions
{
    public class Navigation : GameAction
    {
        public Navigation(ActionModel actionModel, Guid actionId, Guid selfId, Guid teamId) : base(actionModel, actionId, selfId, teamId)
        {
        }

        public override IEnumerable<ITargetable> AvailableTargets()
        {
            throw new NotImplementedException();
        }

        public override bool IsValidActionModel(ActionModel actionModel)
        {
            throw new NotImplementedException();
        }

        protected override void DoAction(int roundNum, IEnumerable<ITargetable> targets)
        {
            throw new NotImplementedException();
        }
    }
}
