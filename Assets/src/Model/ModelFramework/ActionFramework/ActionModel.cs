namespace src.Model.ModelFramework.Actionables
{
    public abstract class ActionModel
    {
        public readonly string ActionName;
        public readonly ActionTime ActionTime;
        public readonly int ActionLevel;
        public readonly string Description;
        public readonly string RoomModel;
        
        protected ActionModel(string actionName, ActionTime actionTime, int actionLevel, string description, string roomModel)
        {
            ActionName = actionName;
            ActionTime = actionTime;
            ActionLevel = actionLevel;
            Description = description;
            RoomModel = roomModel;
        }
    }
}