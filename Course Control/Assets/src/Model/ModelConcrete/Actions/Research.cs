using System;
using src.Action;

namespace src.Model.ModelFramework.Actionables.ActionKinds
{
    public class Research: Action
    {
        public Research(string actionName, ActionTime actionTime, int actionLevel) : base(actionName, actionTime, actionLevel)
        {
        }
    }
}