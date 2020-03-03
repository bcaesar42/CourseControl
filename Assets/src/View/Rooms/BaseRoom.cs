using System;
using UnityEngine;
using UnityEngine.UI;

namespace src.View.Rooms
{
    public abstract class BaseRoom : MonoBehaviour
    {
        Text CrewCountText;
        String RoomName;

        public BaseRoom(String roomName, int currentCrewCount, int maxCrewCount)
        {
            RoomName = roomName;
            MaxCrew = maxCrewCount;
            CrewCount = currentCrewCount;
        }

        private int _maxCrew;
        private int MaxCrew
        {
            get { return _maxCrew; }
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

        private int _crewCount;
        private int CrewCount
        {
            get { return _crewCount; }
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

        void Start()
        {
            Debug.Log($"Created {RoomName}.");

            CrewCountText = GameObject.Find($"{RoomName.Replace(" ","")}CrewCount").GetComponent<Text>();
            CrewCountText.text = $"{CrewCount}";
        }

        // Update is called once per frame
        void Update()
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