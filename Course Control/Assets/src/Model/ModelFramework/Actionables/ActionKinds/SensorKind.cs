using System;
using src.Action;

namespace src.Model.ModelFramework.Actionables.ActionKinds
{
    public class SensorKind: ActionKind
    {
        public SensorKind(string actionName, ActionTime actionTime, int actionLevel) : base(actionName, actionTime, actionLevel)
        {
        }
    }
}