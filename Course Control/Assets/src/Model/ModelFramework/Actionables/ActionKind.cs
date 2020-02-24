using System;
using src.Action;

namespace src.Model.ModelFramework.Actionables
{
    public abstract class ActionKind
    {
        public readonly string ActionName;
        public readonly ActionTime ActionTime;
        public readonly int ActionLevel;
        public readonly string Description;
        public readonly string RoomModel;
        
        protected ActionKind(string actionName, ActionTime actionTime, int actionLevel, string description, string roomModel)
        {
            ActionName = actionName;
            ActionTime = actionTime;
            ActionLevel = actionLevel;
            Description = description;
            RoomModel = roomModel;
        }
    }
}