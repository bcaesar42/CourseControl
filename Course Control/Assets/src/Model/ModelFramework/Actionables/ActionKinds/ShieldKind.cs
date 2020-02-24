using System;
using src.Action;

namespace src.Model.ModelFramework.Actionables.ActionKinds
{
    public class ShieldKind: ActionKind
    {
        public ShieldKind(string actionName, ActionTime actionTime, int actionLevel) : base(actionName, actionTime, actionLevel)
        {
        }
    }
}