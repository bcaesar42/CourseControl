using UnityEngine;

namespace src.View.Rooms.ConcreteRooms
{
    public class DroneBay : BaseRoom
    {
        public DroneBay(BaseShip ship, System.Guid teamId) 
            : base(ship, "Drone Bay", 0, 3, new System.Guid(), teamId)
        {
        }

        public void OnMouseDown()
        {
            if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftControl))
            {
                Debug.Log("Right click");
                RemoveCrew();
            }
            else if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftControl))
            {
                Debug.Log("Left click");
                AddCrew();
            }
        }
    }
}
