namespace src.View.Rooms.ConcreteRooms
{
    public class DroneBay : BaseRoom
    {
        public DroneBay(BaseShip ship, System.Guid teamId) 
            : base(ship, "Drone Bay", 0, 3, new System.Guid(), teamId)
        {
        }
    }
}
