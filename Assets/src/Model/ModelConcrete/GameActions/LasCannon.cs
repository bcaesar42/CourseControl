using System;
using System.Collections.Generic;
using src.Controller.TargetManager;
using src.Model.ModelFramework.ActionFramework;
using src.Model.ModelFramework.TargetableFramework;
using src.Model.ModelFramework.TargetableFramework.Damageable;
using src.Model.ModelFramework.TargetableFramework.Shieldable;
using UnityEngine;

namespace src.Model.ModelConcrete.GameActions
{
    public class LasCannon : GameAction
    {
        private List<ITargetable> targetList = new List<ITargetable>();
        TargetManager targetManager;

        public LasCannon(ActionModel actionModel, Guid actionId, Guid selfId, Guid teamId) : base(actionModel, actionId, selfId, teamId)
        {
            SceneManager sceneManager = GameObject.Find("SceneManager").transform.GetComponent<SceneManager>();
            targetManager = sceneManager.targetManager;
            
        }

        public override IEnumerable<ITargetable> AvailableTargets()
        {
           targetList.AddRange(targetManager.getEnemyByID(SelfId));
           return targetManager.getEnemyByID(SelfId);
        }

        public override ActionModel GetActionModel()
        {
            return this.ActionModel;
        }

        public override bool IsValidActionModel(ActionModel actionModel)
        {
                return true; //hard coded in so I can test. Not sure how/what the purpose of this method does wrt GameACtion line 30
        }

        protected override void DoAction(int roundNum, IEnumerable<ITargetable> targets)
        {
            foreach(ITargetable i in targetList)
            {
                if (i is BaseShip)
                {
                    var sh = (BaseShip)i;
                    if (!sh.didEvade())
                    {
                        if (sh.CurrentShieldCount() > 0)
                            sh.DamageShield(1);
                        else
                            sh.Damage(ActionModel.ActionTurnModels[0].DamagePerShot.GetValueOrDefault(0));
                    }
                }

                else if (i is IDamageable && i is IShieldable)
                {
                    var s = (IShieldable)i;
                    var d = (IDamageable)i;
                    if (s.CurrentShieldCount() > 0)
                    {
                        s.DamageShield(1);
                    }
                    else
                        d.Damage(ActionModel.ActionTurnModels[0].DamagePerShot.GetValueOrDefault(0));
                }

                else if (i is IDamageable)
                {
                    var d = (IDamageable)i;
                    d.Damage(ActionModel.ActionTurnModels[0].DamagePerShot.GetValueOrDefault(0));
                }
            }
            targetList.Clear();
        }
    }
}
