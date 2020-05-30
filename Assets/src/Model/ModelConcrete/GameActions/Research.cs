using System;
using System.Collections.Generic;
using src.Model.ModelFramework.ActionFramework;
using src.Model.ModelFramework.TargetableFramework;

namespace src.Model.ModelConcrete.GameActions
{
    public class Research : GameAction
    {
        protected int researchTokens = 0;
        public Research(ActionModel actionModel, Guid actionId, Guid selfId, Guid teamId) : base(actionModel, actionId, selfId, teamId)
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
            return actionModel.ActionType == "research";
        }

        protected override void DoAction(int roundNum, IEnumerable<ITargetable> targets)
        {
            var turnModel = ActionModel.ActionTurnModels[roundNum];

            researchTokens += turnModel.TokensGained ?? 1;
            UnityEngine.Debug.Log($"{SelfId} has gained {turnModel.TokensGained} research tokens.\nTotal of {researchTokens} tokens.");
        }
    }
}
