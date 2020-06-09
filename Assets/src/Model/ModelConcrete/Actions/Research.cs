using System;
using System.Collections.Generic;
using System.Linq;
using src.Controller.TargetManager;
using src.Model.ModelFramework.ActionFramework;
using src.Model.ModelFramework.TargetableFramework;
using src.View.Rooms;

namespace src.Model.ModelConcrete.Actions
{
    public class Research : GameAction
    {
        private int _ResearchTokens { get; set; } = 0;
        public int ResearchTokens { get => _ResearchTokens; }
        private TargetManager _TargetManager;

        public Research(TargetManager targetManager, ActionModel actionModel, Guid actionInstanceId, Guid selfId, Guid teamId) :
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
            if (ActionUsable)
            {
                _ResearchTokens++;
                ActionUsable = false;
            }
        }

        public void UpgradeRoom(BaseRoom room)
        {
            if (ResearchTokens >= room.upgradeCost)
            {
                _ResearchTokens -= room.upgradeCost;
                //room.Upgrade();
            }
        }

        public override bool IsValidActionModel(ActionModel actionModel)
        {
            throw new NotImplementedException();
        }
    }
}
