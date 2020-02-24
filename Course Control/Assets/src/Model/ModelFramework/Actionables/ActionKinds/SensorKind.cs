using System;
using src.Action;

namespace src.Model.ModelFramework.Actionables.ActionKinds
{
    public class SensorKind: ActionKind
    {
        public ActionTime GetActionTime()
        {
            throw new System.NotImplementedException();
        }

        public SensorKind(Guid actionKindId, ActionTime actionTime, int actionLevel) : base(actionKindId, actionTime, actionLevel)
        {
        }
    }
}