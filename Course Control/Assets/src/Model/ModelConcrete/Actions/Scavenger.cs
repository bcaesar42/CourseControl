using System;
using src.Action;

namespace src.Model.ModelFramework.Actionables.ActionKinds
{
    public class Scavenger: Action
    {
        public Scavenger(string actionName, ActionTime actionTime, int actionLevel) : base(actionName, actionTime, actionLevel)
        {
        }
    }
}