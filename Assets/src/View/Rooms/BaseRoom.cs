using System;
using src.Model.ModelFramework.ActionFramework;
using UnityEngine;
using UnityEngine.UI;

namespace src.View.Rooms
{
    public abstract class BaseRoom : MonoBehaviour
    {
        private int _crewCount;

        private int _maxCrew;
        private Text CrewCountText;
        private readonly string RoomName;
        private GameAction roomAction;

        public BaseRoom(string roomName, int currentCrewCount, int maxCrewCount)
        {
            RoomName = roomName;
            MaxCrew = maxCrewCount;
            CrewCount = currentCrewCount;
            //roomAction gets instantiated as a concrete by the concrete class of Room being used.
        }

        private int MaxCrew
        {
            get => _maxCrew;
            set
            {
                if (value < 1)
                {
                    Debug.Log($"Error updating max crew count. Tried to update to {value}");
                    throw new ArgumentOutOfRangeException(nameof(MaxCrew));
                }

                _maxCrew = value;
            }
        }

        private int CrewCount
        {
            get => _crewCount;
            set
            {
                if (value > MaxCrew || value < 0)
                {
                    Debug.Log($"Error updating crew count. Tried to update to {value}");
                    throw new ArgumentOutOfRangeException(nameof(CrewCount));
                }

                _crewCount = value;
            }
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
            CrewCount++;
        }

        public void RemoveCrew()
        {
            CrewCount--;
        }

        public void ResetCrew()
        {
            _crewCount = 0;
        }
    }
}
