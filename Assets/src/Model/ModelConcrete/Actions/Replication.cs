using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Transactions;
using src.Controller.TargetManager;
using src.Model.ModelFramework.ActionFramework;
using src.Model.ModelFramework.Targetables;
using UnityEditor;
using Action = src.Model.ModelFramework.ActionFramework.GameAction;

namespace src.Model.ModelConcrete.Actions
{
    public class Replication : Action
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
                playerShip.allocateCrew(1);
            }
        }
    }
}
