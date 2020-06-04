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
        List<GameObject> slots;
        SceneManager sceneManager;
        List<Button> buttons;
        TargetManager targetManager;

        int roomIndex;
        Guid playerGUID;

        /*
         * Constructor is passed in slot number and reference to room
         * Find slot object and put in order
         * Add listener
         */

        public AllocationButton(int slotNumber, BaseRoom room)
        {
            
        }
        void Start()
        {
            sceneManager = GameObject.Find("SceneManager").transform.GetComponent<SceneManager>();
            targetManager = sceneManager.targetManager;
            Button button = GameObject.Find("Slot0").GetComponentInChildren<Button>();
            playerGUID = sceneManager.turnManager.currentPlayer;

            switch (this.name)
            {
                case "slot0Button":
                    roomIndex = 0;
                    break;

                case "slot1Button":
                    roomIndex = 1;
                    break;

                case "slot2Button":
                    roomIndex = 2;
                    break;

                case "slot3Button":
                    roomIndex = 3;
                    break;

                case "slot4Button":
                    roomIndex = 4;
                    break;

                case "slot5Button":
                    roomIndex = 5;
                    break;

                case "slot6Button":
                    roomIndex = 6;
                    break;

                case "slot7Button":
                    roomIndex = 8;
                    break;
            }

        }

        void Update()
        {
            
        }

        void TaskOnClick()
        {

        }

        public void OnPointerClick(PointerEventData eventData)
        {

            Debug.Log(this.name);

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
                        Debug.Log(ship.roomList[roomIndex].GetCrewCount());
                    }
                }
            }
        }
    }
}
