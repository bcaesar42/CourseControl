using System;
using src.Action;

namespace src.Model.ModelFramework.Actionables.ActionKinds
{
    public class ResearchKind: ActionKind
    {
        public ResearchKind(string actionName, ActionTime actionTime, int actionLevel) : base(actionName, actionTime, actionLevel)
        {
        }
    }
}