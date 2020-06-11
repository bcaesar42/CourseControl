using System;
using System.Collections.Generic;
using System.Linq;
using src.Controller.TargetManager;
using src.Model.ModelFramework.ActionFramework;
using src.Model.ModelFramework.TargetableFramework;

namespace src.Model.ModelConcrete.Actions
{
    public class Navigation : GameAction
    {
        private double _ChanceToDodge { get; set; } = .10;
        public double ChanceToDodge { get => _ChanceToDodge; }
        private TargetManager _TargetManager;
        public Navigation(TargetManager targetManager, ActionModel actionModel, Guid actionInstanceId, Guid selfId, Guid teamId) :
            base(actionModel, actionInstanceId, selfId, teamId) //TODO, get actionModel passed in
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

        public override bool IsValidActionModel(ActionModel actionModel)
        {
            throw new NotImplementedException();
        }
    }
}
