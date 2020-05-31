using System;
using src.Model.ModelFramework.ActionFramework;
using src.Model.ModelFramework.Targetables.Crewable;
using UnityEngine;
using UnityEngine.UI;

namespace src.View.Rooms
{
    public abstract class BaseRoom : MonoBehaviour
    {
        private int roomCrewCount;
        private int roomMaxCrew;
        private int roomMinCrew;
        private Text CrewCountText;
        private readonly string RoomName;
        public ActionState State { get; set; } = ActionState.Deactivated;
        private BaseShip ship;
        public int upgradeCost;

        public BaseRoom(BaseShip ship, string roomName, int currentCrewCount, int maxCrewCount, Guid SelfId, Guid TeamId)
        {
            RoomName = roomName;
            roomMaxCrew = maxCrewCount;
            CrewCount = currentCrewCount;
            this.ship = ship;
            //roomAction gets instantiated as a concrete by the concrete class of Room being used.
        }

        private int MaxCrew
        {
            get => roomMaxCrew;
            set
            {
                if (value < 1)
                {
                    Debug.Log($"Error updating max crew count. Tried to update to {value}");
                    throw new ArgumentOutOfRangeException(nameof(MaxCrew));
                }

                roomMaxCrew = value;
            }
        }

        private int CrewCount
        {
            get => roomCrewCount;
            set
            {
                if (value > MaxCrew || value < 0)
                {
                    Debug.Log($"Error updating crew count. Tried to update to {value}");
                    throw new ArgumentOutOfRangeException(nameof(CrewCount));
                }

                roomCrewCount = value;
            }
        }

        private int MinCrewCount
        {
            get => roomMinCrew;
            set
            {
                if (value > MaxCrew || value < 1)
                {
                    Debug.Log($"Error updating mincrew count. Tried to update to {value}");
                    throw new ArgumentOutOfRangeException(nameof(CrewCount));
                }

                roomMinCrew = value;
            }
        }

        public void OnMouseDown()
        {
            if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftControl) && roomCrewCount < roomMaxCrew)
            {
                Debug.Log("Right click");
                ship.AllocateCrew(1);
            }
            else if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftControl) && roomCrewCount > 0)
            {
                Debug.Log("Left click");
                ship.FreeCrew(1);
            }
        }

        private void Start()
        {
            //Debug.Log($"Created {RoomName}.");

            //CrewCountText = GameObject.Find($"{RoomName.Replace(" ", "")}CrewCount").GetComponent<Text>();
            //CrewCountText.text = $"{CrewCount}";
        }

        // Update is called once per frame
        private void Update()
        {
            
        }

        public void AddCrew()
        {
            roomCrewCount++;
        }

        public void RemoveCrew()
        {
            roomCrewCount--;
        }

        public void ResetCrew()
        {
            roomCrewCount = 0;
        }

        public int GetCrewCount()
        {
            return roomCrewCount;
        }
    }
}
