namespace src.View.Rooms.ConcreteRooms
{
    public class ResearchCenter : BaseRoom
    {
        public ResearchCenter(BaseShip ship, System.Guid teamId) 
            : base(ship, "Research Center", 0, 3, new System.Guid(), teamId)
        {
        }

        public override void newTurn()
        {
            throw new System.NotImplementedException();
        }
    }
}
