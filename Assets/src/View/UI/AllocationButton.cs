using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using src.Controller.TargetManager;
using src.View.Rooms;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.src.View.UI
{
    public class AllocationButton : MonoBehaviour, IPointerClickHandler
    {
        SceneManager sceneManager;
        int roomIndex;

        /*
         * Constructor is passed in slot number and reference to room
         * Find slot object and put in order
         * Add listener
         */

        void Start()
        {
            sceneManager = GameObject.Find("SceneManager").transform.GetComponent<SceneManager>();
            
            //Guid currentPlayer = sceneManager.turnManager.currentPlayer;

            switch (name)
            {
                case "Slot0Button":
                    roomIndex = 0;

                    break;

                case "Slot1Button":
                    roomIndex = 1;
                    break;

                case "Slot2Button":
                    roomIndex = 2;
                    break;

                case "Slot3Button":
                    roomIndex = 3;
                    break;

                case "Slot4Button":
                    roomIndex = 4;
                    break;

                case "Slot5Button":
                    roomIndex = 5;
                    break;

                case "Slot6Button":
                    roomIndex = 6;
                    break;

                case "Slot7Button":
                    roomIndex = 8;
                    break;
            }

        }

        void Update()
        {
            //this.enabled = false;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Guid playerGUID = sceneManager.turnManager.currentPlayer;

            if (eventData.button == PointerEventData.InputButton.Left)
            {
                foreach (BaseShip ship in sceneManager.shipList)
                {
                    if (playerGUID == ship.GetSelfId())
                    {
                        BaseShip playerShip = ship;
                        ship.AllocateCrew(1, roomIndex);
                        Debug.Log("CrewCount for room: " + ship.roomList[roomIndex].GetCrewCount());
                        Debug.Log("CrewCount for ship: " + ship.CurrentCrewCount());
                    }
                }
            }
            else if (eventData.button == PointerEventData.InputButton.Middle)
            {
                Debug.Log("Middle click");
            }
                
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                foreach (BaseShip ship in sceneManager.shipList)
                {
                    if (playerGUID == ship.GetSelfId())
                    {
                        BaseShip playerShip = ship;
                        ship.FreeCrew(1, roomIndex);
                        Debug.Log("CrewCount for room: " + ship.roomList[roomIndex].GetCrewCount());
                        Debug.Log("CrewCount for ship: " + ship.CurrentCrewCount());
                    }
                }
            }
        }
    }
}
