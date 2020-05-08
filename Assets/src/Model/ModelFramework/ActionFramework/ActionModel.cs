using System;
using System.Collections.Generic;

namespace src.Model.ModelFramework.ActionFramework
{
    public class ActionModel
    {
        //Fields shared by all action types
        public string ActionName;
        public string ActionType;
        public Guid ActionId;
        public ActionTime ActionTime;
        public int ActionLevel;
        public string Description;
        public string RoomModel;
        public string DamagedRoomModel;
        public ActionPriority Priority;
        
        //Where all the actions will use different fields
        public ActionTurnModel[] ActionTurnModels;
    }
}
