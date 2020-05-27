﻿using System;
using System.Collections;
using System.Collections.Generic;
using src.Controller.TargetManager;
using src.Model.ModelFramework.ShipFramework;
using src.Turn;
using UnityEngine;


/* 
 * SceneManager is intended to be the overall manager sitting at the top of 
 * the hierachy for CC. It's role is to set up the game space and direct
 * queries asking to get a manager.
 */


public class SceneManager : MonoBehaviour
{
    List<BaseShip> shipList;
    TurnManager turnManager;
    TargetManager targetManager;
    ActionRunner actionRunner;

    //ActionManager actionManager; TODO: figure out how to get actionManager active

    //Assuming that we construct ships elsewhere (on another scene) and pass them in when the game scene is started

    void Start()
    {
        //this.shipList = shipList;
        actionRunner = new ActionRunner();

        turnManager = new TurnManager(actionRunner);
        test();
    }

    public void test()
    {
        ShipModel sm = new ShipModel();
        sm.Name = "TestShip";
        sm.ShipId = new Guid();
        sm.Description = "THIS IS A TEST SHIP";
        sm.InitialCrewCount = 5;
        sm.InitialMaxHealth = 30;

        BaseShip tShip1 = new BaseShip(sm);
        BaseShip tShip2 = new BaseShip(sm);
    }

    public void newTurn()
    {
        turnManager.newTurn();
    }

}
