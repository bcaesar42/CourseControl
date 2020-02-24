using System;
using src.Action;

namespace src.Model.ModelFramework.Actionables.ActionKinds
{
    public class Navigation: Action
    {
        public Navigation(String actionName, ActionTime actionTime, int actionLevel) : base(actionName, actionTime, actionLevel)
        {
        }
    }
}