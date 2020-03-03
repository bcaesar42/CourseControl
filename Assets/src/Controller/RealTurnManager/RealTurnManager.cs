using System;
using System.Collections.Generic;

public class RealTurnManager
{
    List<Guid> playerList;
    Guid currentPlayer;
    //ActionRunner actionRunner

    public RealTurnManager()
    {
        playerList = new List<Guid>();
    }

    public void addPlayer(Guid id /*ActionRunner actionRunner*/)
    {
        playerList.Add(id);
        //this.actionRunner = actionRunner
    }

    public void removePlayer(Guid id)
    {
        playerList.Remove(id);
    }

    public void start()
    {
        currentPlayer = playerList[0];
    }

    public void newTurn()
    {
        int ix = playerList.IndexOf(currentPlayer);

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
