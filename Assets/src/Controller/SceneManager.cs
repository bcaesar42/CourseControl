using System;
using System.Collections;
using System.Collections.Generic;
using Assets.src.Model.ModelConcrete.Ships;
using src.Controller.ActionModelManager;
using src.Controller.TargetManager;
using Assets.src.Model.ModelFramework.ShipFramework;
using UnityEngine;
using UnityEngine.EventSystems;


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

    //Assuming that we construct ships elsewhere (on another scene) and pass them in when the game scene is started

    void Start()
    {
        shipList =  new List<BaseShip>();

        turnManager = new TurnManager();
        targetManager = new TargetManager();
        actionManager = ActionManager.instance;
        test();
    }

    public void test()
    {
        //ShipModel sm = new ShipModel();
        //sm.Name = "TestShip";
        //sm.ShipId = new Guid();
        //sm.Description = "THIS IS A TEST SHIP";
        //sm.InitialCrewCount = 5;
        //sm.InitialMaxHealth = 30;

        //BaseShip tShip1 = new BaseShip(sm);
        //BaseShip tShip2 = new BaseShip(sm);

        Guid Player1 = Guid.NewGuid();
        turnManager.addPlayer(Player1);
        Wishbone wishbone = new Wishbone(new WishboneModel());
        shipList.Add(wishbone);

    }

    public void roomClickEvent(int room, PointerEventData pointer)
    {
        Guid curPlayer = turnManager.currentPlayer;

        foreach(BaseShip ship in shipList)
        {
            if(ship.GetSelfId().Equals(curPlayer))
            {
                if(pointer.button == PointerEventData.InputButton.Left)
                    ship.AllocateCrew(1, room);
                if (pointer.button == PointerEventData.InputButton.Right)
                    ship.FreeCrew(1, room);
            }

        }
            
    }

    public void newTurn()
    {
        turnManager.newTurn();
    }

}
