using System;
using src.Controller;
using src.Controller.ActionModelManager;
using src.Model.ModelConcrete.GameActions;
using src.Model.ModelFramework.ActionFramework;

namespace src.View.Rooms.ConcreteRooms
{
    public class ShieldBay : BaseRoom
    {
        Guid ShieldID = Guid.Parse("64EE9EA2-C2E0-4E71-BB29-C6b1CE251394");
        Shield baseShield;
        public static readonly SceneManager instance = new SceneManager();

        public ShieldBay(BaseShip ship, System.Guid teamId)
            : base(ship, "Shield Bay", 0, 3, new Guid(), teamId)
        {
            ActionModel ShieldModel = ActionManager.instance.GetActionModel(ShieldID, 0);
            baseShield = new Shield(ShieldModel, ShieldID, ship.GetSelfId(), ship.GetTeamId());
            baseShield.readyAction();
        }
        public override void newTurn()
        {
            if (this.GetCrewCount() > 0)
            {
                baseShield.UseAction(baseShield.AvailableTargets());
                baseShield.AdvanceRound();
            }
        }
    }
}
