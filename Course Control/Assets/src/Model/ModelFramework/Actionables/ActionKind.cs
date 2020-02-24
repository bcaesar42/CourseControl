using System;
using src.Action;

namespace src.Model.ModelFramework.Actionables
{
    public abstract class ActionKind
    {
        public readonly Guid ActionKindId;
        public readonly ActionTime ActionTime;
        public readonly int ActionLevel;
        
        protected ActionKind(Guid actionKindId, ActionTime actionTime, int actionLevel)
        {
            ActionKindId = actionKindId;
            ActionTime = actionTime;
            ActionLevel = actionLevel;
        }
    }
}