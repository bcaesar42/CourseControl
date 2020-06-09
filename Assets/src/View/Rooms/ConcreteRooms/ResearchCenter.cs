using System;
using src.Controller.ActionModelManager;
using src.Model.ModelConcrete.GameActions;
using src.Model.ModelFramework.ActionFramework;

namespace src.View.Rooms.ConcreteRooms
{
    public class ResearchCenter : BaseRoom
    {
        Guid g = Guid.Parse("41E9A99D-A083-4C99-A322-048AB604202A");
        Replication  rep;
        public ResearchCenter(BaseShip ship, System.Guid teamId) 
            : base(ship, "Research Center", 0, 3, new System.Guid(), teamId)
        {
            ActionModel repModel = ActionManager.instance.GetActionModel(g, 0);
            rep = new Replication(repModel, g, ship.GetSelfId(), ship.GetTeamId());
            rep.readyAction();
        }

        public override void newTurn()
        {
            this.AddCrew();
            this.AddCrew();
            this.AddCrew();
            if (this.GetCrewCount() > 0)
            {
                rep.UseAction(rep.AvailableTargets());
                rep.AdvanceRound();
            }
            this.RemoveCrew();
            this.RemoveCrew();
            this.RemoveCrew();
        }
    }
}
