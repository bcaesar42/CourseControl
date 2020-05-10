using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using src.Model.ModelFramework.ActionFramework;
using src.View.Rooms;
using src.View.Rooms.ConcreteRooms;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class RoomView : MonoBehaviour
{
    List<BaseRoom> Rooms = new List<BaseRoom>(); //Are these necessary?
    List<TextMesh> Labels = new List<TextMesh>(); //Are these necessary?

    Dictionary<BaseRoom, TextMesh> RoomMap = new Dictionary<BaseRoom, TextMesh>();

    string Description { get; set; }
    string ShipModelPath { get; set; }
    string RoomModelPath { get; set; }
    int CrewCount { get; set; }
    string[] selectedRooms { get; set; }
    //ActionState State;

    // Start is called before the first frame update
    void Start()
    {
        if (selectedRooms is null)
        {
             selectedRooms = new string[] { "WeaponsBay", "DroneBay", "MaintenanceBay", "NavigationRoom", "ResearchCenter", "ScavengeBay", "ShieldBay", "SensorRoom" };
        }
        TextMesh text;
        BaseRoom room;

        GameObject Player = GameObject.Find("Player");
        GameObject Room0, Room1, Room2, Room3, Room4, Room5, Room6, Room7 = null;

        Vector3[] Slots = { new Vector3(7.8639f, -4.3603f, -55.895f), new Vector3(6.2546f, -4.5828f, -46.731f), new Vector3(3.8639f, -6.8602f, -37.895f), new Vector3(-2.1361f, -6.8602f, -30.895f), new Vector3(-2.1361f, -4.8872f, -25.331f), new Vector3(-8.1361f, -6.8602f, -37.895f), new Vector3(-12.136f, -6.8602f, -48.895f), new Vector3(-14.2f, -6.3376f, -55.818f) };

        /*
         * Current behavior is fixed. Rooms are manually placed and oriented because they all require a specific orientation/position. Will try to make modular closer to project completion.
         * Translation can be accomplished in a two step manner after all rooms have been placed.
         */

        try
        {
            int slotNumber = 0;
            GameObject objPrefab;
            GameObject obj;

            while (slotNumber < Slots.Length)
            {
                Debug.Log(selectedRooms[slotNumber]);
                switch (selectedRooms[slotNumber].ToString())
                {
                    case "WeaponsBay":
                        text = GameObject.Find($"Slot{slotNumber}CrewCount").GetComponent<TextMesh>();
                        room = GameObject.Find($"Slot{slotNumber}").AddComponent<WeaponsBay>() as WeaponsBay;
                        objPrefab = Resources.Load("WeaponRoom") as GameObject;
                        obj = Instantiate(objPrefab, transform.position, Quaternion.identity) as GameObject;
                        obj.transform.Rotate(new Vector3(-90, 0, -90));
                        obj.transform.position = Slots[slotNumber];
                        break;
                    case "DroneBay":
                        text = GameObject.Find($"Slot{slotNumber}CrewCount").GetComponent<TextMesh>();
                        room = GameObject.Find($"Slot{slotNumber}").AddComponent<DroneBay>() as DroneBay;
                        objPrefab = Resources.Load("DroneRoom") as GameObject;
                        obj = Instantiate(objPrefab, transform.position, Quaternion.identity) as GameObject;
                        obj.transform.Rotate(new Vector3(0, 0, -135));
                        obj.transform.position = Slots[slotNumber];
                        break;
                    case "MaintenanceBay":
                        text = GameObject.Find($"Slot{slotNumber}CrewCount").GetComponent<TextMesh>();
                        room = GameObject.Find($"Slot{slotNumber}").AddComponent<MaintenanceBay>() as MaintenanceBay;
                        objPrefab = Resources.Load("MaintenanceRoom") as GameObject;
                        obj = Instantiate(objPrefab, transform.position, Quaternion.identity) as GameObject;
                        obj.transform.Rotate(new Vector3(0, 0, -90));
                        obj.transform.position = Slots[slotNumber];
                        break;
                    case "NavigationRoom":
                        text = GameObject.Find($"Slot{slotNumber}CrewCount").GetComponent<TextMesh>();
                        room = GameObject.Find($"Slot{slotNumber}").AddComponent<DroneBay>() as DroneBay;
                        objPrefab = Resources.Load("DroneRoom") as GameObject;
                        obj = Instantiate(objPrefab, transform.position, Quaternion.identity) as GameObject;
                        obj.transform.Rotate(new Vector3(-90, 0, 0));
                        obj.transform.position = Slots[slotNumber];
                        break;
                    case "ResearchCenter":
                        text = GameObject.Find($"Slot{slotNumber}CrewCount").GetComponent<TextMesh>();
                        room = GameObject.Find($"Slot{slotNumber}").AddComponent<DroneBay>() as DroneBay;
                        objPrefab = Resources.Load("DroneRoom") as GameObject;
                        obj = Instantiate(objPrefab, transform.position, Quaternion.identity) as GameObject;
                        obj.transform.Rotate(new Vector3(-90, 0, 0));
                        obj.transform.position = Slots[slotNumber];
                        break;
                    case "ScavengeBay":
                        text = GameObject.Find($"Slot{slotNumber}CrewCount").GetComponent<TextMesh>();
                        room = GameObject.Find($"Slot{slotNumber}").AddComponent<DroneBay>() as DroneBay;
                        objPrefab = Resources.Load("DroneRoom") as GameObject;
                        obj = Instantiate(objPrefab, transform.position, Quaternion.identity) as GameObject;
                        obj.transform.position = Slots[slotNumber];
                        break;
                    case "ShieldBay":
                        text = GameObject.Find($"Slot{slotNumber}CrewCount").GetComponent<TextMesh>();
                        room = GameObject.Find($"Slot{slotNumber}").AddComponent<DroneBay>() as DroneBay;
                        objPrefab = Resources.Load("DroneRoom") as GameObject;
                        obj = Instantiate(objPrefab, transform.position, Quaternion.identity) as GameObject;
                        obj.transform.Rotate(new Vector3(-90, 0, 0));
                        obj.transform.position = Slots[slotNumber];
                        break;
                    case "SensorRoom":
                        text = GameObject.Find($"Slot{slotNumber}CrewCount").GetComponent<TextMesh>();
                        room = GameObject.Find($"Slot{slotNumber}").AddComponent<DroneBay>() as DroneBay;
                        objPrefab = Resources.Load("DroneRoom") as GameObject;
                        obj = Instantiate(objPrefab, transform.position, Quaternion.identity) as GameObject;
                        obj.transform.Rotate(new Vector3(-90, 0, 0));
                        obj.transform.position = Slots[slotNumber];
                        break;
                }
                slotNumber++;
            }
        }
        catch (NullReferenceException e)
        {
            print(e.Message);
        }

        //WeaponsBay weaponsBay = RoomMap.ContainsKey
    }

    // Update is called once per frame
    void Update()
    {
        //Worked when rooms were predefined per ship.
        //Update room counts
        int ix = 0;
        foreach (BaseRoom room in Rooms)
        {
            Labels[ix].text = "" + room.GetCrewCount();
            ix++;
        }
    }

    void StateChanged(string description, string modelPath, int crewCount, ActionState state)
    {

    }
}
