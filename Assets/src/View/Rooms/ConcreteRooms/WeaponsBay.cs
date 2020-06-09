using System;
using src.Controller;
using src.Controller.ActionModelManager;
using src.Model.ModelConcrete.GameActions;
using src.Model.ModelConcrete.Ships;
using src.Model.ModelFramework.ActionFramework;

namespace src.View.Rooms.ConcreteRooms
{
    public class WeaponsBay : BaseRoom
    {
        Guid lasCannonID = Guid.Parse("49b68f9f-45b7-4444-993d-0441b8cb14d9");
        LasCannon lasCannon;
        public static readonly SceneManager instance = new SceneManager();

        public WeaponsBay(BaseShip ship, Guid teamId)
            : base(ship, "Weapons Bay", 0, 3, new System.Guid(), teamId)
        {

            ActionModel lasCanModel = ActionManager.instance.GetActionModel(lasCannonID, 0);
            lasCannon = new LasCannon(lasCanModel, lasCannonID, ship.GetSelfId(), ship.GetTeamId());
            lasCannon.readyAction();
        }

        public override void newTurn()
        {
            if(this.GetCrewCount() > 0)
            {
                lasCannon.UseAction(lasCannon.AvailableTargets());
                lasCannon.AdvanceRound();
            }
        }
    }
}
