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

    Dictionary<BaseRoom, TextMesh> RoomMap { get; set; }
    string Description { get; set; }
    string ShipModelPath { get; set; }
    string RoomModelPath { get; set; }
    int CrewCount { get; set; }
    string[] selectedRooms { get; set; }
    //ActionState State;

    // Start is called before the first frame update
    void Start()
    {
        RoomMap = new Dictionary<BaseRoom, TextMesh>();
        if (selectedRooms is null)
        {
             selectedRooms = new string[] { "WeaponsBay", "DroneBay", "MaintenanceBay", "NavigationRoom", "ResearchCenter", "ScavengeBay", "ShieldBay", "SensorRoom" };
        }
        TextMesh text;
        BaseRoom room;

        GameObject Player = GameObject.Find("Player");
        GameObject Room0, Room1, Room2, Room3, Room4, Room5, Room6, Room7;

        Vector3[] Slots = { new Vector3(7.8639f, -4.3603f, -55.895f), new Vector3(6.2546f, -4.5828f, -46.731f), new Vector3(3.8639f, -6.8602f, -37.895f), new Vector3(-2.1361f, -6.8602f, -30.895f), new Vector3(-2.1361f, -4.8872f, -25.331f), new Vector3(-8.1361f, -6.8602f, -37.895f), new Vector3(-12.136f, -6.8602f, -48.895f), new Vector3(-14.2f, -6.3376f, -55.818f) };

        /*
         * Current behavior is fixed. Rooms are manually placed and oriented because they all require a specific orientation/position. Will try to make modular closer to project completion.
         * Translation can be accomplished in a two step manner after all rooms have been placed.
         * Will have to fix orientation in order to not rotate rooms.
         */

        try
        {
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
                        break;
                    case "DroneBay":
                        room = GameObject.Find($"Slot{slotNumber}").AddComponent<DroneBay>() as DroneBay;
                        objPrefab = Resources.Load("DroneRoom") as GameObject;
                        break;
                    case "MaintenanceBay":
                        room = GameObject.Find($"Slot{slotNumber}").AddComponent<MaintenanceBay>() as MaintenanceBay;
                        objPrefab = Resources.Load("MaintenanceRoom") as GameObject;
                        break;
                    case "NavigationRoom":
                        room = GameObject.Find($"Slot{slotNumber}").AddComponent<DroneBay>() as DroneBay;
                        objPrefab = Resources.Load("DroneRoom") as GameObject;
                        break;
                    case "ResearchCenter":
                        room = GameObject.Find($"Slot{slotNumber}").AddComponent<DroneBay>() as DroneBay;
                        objPrefab = Resources.Load("DroneRoom") as GameObject;
                        break;
                    case "ScavengeBay":
                        room = GameObject.Find($"Slot{slotNumber}").AddComponent<DroneBay>() as DroneBay;
                        objPrefab = Resources.Load("DroneRoom") as GameObject;
                        break;
                    case "ShieldBay":
                        room = GameObject.Find($"Slot{slotNumber}").AddComponent<DroneBay>() as DroneBay;
                        objPrefab = Resources.Load("DroneRoom") as GameObject;
                        break;
                    case "SensorRoom":
                        room = GameObject.Find($"Slot{slotNumber}").AddComponent<DroneBay>() as DroneBay;
                        objPrefab = Resources.Load("DroneRoom") as GameObject;
                        break;
                    default:
                        room = GameObject.Find($"Slot{slotNumber}").AddComponent<WeaponsBay>() as WeaponsBay;
                        objPrefab = Resources.Load("WeaponRoom") as GameObject;
                        break;
                }
                obj = Instantiate(objPrefab, transform.position, Quaternion.identity) as GameObject;
                //obj.transform.Rotate(new Vector3(-90, 0, -90));
                obj.transform.position = Slots[slotNumber];
                RoomMap.Add(room, text);
            }
        }
        catch (NullReferenceException e)
        {
            print(e.Message);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Will fix soon
        //Update room counts
        //int ix = 0;
        //foreach (BaseRoom room in Rooms)
        //{
        //    Labels[ix].text = "" + room.GetCrewCount();
        //    ix++;
        //}
    }

    void StateChanged(string description, string modelPath, int crewCount, ActionState state)
    {

    }
}
