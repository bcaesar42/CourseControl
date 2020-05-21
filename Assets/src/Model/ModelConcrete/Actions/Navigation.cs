using System;
using System.Collections.Generic;
using System.Linq;
using src.Controller.TargetManager;
using src.Model.ModelFramework.ActionFramework;
using src.Model.ModelFramework.Targetables;
using Action = src.Model.ModelFramework.ActionFramework.GameAction;

namespace src.Model.ModelConcrete.Actions
{
    public class Navigation : Action
    {
        private double _ChanceToDodge { get; set; } = .10;
        public double ChanceToDodge { get => _ChanceToDodge; }
        private TargetManager _TargetManager;
        public Navigation(TargetManager targetManager, Guid actionId, Guid actionInstanceId, Guid selfId, Guid teamId) :
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
            return _TargetManager.getAlliedID(SelfId);
        }

        protected override void DoAction(int roundNum, IEnumerable<ITargetable> targets)
        {
            //Seems like an action isn't really required for this room?
            if (ActionUsable)
            {
                _ChanceToDodge += .10;
                if (_ChanceToDodge > 1)
                {
                    _ChanceToDodge = 1;
                    ActionUsable = false;
                }  
            } else
            {
                _ChanceToDodge = .10;
            }
        }
    }
}
