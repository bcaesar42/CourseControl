using System;
using System.Collections.Generic;
using src.Controller.ActionKindManager;
using src.Controller.TargetManager;
using src.Model.ModelFramework.ActionFramework;
using src.Model.ModelFramework.ActionFramework.ActionModels;
using src.Model.ModelFramework.Targetables;
using src.Model.ModelFramework.Targetables.Damageable;
using Action = src.Model.ModelFramework.ActionFramework.GameAction;

namespace src.Model.ModelConcrete.GameActions
{
    public class Heal : Action
    {
        private ActionModel _actionModel;
        
        public Heal(TargetManager targetManager, Guid actionId, Guid actionInstanceId, Guid selfId, Guid teamId) : base(
            targetManager, actionId, actionInstanceId, selfId, teamId)
        {
            this._actionModel = ActionManager.instance.GetActionModel<HealModel>(actionId, 1);
        }

        public override ActionModel GetActionModel()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<ITargetable> AvailableTargets()
        {
            throw new NotImplementedException();
        }

        protected override void DoAction(int roundNum, IEnumerable<ITargetable> targets)
        {
            int healamount = 0;
            //TODO get heal amount from actionModelManager
            
            foreach (var targetable in targets)
            {
                if (targetable is IHealable healable)
                {
                    healable.Heal(healamount);
                }
            }
        }
    }
}
