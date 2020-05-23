namespace src.View.Rooms.ConcreteRooms
{
    public class ResearchCenter : BaseRoom
    {
        public ResearchCenter(BaseShip ship, System.Guid teamId) 
            : base(ship, "Research Center", 0, 3, new System.Guid(), teamId)
        {
        }

        /*
        public override void Upgrade()
        {
            if (upgradeLevel < 3)
            {
                upgradeLevel++;
                //need to adjust other aspects of room on successful upgrade
            }
        }
        */
    }
}
