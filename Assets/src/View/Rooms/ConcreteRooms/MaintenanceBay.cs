using System;
using src.Controller.ActionModelManager;
using src.Model.ModelConcrete.GameActions;
using src.Model.ModelConcrete.Ships;
using src.Model.ModelFramework.ActionFramework;

namespace src.View.Rooms.ConcreteRooms
{
    public class MaintenanceBay : BaseRoom//TODO reimplament these
    {
        Guid healID = Guid.Parse("A43827BC-68B1-4779-9867-07fAC878f7CB");
        Heal heal;
        public MaintenanceBay(BaseShip ship, System.Guid teamId) 
            : base(ship, "Maintenance Bay", 0, 3, new System.Guid(), teamId)
        {
            ActionModel HealModel = ActionManager.instance.GetActionModel(healID, 0);
            heal = new Heal(HealModel, healID, ship.GetSelfId(), ship.GetTeamId());
            heal.readyAction();
        }

        public override void newTurn()
        {
            this.AddCrew();
            if (this.GetCrewCount() > 0)
            {
                heal.UseAction(heal.AvailableTargets());
                heal.AdvanceRound();
            }
            this.RemoveCrew();
        }
    }
}
