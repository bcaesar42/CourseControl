﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using src.Model.ModelFramework.ActionFramework;
using src.View.Rooms;
using UnityEngine;

public class RoomView : MonoBehaviour
{
    List<BaseRoom> Rooms = new List<BaseRoom>();
    List<TextMesh> Labels = new List<TextMesh>();

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


        //Worked when rooms were predefined per ship.
        //foreach (string prefix in prefixes)
        //{
        //    string fullRoom = prefix + "CrewCount";
        //    try {
        //        text = GameObject.Find(fullRoom).GetComponent<TextMesh>();
        //        room = GameObject.Find(prefix).GetComponent<BaseRoom>();
        //        print("Successfully created a " + fullRoom);
        //        Labels.Add(text);
        //        Rooms.Add(room);
        //        RoomMap.Add(room, text);
        //    } catch (NullReferenceException e)
        //    {
        //        //print(e.Message);
        //    }
        //}

        GameObject Player = GameObject.Find("Player");
        for (int ix = 0; ix < 8; ix++)
        {
            try
            {
                text = GameObject.Find($"Slot{ix}CrewCount").GetComponent<TextMesh>();
                room = GameObject.Find($"Slot{ix}").GetComponent<BaseRoom>();
                print("Successfully created a " + prefixes[ix]);
                Labels.Add(text);
                Rooms.Add(room);
                RoomMap.Add(room, text);
            }
            catch (NullReferenceException e)
            {
                //print(e.Message);
            }
        }


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
