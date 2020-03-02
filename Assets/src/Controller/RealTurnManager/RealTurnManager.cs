using System;

public class RealTurnManager
{
    List<Guid> playerList;
    Guid currentPlayer;
    //ActionRunner actionRunner

    public RealTurnManager()
    {
        playerList = new List<Guid>();
    }

    public addPlayer(Guid id /*ActionRunner actionRunner*/)
    {
        playerList.Add(id);
        //this.actionRunner = actionRunner
    }

    public removePlayer(Guid id)
    {
        playerList.Remove(id);
    }

    public void start()
    {
        currentPlayer = playerList.IndexOf(0);
    }

    public void newTurn()
    {
        int ix = playerList.FindIndex(currentPlayer);

        if (ix < playerList.Count - 1)
        {
            currentPlayer = playerList.FindIndex(ix + 1);
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
        currentPlayer = playerList.IndexOf(0);
        //Do whatever we will do to update and reset thing when we beging a new round.
        //Do whatever we will do to update view to current player
    }
}
