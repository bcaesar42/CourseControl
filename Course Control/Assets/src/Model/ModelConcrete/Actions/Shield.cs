using System;
using src.Action;

namespace src.Model.ModelFramework.Actionables.ActionKinds
{
    public class Shield: Action
    {
        public Shield(string actionName, ActionTime actionTime, int actionLevel) : base(actionName, actionTime, actionLevel)
        {
        }
    }
}