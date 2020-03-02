using System;
using System.Collections.Generic;
using src.Controller.TargetManager;
using src.Model.ModelFramework.Actionables;
using src.Model.ModelFramework.Actionables.ActionModels;
using src.Model.ModelFramework.Targetables;
using Action = src.Model.ModelFramework.Actionables.Action;

namespace src.Model.ModelConcrete.Actions
{
    public class Scavenger: ModelFramework.Actionables.Action
    {
        public Scavenger(TargetManager targetManager, Guid actionId, Guid actionInstanceId, Guid selfId, Guid teamId) : base(targetManager, actionId, actionInstanceId, selfId, teamId)
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