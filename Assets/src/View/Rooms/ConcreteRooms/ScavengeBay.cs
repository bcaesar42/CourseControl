using UnityEngine;

namespace src.View.Rooms.ConcreteRooms
{
    public class ScavengeBay : BaseRoom
    {
        public ScavengeBay(BaseShip ship, System.Guid teamId) 
            : base(ship, "Scavenge Bay", 0, 3, new System.Guid(), teamId)
        {
        }

        public override void newTurn()
        {
            Debug.Log("Not Implemented");
        }
    }
}
