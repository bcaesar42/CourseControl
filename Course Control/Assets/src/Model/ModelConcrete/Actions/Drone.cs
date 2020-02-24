using System;
using src.Action;

namespace src.Model.ModelFramework.Actionables.ActionKinds
{
    public class DroneKind: ActionKind
    {
        public DroneKind(string actionName, ActionTime actionTime, int actionLevel) : base(actionName, actionTime, actionLevel)
        {
        }
    }
}