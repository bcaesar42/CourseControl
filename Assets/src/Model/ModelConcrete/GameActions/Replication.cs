using System;
using System.Collections.Generic;
using src.Controller.TargetManager;
using src.Model.ModelFramework.ActionFramework;
using src.Model.ModelFramework.TargetableFramework;
using src.View.Rooms;
using src.View.Rooms.ConcreteRooms;
using UnityEngine;

namespace src.Model.ModelConcrete.GameActions
{
    public class Replication : GameAction
    {

        private List<ITargetable> targetList = new List<ITargetable>();
        TargetManager targetManager;
        public Replication(ActionModel actionModel, Guid actionId, Guid selfId, Guid teamId) : base(actionModel, actionId, selfId, teamId)
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
            BaseShip sh = (BaseShip)targetList[0];
            int crewCount = 0;
            foreach (BaseRoom r in sh.roomList)
            {
                if (r is ResearchCenter)
                    crewCount = r.GetCrewCount();
            }

            if (crewCount >= 3)
                sh.IncreaseCrewCount(1);
        }
    }
}
