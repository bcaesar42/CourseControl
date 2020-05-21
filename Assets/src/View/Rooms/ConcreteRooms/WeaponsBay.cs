namespace src.View.Rooms.ConcreteRooms
{
    public class WeaponsBay //: BaseRoom
    {
        public WeaponsBay(BaseShip ship, System.Guid teamId)
            : base(ship, "Weapons Bay", 0, 3, new System.Guid(), teamId)
        {
        }
    }
}
