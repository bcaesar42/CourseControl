using System;
using System.Collections.Generic;
using System.Linq;
using src.Controller.TargetManager;
using src.Model.ModelFramework.ActionFramework;
using src.Model.ModelFramework.Targetables;
using Action = src.Model.ModelFramework.ActionFramework.GameAction;

namespace src.Model.ModelConcrete.Actions
{
    public class Research : Action
    {
        private int _ResearchTokens { get; set; } = 0;
        public int ResearchTokens { get => _ResearchTokens; }
        private TargetManager _TargetManager;

        public Research(TargetManager targetManager, Guid actionId, Guid actionInstanceId, Guid selfId, Guid teamId) :
            base(targetManager, actionId, actionInstanceId, selfId, teamId)
        {
            _TargetManager = targetManager;
        }

        public override ActionModel GetActionModel()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<ITargetable> AvailableTargets()
        {
            yield return _TargetManager.getAlliedID(SelfId).FirstOrDefault();
        }

        protected override void DoAction(int roundNum, IEnumerable<ITargetable> targets)
        {
            if (ActionUsable)
            {
                _ResearchTokens++;
                ActionUsable = false;
            }
        }
    }
}
