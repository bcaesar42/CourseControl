using System;
using System.Collections.Generic;
using src.Controller;
using src.Controller.TargetManager;
using src.Model.ModelFramework.ActionFramework;
using src.Model.ModelFramework.TargetableFramework;
using src.View.Rooms;
using src.View.Rooms.ConcreteRooms;
using UnityEngine;

namespace src.Model.ModelConcrete.GameActions
{
    public class Shield : GameAction
    {
        private List<ITargetable> targetList = new List<ITargetable>();
        TargetManager targetManager;

        public Shield(ActionModel actionModel, Guid actionId, Guid selfId, Guid teamId) : base(actionModel, actionId, selfId, teamId)
        {
            SceneManager sceneManager = GameObject.Find("SceneManager").transform.GetComponent<SceneManager>();
            targetManager = sceneManager.targetManager;

        }

        public override IEnumerable<ITargetable> AvailableTargets()
        {
            targetList.AddRange(targetManager.getSelf(SelfId));
            return targetManager.getSelf(SelfId);
        }

        public override ActionModel GetActionModel()
        {
            return this.ActionModel;
        }

        public override bool IsValidActionModel(ActionModel actionModel)
        {
            return true;
        }

        protected override void DoAction(int roundsLeft, IEnumerable<ITargetable> targets)
        {
            BaseShip sh = (BaseShip)targetList[0];
            int crewMult = 1;
            foreach (BaseRoom r in sh.roomList)
            {
                if (r is ShieldBay)
                    crewMult = r.GetCrewCount();
            }

            sh.ActivateShield(ActionModel.ActionTurnModels[0].ShieldCount.GetValueOrDefault(0) * crewMult);
        
        }
    }
}
