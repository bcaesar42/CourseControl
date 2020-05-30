using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using src.Controller.ShipModelManager;
using src.Controller.TargetManager;
using src.Model.ModelFramework.ActionFramework;
using src.Model.ModelFramework.TargetableFramework;
using src.Model.ModelFramework.Targetables.Crewable;
using UnityEngine;

namespace src.Model.ModelConcrete.GameActions
{
    public class Replication : GameAction
    {
        System.Random random = new System.Random();
        public Replication(ActionModel actionModel, Guid actionId, Guid selfId, Guid teamId) : base(actionModel, actionId, selfId, teamId)
        {
        }

        public override IEnumerable<ITargetable> AvailableTargets()
        {
            throw new NotImplementedException();
        }

        public override ActionModel GetActionModel()
        {
            throw new NotImplementedException();
        }

        public override bool IsValidActionModel(ActionModel actionModel)
        {
            return actionModel.ActionType == "replication";
        }

        protected override void DoAction(int roundNum, IEnumerable<ITargetable> targets)
        {
            int increaseCount = 1;
            var turnModel = ActionModel.ActionTurnModels[roundNum];
            var targetables = targets as ITargetable[] ?? targets.ToArray();
            foreach (var targetable in targetables)
            {
                if ((random.Next(25) + turnModel.ChanceToIncreaseTotalCrewCount) > 99)
                {
                    if (targetable is ICrewable crewable)
                    {
                        crewable.IncreaseCrewCount(turnModel.IncreaseTotalCrewCount ?? increaseCount);
                        UnityEngine.Debug.Log($"Increased crew for {targetable.GetSelfId()} by {turnModel.IncreaseTotalCrewCount ?? increaseCount}");
                    }
                } else
                {
                    UnityEngine.Debug.Log($"{targetable.GetSelfId()} failed to increase crew because the chance was too low.");
                }
            }
        }
    }
}
