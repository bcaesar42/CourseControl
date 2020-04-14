using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using src.Model.ModelFramework.ActionFramework;
using src.View.Rooms;
using src.View.Rooms.ConcreteRooms;
using UnityEngine;

public class RoomView : MonoBehaviour
{
    List<BaseRoom> Rooms = new List<BaseRoom>(); //Are these necessary?
    List<TextMesh> Labels = new List<TextMesh>(); //Are these necessary?

    Dictionary<BaseRoom, TextMesh> RoomMap = new Dictionary<BaseRoom, TextMesh>();

    string Description { get; set; }
    string ShipModelPath { get; set; }
    string RoomModelPath { get; set; }
    int CrewCount { get; set; }
    //ActionState State;

    // Start is called before the first frame update
    void Start()
    {
        string[] prefixes = {"DroneBay", "MaintenanceBay", "MedicalBay", "NavigationRoom", "ReplicationCenter", "ResearchCenter", "ScavengeBay", "SensorRoom", "ShieldBay", "WeaponsBay"};
        TextMesh text;
        BaseRoom room;

        GameObject Player = GameObject.Find("Player");
        GameObject Room0, Room1, Room2, Room3, Room4, Room5, Room6, Room7 = null;

        try
        {
            text = GameObject.Find("Slot0CrewCount").GetComponent<TextMesh>();
            room = GameObject.Find("Slot0").AddComponent<WeaponsBay>() as WeaponsBay;
            Labels.Add(text); //Necessary?
            Rooms.Add(room); //Necessary?
            RoomMap.Add(room, text);

            GameObject objPrefab = Resources.Load("WeaponRoom") as GameObject;
            GameObject obj = Instantiate(objPrefab, transform.position, Quaternion.identity) as GameObject;
            obj.transform.Rotate(new Vector3(-90, 0, -90));
            Vector3 target = new Vector3(9.95f, -6.4f, -55.983f);
            obj.transform.position = target;

            text = GameObject.Find("Slot1CrewCount").GetComponent<TextMesh>();
            room = GameObject.Find("Slot1").AddComponent<DroneBay>() as DroneBay;
            Labels.Add(text); //Necessary?
            Rooms.Add(room); //Necessary?
            RoomMap.Add(room, text);
            target = new Vector3(7.9f, -4.35f, -48.87f);
            objPrefab = Resources.Load("DroneRoom") as GameObject;
            obj = Instantiate(objPrefab, target, Quaternion.identity);
            obj.transform.Rotate(new Vector3(0, 0, -135));

            text = GameObject.Find("Slot2CrewCount").GetComponent<TextMesh>();
            room = GameObject.Find("Slot2").AddComponent<MedicalBay>() as MedicalBay;
            Labels.Add(text); //Necessary?
            Rooms.Add(room); //Necessary?
            RoomMap.Add(room, text);

            text = GameObject.Find("Slot3CrewCount").GetComponent<TextMesh>();
            room = GameObject.Find("Slot3").AddComponent<NavigationRoom>() as NavigationRoom;
            Labels.Add(text); //Necessary?
            Rooms.Add(room); //Necessary?
            RoomMap.Add(room, text);

            text = GameObject.Find("Slot4CrewCount").GetComponent<TextMesh>();
            room = GameObject.Find("Slot4").AddComponent<ReplicationCenter>() as ReplicationCenter;
            Labels.Add(text); //Necessary?
            Rooms.Add(room); //Necessary?
            RoomMap.Add(room, text);

            text = GameObject.Find("Slot5CrewCount").GetComponent<TextMesh>();
            room = GameObject.Find("Slot5").AddComponent<ResearchCenter>() as ResearchCenter;
            Labels.Add(text); //Necessary?
            Rooms.Add(room); //Necessary?
            RoomMap.Add(room, text);

            text = GameObject.Find("Slot6CrewCount").GetComponent<TextMesh>();
            room = GameObject.Find("Slot6").AddComponent<SensorRoom>() as SensorRoom;
            Labels.Add(text); //Necessary?
            Rooms.Add(room); //Necessary?
            RoomMap.Add(room, text);

            text = GameObject.Find("Slot7CrewCount").GetComponent<TextMesh>();
            room = GameObject.Find("Slot7").AddComponent<ShieldBay>() as ShieldBay;
            Labels.Add(text); //Necessary?
            Rooms.Add(room); //Necessary?
            RoomMap.Add(room, text);
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
