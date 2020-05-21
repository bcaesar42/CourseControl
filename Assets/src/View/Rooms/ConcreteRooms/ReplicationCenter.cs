namespace src.View.Rooms.ConcreteRooms
{
    public class ReplicationCenter //: BaseRoom
    {
        public ReplicationCenter(BaseShip ship, System.Guid teamId) 
            : base(ship, "Replication Center", 0, 3, new System.Guid(), teamId)
        {
        }
    }
}
