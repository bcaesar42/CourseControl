using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class RoomView : MonoBehaviour
{
    List<BaseRoom> Rooms = new List<BaseRoom>();
    List<TextMesh> Labels = new List<TextMesh>();

    Dictionary<BaseRoom, TextMesh> RoomMap = new Dictionary<BaseRoom, TextMesh>();

    // Start is called before the first frame update
    void Start()
    {
        string[] prefixes = {"DroneBay", "MaintenanceBay", "MedicalBay", "NavigationRoom", "ReplicationCenter", "ResearchCenter", "ScavengeBay", "SensorRoom", "ShieldBay", "WeaponsBay"};
        TextMesh text;
        BaseRoom room;

        foreach (string prefix in prefixes)
        {
            string fullRoom = prefix + "CrewCount";
            try {
                text = GameObject.Find(fullRoom).GetComponent<TextMesh>();
                room = GameObject.Find(prefix).GetComponent<BaseRoom>();
                print("Successfully created a " + fullRoom);
                Labels.Add(text);
                Rooms.Add(room);
                RoomMap.Add(room, text);
            } catch (NullReferenceException e)
            {
                //print(e.Message);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        //Update room counts
        int ix = 0;
        foreach (BaseRoom room in Rooms)
        {
            Labels[ix].text = "" + room.GetCrewCount();
            ix++;
        }
    }
}
