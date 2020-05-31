using System;
using System.Collections;
using System.Collections.Generic;
using src.Controller.ActionModelManager;
using src.Controller.TargetManager;
using src.Model.ModelFramework.ShipFramework;
using src.Model.ModelFramework.TargetableFramework;
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

    ActionManager actionManager;

    //Assuming that we construct ships elsewhere (on another scene) and pass them in when the game scene is started

    void Start()
    {
        actionManager = new ActionManager();
        targetManager = new TargetManager();

        turnManager = new TurnManager();
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

        Debug.Log("Ship Model ID: " + sm.ShipId);

        BaseShip tShip1 = new BaseShip(sm);
        BaseShip tShip2 = new BaseShip(sm);

        Debug.Log("tShip1 ID: " + tShip1.GetSelfId());
        Debug.Log("tShip2 ID: " + tShip2.GetSelfId());


        targetManager.AddTarget(tShip1);
        targetManager.AddTarget(tShip2);

        List<ITargetable> targets = targetManager.getEnemies(tShip1.GetSelfId());
        
        foreach(ITargetable t in targets)
        {
            Debug.Log(t.GetSelfId());
        }

    }

    public void newTurn()
    {
        turnManager.newTurn();
    }

}
