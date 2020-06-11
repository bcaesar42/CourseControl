using System;
using System.Collections.Generic;
using src.Controller;
using src.Controller.TargetManager;
using src.Model.ModelConcrete.Ships;
using src.Model.ModelFramework.ActionFramework;
using src.Model.ModelFramework.TargetableFramework;
using src.Model.ModelFramework.TargetableFramework.Damageable;
using src.Model.ModelFramework.TargetableFramework.Shieldable;
using src.View.Rooms;
using src.View.Rooms.ConcreteRooms;
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



            List<ITargetable> sList = new List<ITargetable>();
            sList.AddRange(targetManager.getSelf(SelfId));
            BaseShip ship = (BaseShip)sList[0];

            int crewMult = 1;
            foreach (BaseRoom r in ship.roomList)
            {
                if (r is WeaponsBay)
                    crewMult = r.GetCrewCount();
            }

            PlayerLog eventLog = GameObject.Find("EventLog").GetComponent<PlayerLog>();

            foreach (ITargetable i in targetList)
            {
                if (i is BaseShip)
                {
                    var sh = (BaseShip)i;

                    if (!sh.didEvade())
                    {
                        if (sh.CurrentShieldCount() > 0)
                        {
                            sh.DamageShield(1);
                            eventLog.AddEvent("Struck enemy shield! " + sh.CurrentShieldCount() + " shields remaining!");
                        }
                        else
                        {
                            sh.Damage(ActionModel.ActionTurnModels[0].DamagePerShot.GetValueOrDefault(0) * crewMult);
                            eventLog.AddEvent("Struck enemy hull for " + ActionModel.ActionTurnModels[0].DamagePerShot.GetValueOrDefault(0) * crewMult + ", they have " + sh.CurrentHP() + " hull remaining!");
                        }
                    }
                }

                else if (i is IDamageable && i is IShieldable)
                {
                    var s = (IShieldable)i;
                    var d = (IDamageable)i;
                    if (s.CurrentShieldCount() > 0)
                    {
                        s.DamageShield(1);
                        eventLog.AddEvent("Struck enemy shield! " + s.CurrentShieldCount() + " shields remaining!");
                    }
                    else
                    {
                        d.Damage(ActionModel.ActionTurnModels[0].DamagePerShot.GetValueOrDefault(0) * crewMult);
                        eventLog.AddEvent("Struck enemy hull for " + ActionModel.ActionTurnModels[0].DamagePerShot.GetValueOrDefault(0) * crewMult + ", they have " + d.CurrentHP() + " hull remaining!");
                    }
                }

                else if (i is IDamageable)
                {
                    var d = (IDamageable)i;
                    d.Damage(ActionModel.ActionTurnModels[0].DamagePerShot.GetValueOrDefault(0) * crewMult);
                    eventLog.AddEvent("Struck enemy hull for " + ActionModel.ActionTurnModels[0].DamagePerShot.GetValueOrDefault(0) * crewMult + ", they have " + d.CurrentHP() + " hull remaining!");
                }
            }
            targetList.Clear();
        }
    }
}
