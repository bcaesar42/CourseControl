using System;
using System.Collections;
using System.Collections.Generic;
using Assets.src.Model.ModelConcrete.Ships;
using src.Controller.ActionModelManager;
using src.Controller.TargetManager;
using Assets.src.Model.ModelFramework.ShipFramework;
using UnityEngine;
using UnityEngine.EventSystems;
using src.Model.ModelFramework.ActionFramework;


/* 
 * SceneManager is intended to be the overall manager sitting at the top of 
 * the hierachy for CC. It's role is to set up the game space and direct
 * queries asking to get a manager.
 */


public class SceneManager : MonoBehaviour
{
    public List<BaseShip> shipList;
    public TurnManager turnManager;
    public TargetManager targetManager { get; set; }
    public ActionManager actionManager { get; set; }
    public static readonly SceneManager instance = new SceneManager();

    //Assuming that we construct ships elsewhere (on another scene) and pass them in when the game scene is started

    private void Awake()
    {
        shipList = new List<BaseShip>();
        turnManager = new TurnManager();
        targetManager = new TargetManager();
        actionManager = ActionManager.instance;

        targetShip tShip = new targetShip();
        Wishbone wishbone = new Wishbone(new WishboneModel());

        shipList.Add(wishbone);
        targetManager.AddTarget(tShip);


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
        shipList[0].Damage(5);
        shipList[0].newTurn();
    }

}
