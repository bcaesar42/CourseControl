using System;
using System.Collections.Generic;
using System.Linq;
using src.Controller.TargetManager;
using src.Model.ModelFramework.ActionFramework;
using src.Model.ModelFramework.TargetableFramework;

namespace src.Model.ModelConcrete.Actions
{
    public class Replication : GameAction
    {
        private TargetManager _TargetManger { get; set; }
        

        public Replication(TargetManager targetManager, Guid actionId, Guid actionInstanceId, Guid selfId, Guid teamId)
            : base(targetManager, actionId, actionInstanceId, selfId, teamId)
        {
            CurrentState = ActionState.Ready;
        }

        public override ActionModel GetActionModel()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<ITargetable> AvailableTargets()
        {
            return _TargetManger.getAlliedID(SelfId);
        }

        protected override void DoAction(int roundNum, IEnumerable<ITargetable> targets)
        {
            if (ActionUsable)
            {
                BaseShip playerShip = (BaseShip)AvailableTargets().FirstOrDefault();
                playerShip.AllocateCrew(1);
            }
        }

        public override bool IsValidActionModel(ActionModel actionModel)
        {
            throw new NotImplementedException();
        }
    }
}
