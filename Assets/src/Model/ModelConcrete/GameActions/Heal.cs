using System;
using System.Collections.Generic;
using src.Model.ModelFramework.ActionFramework;
using src.Model.ModelFramework.TargetableFramework;
using src.Model.ModelFramework.TargetableFramework.Damageable;
using src.Model.ModelFramework.Targetables;
using UnityEngine;

namespace src.Model.ModelConcrete.GameActions
{
    public class Heal : GameAction
    {
        public Heal(ActionModel actionModel, Guid actionId, Guid selfId, Guid teamId) : base(actionModel, actionId,
            selfId, teamId)
        {
        }

        public override IEnumerable<ITargetable> AvailableTargets()
        {
            throw new NotImplementedException();
        }

        public override bool IsValidActionModel(ActionModel actionModel)
        {
            return actionModel.ActionType == "heal";
        }

        protected override void DoAction(int roundNum, IEnumerable<ITargetable> targets)
        {
            if (roundNum >= ActionModel.ActionTurnModels.Length)
            {
                Debug.Log(
                    $"Heal action with Id: {ActionInstanceId} had round num of: {roundNum} when its round num should have ended at: {ActionModel.ActionTurnModels.Length}");
                return;
            }

            int healAmount = this.ActionModel.ActionTurnModels[roundNum].HealAmount.GetValueOrDefault(0);
            int maxIncreaseAmount = this.ActionModel.ActionTurnModels[roundNum].IncreaseMaxHealthAmount.GetValueOrDefault(0);
            int maxDecreaseAmount = this.ActionModel.ActionTurnModels[roundNum].DecreaseMaxHealthAmount.GetValueOrDefault(0);

            foreach (var targetable in targets)
            {
                if (targetable is IHealable healable)
                {
                    healable.Heal(healAmount);
                    healable.IncreaseMaxHealth(maxIncreaseAmount);
                    healable.DecreaseMaxHealth(maxDecreaseAmount);
                }
            }
        }
    }
}
