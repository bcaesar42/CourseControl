using System;
using src.Action;

namespace src.Model.ModelFramework.Actionables.ActionKinds
{
    public class ScavengerKind: ActionKind
    {
        public ActionTime GetActionTime()
        {
            throw new System.NotImplementedException();
        }

        public ScavengerKind(Guid actionKindId, ActionTime actionTime, int actionLevel) : base(actionKindId, actionTime, actionLevel)
        {
        }
    }
}