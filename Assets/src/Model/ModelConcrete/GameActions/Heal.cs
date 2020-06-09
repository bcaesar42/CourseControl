using System;
using System.Collections.Generic;
using src.Controller.TargetManager;
using src.Model.ModelFramework.ActionFramework;
using src.Model.ModelFramework.TargetableFramework;
using src.Model.ModelFramework.TargetableFramework.Damageable;
using UnityEngine;

namespace src.Model.ModelConcrete.GameActions
{
    public class Heal : GameAction
    {
        private List<ITargetable> targetList = new List<ITargetable>();
        TargetManager targetManager;
        public Heal(ActionModel actionModel, Guid actionId, Guid selfId, Guid teamId) : base(actionModel, actionId,
            selfId, teamId)
        {
            SceneManager sceneManager = GameObject.Find("SceneManager").transform.GetComponent<SceneManager>();
            targetManager = sceneManager.targetManager;
        }

        public override IEnumerable<ITargetable> AvailableTargets()
        {
            targetList.AddRange(targetManager.getSelf(SelfId));
            return targetManager.getEnemyByID(SelfId);
        }

        public override ActionModel GetActionModel()
        {
            return this.ActionModel;
        }

        public override bool IsValidActionModel(ActionModel actionModel)
        {
            return true;
        }

        protected override void DoAction(int roundNum, IEnumerable<ITargetable> targets)
        {
            int healAmount = this.ActionModel.ActionTurnModels[0].HealAmount.GetValueOrDefault(0);

            foreach (var targetable in targetList)
            {
                if (targetable is IHealable healable)
                {
                    healable.Heal(healAmount);
                }
            }
        }
    }
}
