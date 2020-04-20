﻿namespace src.View.Rooms.ConcreteRooms
{
    public class MaintenanceBay : BaseRoom
    {
        public MaintenanceBay(BaseShip ship, System.Guid teamId) 
            : base(ship, "Maintenance Bay", 0, 3, new System.Guid(), teamId)
        {
        }
    }
}
