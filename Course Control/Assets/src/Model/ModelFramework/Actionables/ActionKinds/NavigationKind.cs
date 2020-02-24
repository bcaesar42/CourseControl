using System;
using src.Action;

namespace src.Model.ModelFramework.Actionables.ActionKinds
{
    public class NavigationKind: ActionKind
    {
        public NavigationKind(string actionName, ActionTime actionTime, int actionLevel) : base(actionName, actionTime, actionLevel)
        {
        }
    }
}