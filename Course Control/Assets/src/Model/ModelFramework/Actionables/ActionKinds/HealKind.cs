using System;
using src.Action;

namespace src.Model.ModelFramework.Actionables.ActionKinds
{
    public class HealKind: ActionKind
    {
        public HealKind(string actionName, ActionTime actionTime, int actionLevel) : base(actionName, actionTime, actionLevel)
        {
        }
    }
}