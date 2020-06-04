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
        }

        void Update()
        {
            
        }

        void TaskOnClick()
        {

        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                Guid playerGUID = sceneManager.turnManager.currentPlayer;
                foreach (BaseShip ship in sceneManager.shipList)
                {
                    if (playerGUID == ship.GetSelfId())
                    {
                        BaseShip playerShip = ship;
                        Debug.Log("Found the ship");
                    }
                }
            }
            else if (eventData.button == PointerEventData.InputButton.Middle)
                Debug.Log("Middle click");
            else if (eventData.button == PointerEventData.InputButton.Right)
                Debug.Log("Right click");
        }
    }
}
