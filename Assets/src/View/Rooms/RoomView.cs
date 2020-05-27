using System;
using System.Collections.Generic;
using src.Model.ModelFramework.ActionFramework;
using src.View.Rooms;
using src.View.Rooms.ConcreteRooms;
using UnityEngine;

public class RoomView : MonoBehaviour
{

    private Dictionary<BaseRoom, TextMesh> RoomMap { get; set; }
    private string Description { get; set; }
    private string ShipModelPath { get; set; }
    private string RoomModelPath { get; set; }
    private string[] selectedRooms { get; set; }
    private BaseRoom room { get; set; }
    private List<TextMesh> Labels { get; set; }
    private ActionState State { get; set; }
    private int CrewCount { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        RoomMap = new Dictionary<BaseRoom, TextMesh>();
        if (selectedRooms is null)
        {
             selectedRooms = new string[] { "WeaponsBay", "DroneBay", "MaintenanceBay", "NavigationRoom", "ResearchCenter", "ScavengeBay", "ShieldBay", "SensorRoom" };
        }
        TextMesh text = new TextMesh();
        Labels = new List<TextMesh>();

        GameObject Player = GameObject.Find("Player");

        Vector3[] Slots = { new Vector3(7.8639f, -4.3603f, -55.895f), new Vector3(6.2546f, -4.5828f, -46.731f), new Vector3(3.8639f, -6.8602f, -37.895f), new Vector3(-2.1361f, -6.8602f, -30.895f), new Vector3(-2.1361f, -4.8872f, -25.331f), new Vector3(-8.1361f, -6.8602f, -37.895f), new Vector3(-12.136f, -6.8602f, -48.895f), new Vector3(-14.2f, -6.3376f, -55.818f) };

        /*
         * Current behavior is fixed. Rooms are manually placed and oriented because they all require a specific orientation/position. Will try to make modular closer to project completion.
         * Translation can be accomplished in a two step manner after the room has been placed.
         * Will have to fix orientation in order to not rotate rooms.
         * Global variables could be cleaned up but I can't figure out how currently.
         */

        GameObject objPrefab;
        GameObject obj;

        for (int slotNumber = 0; slotNumber < Slots.Length; slotNumber++)
        {
            
            text = GameObject.Find($"Slot{slotNumber}CrewCount").GetComponent<TextMesh>();

            switch (selectedRooms[slotNumber].ToString())
            {
                case "WeaponsBay":
                    room = GameObject.Find($"Slot{slotNumber}").AddComponent<WeaponsBay>() as WeaponsBay;
                    objPrefab = Resources.Load("WeaponRoom") as GameObject;
                    obj = Instantiate(objPrefab, transform.position, Quaternion.identity) as GameObject;
                    obj.transform.Rotate(new Vector3(-90, 0, -90));
                    break;
                case "DroneBay":
                    room = GameObject.Find($"Slot{slotNumber}").AddComponent<DroneBay>() as DroneBay;
                    objPrefab = Resources.Load("DroneRoom") as GameObject;
                    obj = Instantiate(objPrefab, transform.position, Quaternion.identity) as GameObject;
                    obj.transform.Rotate(new Vector3(0, 0, -135));
                    break;
                case "MaintenanceBay":
                    room = GameObject.Find($"Slot{slotNumber}").AddComponent<MaintenanceBay>() as MaintenanceBay;
                    objPrefab = Resources.Load("MaintenanceRoom") as GameObject;
                    obj = Instantiate(objPrefab, transform.position, Quaternion.identity) as GameObject;
                    obj.transform.Rotate(new Vector3(0, 0, -90));
                    break;
                case "NavigationRoom":
                    room = GameObject.Find($"Slot{slotNumber}").AddComponent<NavigationRoom>() as NavigationRoom;
                    objPrefab = Resources.Load("NavigationRoom") as GameObject;
                    obj = Instantiate(objPrefab, transform.position, Quaternion.identity) as GameObject;
                    obj.transform.Rotate(new Vector3(-90, 0, 0));
                    break;
                case "ResearchCenter":
                    room = GameObject.Find($"Slot{slotNumber}").AddComponent<ResearchCenter>() as ResearchCenter;
                    objPrefab = Resources.Load("ResearchRoom") as GameObject;
                    obj = Instantiate(objPrefab, transform.position, Quaternion.identity) as GameObject;
                    obj.transform.Rotate(new Vector3(-90, 0, 0));
                    break;
                case "ScavengeBay":
                    room = GameObject.Find($"Slot{slotNumber}").AddComponent<ScavengeBay>() as ScavengeBay;
                    objPrefab = Resources.Load("ScavengeRoom") as GameObject;
                    obj = Instantiate(objPrefab, transform.position, Quaternion.identity) as GameObject;
                    break;
                case "ShieldBay":
                    room = GameObject.Find($"Slot{slotNumber}").AddComponent<ShieldBay>() as ShieldBay;
                    objPrefab = Resources.Load("ShieldRoom") as GameObject;
                    obj = Instantiate(objPrefab, transform.position, Quaternion.identity) as GameObject;
                    obj.transform.Rotate(new Vector3(-90, 0, 0));
                    break;
                case "SensorRoom":
                    room = GameObject.Find($"Slot{slotNumber}").AddComponent<SensorRoom>() as SensorRoom;
                    objPrefab = Resources.Load("SensorRoom") as GameObject;
                    obj = Instantiate(objPrefab, transform.position, Quaternion.identity) as GameObject;
                    obj.transform.Rotate(new Vector3(-90, 0, 0));
                    break;
                default:
                    room = GameObject.Find($"Slot{slotNumber}").AddComponent<WeaponsBay>() as WeaponsBay;
                    objPrefab = Resources.Load("WeaponRoom") as GameObject;
                    obj = Instantiate(objPrefab, transform.position, Quaternion.identity) as GameObject;
                    obj.transform.Rotate(new Vector3(-90, 0, -90));
                    break;
            
            
            }
            Labels.Add(text);
            obj.transform.position = Slots[slotNumber];
            RoomMap.Add(room, text);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Update room counts
        for (int ix = 0; ix < Labels.Count; ix++)
        {
            Labels[ix].text = $"{room.GetCrewCount()}\n{room.State}";
        }
    }

    void StateChanged(string description, string modelPath, int crewCount, ActionState state)
    {
        State = state;
        Description = description ?? throw new ArgumentNullException(nameof(description));
        RoomModelPath = modelPath ?? throw new ArgumentNullException(nameof(modelPath));
        CrewCount = crewCount; //crewCount is not used anywhere. Should we maybe remove this from StateChanged?
    }
}
