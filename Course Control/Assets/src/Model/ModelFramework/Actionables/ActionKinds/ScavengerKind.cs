using System;
using src.Action;

namespace src.Model.ModelFramework.Actionables.ActionKinds
{
    public class ScavengerKind: ActionKind
    {
        public ScavengerKind(string actionName, ActionTime actionTime, int actionLevel) : base(actionName, actionTime, actionLevel)
        {
        }
    }
}