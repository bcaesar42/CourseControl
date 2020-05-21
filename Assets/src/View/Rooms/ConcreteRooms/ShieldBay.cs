namespace src.View.Rooms.ConcreteRooms
{
    public class ShieldBay : BaseRoom
    {
        public ShieldBay(BaseShip ship, System.Guid teamId)
            : base(ship, "Shield Bay", 0, 3, new System.Guid(), teamId)
        {
        }
    }
}
