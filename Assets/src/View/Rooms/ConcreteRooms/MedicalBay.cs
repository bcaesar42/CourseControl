using src.Model.ModelConcrete.Ships;
using UnityEngine;

namespace src.View.Rooms.ConcreteRooms
{
    public class MedicalBay : BaseRoom
    {
        public MedicalBay(BaseShip ship, System.Guid teamId) 
            : base(ship, "Medical Bay", 0, 3, new System.Guid(), teamId)
        {
        }

        public override void newTurn()
        {
            Debug.Log("Not Implemented");
        }
    }
}
