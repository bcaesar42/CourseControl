using System;
using src.Model.ModelFramework.ActionFramework;

namespace src.Model.ModelFramework.ShipFramework
{
    public class ShipModel
    {
        public string Name;
        public Guid ShipId;
        public string Description;

        public string ShipModelFile;

        public Guid GameActionId1;
        public Guid GameActionId2;
        public Guid GameActionId3;
        public Guid GameActionId4;
        public Guid GameActionId5;
        public Guid GameActionId6;
        public Guid GameActionId7;

        public int InitialCrewCount;

        public int InitialMaxHealth;
        public int MaxShield;
    }
}
