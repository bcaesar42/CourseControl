﻿using System.Collections.Generic;
using Assets.src.Model.ModelFramework.ShipFramework;
using src.Controller.ActionModelManager;
using src.Model.ModelConcrete.Ships;
using UnityEngine;


/* 
 * SceneManager is intended to be the overall manager sitting at the top of 
 * the hierachy for CC. It's role is to set up the game space and direct
 * queries asking to get a manager.
 */


namespace src.Controller
{
    public class SceneManager : MonoBehaviour
    {
        public List<BaseShip> shipList { get; private set; }
        public TurnManager turnManager { get; private set; }
        public TargetManager.TargetManager targetManager { get; private set; }
        public ActionManager actionManager { get; private set; }
        public static readonly SceneManager instance = new SceneManager();
        PlayerLog eventLog;
        targetShip tShip;
        //Assuming that we construct ships elsewhere (on another scene) and pass them in when the game scene is started

        private void Awake()
        {
            shipList = new List<BaseShip>();
            turnManager = new TurnManager();
            targetManager = new TargetManager.TargetManager();
            actionManager = ActionManager.instance;

            tShip = new targetShip();
            Wishbone wishbone = new Wishbone(new WishboneModel());

            shipList.Add(wishbone);
            targetManager.AddTarget(tShip);

            eventLog = GameObject.Find("EventLog").GetComponent<PlayerLog>();

        }
        void Start()
        {
            Demo();

        }

        public void Demo()
        {
            //ShipModel sm = new ShipModel();
            //sm.Name = "TestShip";
            //sm.ShipId = new Guid();
            //sm.Description = "THIS IS A TEST SHIP";
            //sm.InitialCrewCount = 5;
            //sm.InitialMaxHealth = 30;

            //BaseShip tShip1 = new BaseShip(sm);
            //BaseShip tShip2 = new BaseShip(sm);

            turnManager.addPlayer(shipList[0].GetSelfId());
            turnManager.start();

            targetManager.AddTarget(shipList[0]);
        
        }

        public void newTurn()
        {
            shipList[0].newTurn();
            tShip.newRound(shipList[0]);
        }

    }
}
