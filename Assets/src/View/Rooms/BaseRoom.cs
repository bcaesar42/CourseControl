using System;
using src.Model.ModelFramework.ActionFramework;
using UnityEngine;
using UnityEngine.UI;

namespace src.View.Rooms
{
    public abstract class BaseRoom
    {
        private int roomCrewCount;
        private int roomMaxCrew;
        private int roomMinCrew;
        private Text CrewCountText;
        private readonly string RoomName;
        private GameAction roomAction;
        public readonly Guid SelfId;
        public readonly Guid TeamId;
        public BaseShip ship;
        public int upgradeCost = 5;
        public int upgradeLevel = 1;

        public BaseRoom(BaseShip ship, string roomName, int currentCrewCount, int maxCrewCount, Guid SelfId, Guid TeamId)
        {
            RoomName = roomName;
            MaxCrew = maxCrewCount;
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
            if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftControl) && roomCrewCount > roomMaxCrew)
            {
                Debug.Log("Right click");
                AddCrew();
                ship.allocateCrew(1);
            }
            else if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftControl) && roomCrewCount > 0)
            {
                Debug.Log("Left click");
                RemoveCrew();
                ship.freeCrew(1);
            }
        }

        private void Start()
        {
            Debug.Log($"Created {RoomName}.");

            CrewCountText = GameObject.Find($"{RoomName.Replace(" ", "")}CrewCount").GetComponent<Text>();
            CrewCountText.text = $"{CrewCount}";
        }

        // Update is called once per frame
        private void Update()
        {
            CrewCountText.text = $"{CrewCount}";
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

        abstract public void Upgrade();
    }
}
