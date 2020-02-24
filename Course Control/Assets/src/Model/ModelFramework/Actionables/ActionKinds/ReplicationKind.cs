using System;
using src.Action;

namespace src.Model.ModelFramework.Actionables.ActionKinds
{
    public class ReplicationKind: ActionKind
    {
        public ReplicationKind(string actionName, ActionTime actionTime, int actionLevel) : base(actionName, actionTime, actionLevel)
        {
        }
    }
}