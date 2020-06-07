using System;
using System.Collections.Generic;
using src.Turn;
using UnityEngine;

public class TurnManager
{
    List<Guid> playerList { get; set; }
    public Guid currentPlayer { get; set; }

    public TurnManager()
    {
        playerList = new List<Guid>();
    }

    public void addPlayer(Guid id)
    {
        //Debug.Log("Added Player: " + id);
        playerList.Add(id);
        
    }

    public void removePlayer(Guid id)
    {
        playerList.Remove(id);
    }

    public BaseShip CurrentShip()
    {
        foreach (BaseShip ship in SceneManager.instance.shipList)
        {
            if (currentPlayer == ship.GetSelfId())
            {
                return ship;
            }
        }
        Debug.Log("No ship can be found matching the current player's GUID");
        return null;
    }

    public void start()
    {
        currentPlayer = playerList[0];
    }

    public void newTurn()
    {
        int ix = playerList.IndexOf(currentPlayer);

        //Debug.Log("currentPlayer: " + currentPlayer + " Index: " + ix);

        if (ix < playerList.Count - 1)
        {
            currentPlayer = playerList[ix + 1];
            //Do whatever we will do to update view and whatnot at this stage.
        }
        else
        {
            this.newRound();
        }
    }

    public void newRound()
    {
        //actionRunner.runActions();
        currentPlayer = playerList[0];
        //Do whatever we will do to update and reset thing when we beging a new round.
        //Do whatever we will do to update view to current player
    }
}
