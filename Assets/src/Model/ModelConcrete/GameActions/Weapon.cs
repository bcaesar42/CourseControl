using System;
using System.Collections.Generic;
using System.Linq;
using src.Model.ModelFramework.ActionFramework;
using src.Model.ModelFramework.TargetableFramework;
using src.Model.ModelFramework.TargetableFramework.Damageable;
using UnityEngine;
using Random = System.Random;

namespace src.Model.ModelConcrete.GameActions
{
    public class Weapon : GameAction
    {
        private Random chanceToHitGen;

        public Weapon(ActionModel actionModel, Guid actionId, Guid selfId, Guid teamId) : base(actionModel, actionId,
            selfId, teamId)
        {
            chanceToHitGen = new Random();
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
            return actionModel.ActionType == "weapon";
        }

        protected override void
            DoAction(int roundNum, IEnumerable<ITargetable> targets)
        {
            if (roundNum >= ActionModel.ActionTurnModels.Length)
            {
                Debug.Log(
                    $"Heal action with Id: {ActionInstanceId} had round num of: {roundNum} when its round num should have ended at: {ActionModel.ActionTurnModels.Length}");
                return;
            }

            var turnModel = ActionModel.ActionTurnModels[roundNum];
            var targetables = targets as ITargetable[] ?? targets.ToArray();
            for (int i = 0; i < turnModel.ShotsFired; i++)
            {
                foreach (var targetable in targetables)
                {
                    if (turnModel.GuaranteedHit.GetValueOrDefault(false) || turnModel.ChanceToHit.GetValueOrDefault(0) >
                        (int)(chanceToHitGen.NextDouble() * 99))
                    {
                        if (targetable is IDamageable damageable)
                        {
                            damageable.Damage(turnModel.DamagePerShot.GetValueOrDefault(0));
                            damageable.Damage(turnModel.DamagePerShotIgnoreShield.GetValueOrDefault(0));
                            damageable.DecreaseMaxHealth(turnModel.DecreaseMaxHealthAmount.GetValueOrDefault(0));
                            //Need to add chanceToDisableRoom call
                        }

                        if (targetable is IHealable healable)
                        {
                            healable.Heal(turnModel.HealAmount.GetValueOrDefault(0));
                            healable.IncreaseMaxHealth(turnModel.IncreaseMaxHealthAmount.GetValueOrDefault(0));
                        }
                    }
                }
            }
        }
    }
}
