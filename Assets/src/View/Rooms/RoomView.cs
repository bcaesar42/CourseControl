﻿using System;
using System.Collections.Generic;
using System.Linq;
using Assets.src.View.Rooms;
using Assets.src.View.Ship;
using src.Controller;
using src.Model.ModelConcrete.Ships;
using src.Model.ModelFramework.ActionFramework;
using src.View.Rooms;
using src.View.Rooms.ConcreteRooms;
using UnityEngine;
using UnityEngine.UI;

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
    private List<BaseShip> shipList { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        RoomMap = new Dictionary<BaseRoom, TextMesh>();
        if (selectedRooms is null)
        {
             selectedRooms = new string[] { "WeaponsBay", "DroneBay", "MaintenanceBay", "NavigationRoom", "ResearchCenter", "ScavengeBay", "ShieldBay", "SensorRoom" };
        }
        TextMesh text = new TextMesh();
        Labels = GameObject.Find("Player").GetComponentsInChildren<TextMesh>().ToList<TextMesh>();

        GameObject Player = GameObject.Find("Player");
        SceneManager sceneManager = GameObject.Find("SceneManager").transform.GetComponent<SceneManager>();
        shipList = sceneManager.shipList;

        Vector3[] Slots = {
            new Vector3(7.780874f, -2.5905f, -53.41037f),
            new Vector3(7.7205f, -3.1131f, -48.609f),
            new Vector3(5.9608f, -0.83571f, -36.209f),
            new Vector3(-2.0886f, -0.61312f, -30.952f),
            new Vector3(-2.0887f, -3.1131f, -23.105f),
            new Vector3(-10.40568f, -1.1401f, -37.74602f),
            new Vector3(-11.898f, -3.1131f, -48.609f),
            new Vector3(-11.898f, -3.1131f, -55.475f)
        };

        /*
         * Weapon
         * Navigation
         * Drone
         * Maintenance
         * Shield
         * Research
         * Sensor
         * Scavenge
         * 
         * Medical missing
         * Replication missing
         */
        GameObject objPrefab;
        GameObject obj;
        //Creating RoomMaterialUitls object, team colors are specified in constuctor here
        RoomMaterialUtils roomMaterialUtils = new RoomMaterialUtils(MaterialNames.TeamGreenLight, MaterialNames.TeamGreenDark);

        BaseShip ship = sceneManager.shipList.First();
        //Creating ShipMaterialutils object, specify team colors for ship in constructor
        ShipMaterialUtils shipMaterialUtils = new ShipMaterialUtils(MaterialNames.TeamGreenLight);
        shipMaterialUtils.ApplyShipMaterials("Player");

        foreach (BaseRoom room in ship.roomList)
        {
            Debug.Log(room.RoomName);
            switch (room.RoomName)
            {
                case "Weapons Bay":
                    objPrefab = Resources.Load("WeaponRoom") as GameObject;
                    obj = Instantiate(objPrefab, Slots[0], Quaternion.identity) as GameObject;
                    obj.transform.Rotate(new Vector3(-90, 0, 180));
                    roomMaterialUtils.ApplyWeaponRoomMaterials(obj);
                    break;
                case "Drone Bay":
                    objPrefab = Resources.Load("DroneRoom") as GameObject;
                    obj = Instantiate(objPrefab, Slots[3], Quaternion.identity) as GameObject;
                    obj.transform.Rotate(new Vector3(0, 0, -135));
                    roomMaterialUtils.ApplyDroneRoomMaterials(obj);
                    break;
                case "Maintenance Bay":
                    objPrefab = Resources.Load("MaintenanceRoom") as GameObject;
                    obj = Instantiate(objPrefab, Slots[2], Quaternion.identity) as GameObject;
                    obj.transform.Rotate(new Vector3(0, 90, -90));
                    roomMaterialUtils.ApplyMaintenanceRoomMaterials(obj);
                    break;
                case "Navigation Room":
                    objPrefab = Resources.Load("NavigationRoom") as GameObject;
                    obj = Instantiate(objPrefab, Slots[1], Quaternion.identity) as GameObject;
                    obj.transform.Rotate(new Vector3(-90, 90, 0));
                    roomMaterialUtils.ApplyNavigationRoomMaterials(obj);
                    break;
                case "Research Center":
                    objPrefab = Resources.Load("ResearchRoom") as GameObject;
                    obj = Instantiate(objPrefab, Slots[4], Quaternion.identity) as GameObject;
                    obj.transform.Rotate(new Vector3(-90, 90, 0));
                    roomMaterialUtils.ApplyResearchRoomMaterials(obj);
                    break;
                case "Scavenge Bay":
                    objPrefab = Resources.Load("ScavengeRoom") as GameObject;
                    obj = Instantiate(objPrefab, Slots[5], Quaternion.identity) as GameObject;
                    obj.transform.Rotate(new Vector3(0, 90, 0));
                    roomMaterialUtils.ApplyScavengeRoomMaterials(obj);
                    break;
                case "Shield Bay":
                    objPrefab = Resources.Load("ShieldRoom") as GameObject;
                    obj = Instantiate(objPrefab, Slots[6], Quaternion.identity) as GameObject;
                    obj.transform.Rotate(new Vector3(-90, 0, 0));
                    roomMaterialUtils.ApplyShieldRoomMaterials(obj);
                    break;
                case "Sensor Room":
                    objPrefab = Resources.Load("SensorRoom") as GameObject;
                    obj = Instantiate(objPrefab, Slots[7], Quaternion.identity) as GameObject;
                    obj.transform.Rotate(new Vector3(-90, 0, 0));
                    roomMaterialUtils.ApplySensorRoomMaterials(obj);
                    break;
                default:
                    objPrefab = Resources.Load("WeaponRoom") as GameObject;
                    obj = Instantiate(objPrefab, Slots[0], Quaternion.identity) as GameObject;
                    obj.transform.Rotate(new Vector3(-90, 0, -90));
                    roomMaterialUtils.ApplyWeaponRoomMaterials(obj);
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Update room counts

        BaseShip playerShip = shipList.First();
        for (int ix = 0; ix < playerShip.roomList.Count; ix++)
        {
            Labels[ix].text = $"{playerShip.roomList[ix].GetCrewCount()}";
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
