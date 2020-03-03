namespace src.Model.ModelFramework.ActionFramework
{
    public abstract class ActionModel
    {
        public readonly int ActionLevel;
        public readonly string ActionName;
        public readonly ActionTime ActionTime;
        public readonly string Description;
        public readonly ActionPriority Priority;
        public readonly string RoomModel;

        protected ActionModel(string actionName, ActionTime actionTime, int actionLevel, string description,
            string roomModel, ActionPriority priority)
        {
            ActionName = actionName;
            ActionTime = actionTime;
            ActionLevel = actionLevel;
            Description = description;
            RoomModel = roomModel;
            Priority = priority;
        }
    }
}