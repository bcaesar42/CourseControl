using System;
using System.Collections.Generic;
using src.Controller.TargetManager;
using src.Model.ModelFramework.ActionFramework;
using src.Model.ModelFramework.Targetables;
using Action = src.Model.ModelFramework.ActionFramework.GameAction;

namespace src.Model.ModelConcrete.Actions
{
    public class Weapon : Action
    {
        public Weapon(TargetManager targetManager, Guid actionId, Guid actionInstanceId, Guid selfId, Guid teamId) :
            base(targetManager, actionId, actionInstanceId, selfId, teamId)
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
