namespace src.View.Rooms.ConcreteRooms
{
    public class NavigationRoom : BaseRoom
    {
        public NavigationRoom(BaseShip ship, System.Guid teamId) 
            : base(ship, "Navigation Room", 0, 3, new System.Guid(), teamId)
        {
        }
    }
}
