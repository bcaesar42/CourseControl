using System;

namespace src.Model.ModelFramework.ActionFramework
{
    public abstract class ActionModel
    {
        //Fields shared by all action types
        public readonly string ActionName;
        public readonly Guid ActionModelId;
        public readonly ActionTime ActionTime;
        public readonly int ActionLevel;
        public readonly string Description;
        public readonly string RoomModel;
        public readonly ActionPriority Priority;
        
        //Where all the actions will use different fields
        public readonly ActionTurnModel[] ActionTurnModel;


        protected ActionModel(string actionName, ActionTime actionTime, int actionLevel, string description,
            string roomModel, ActionPriority priority, ActionTurnModel[] actionTurnModel)
        {
            ActionName = actionName;
            ActionTime = actionTime;
            ActionLevel = actionLevel;
            Description = description;
            RoomModel = roomModel;
            Priority = priority;

            ActionTurnModel = actionTurnModel;
        }
    }
}
