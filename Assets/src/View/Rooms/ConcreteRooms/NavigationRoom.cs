using System;
using src.Controller.ActionModelManager;
using src.Model.ModelFramework.ActionFramework;

namespace src.View.Rooms.ConcreteRooms
{
    public class NavigationRoom : BaseRoom
    {
        //1C1E28A2-4247-4249-9EEC-6A0D31256A7F
        Guid baseNavID = Guid.Parse("1C1E28A2-4247-4249-9EEC-6A0D31256A7F");
        BaseNav baseNave;
        public static readonly SceneManager instance = new SceneManager();

        public NavigationRoom(BaseShip ship, System.Guid teamId) 
            : base(ship, "Navigation Room", 0, 3, new System.Guid(), teamId)
        {
            ActionModel BaseNavModel = ActionManager.instance.GetActionModel(baseNavID, 0);
            baseNave = new BaseNav(BaseNavModel, baseNavID, ship.GetSelfId(), ship.GetTeamId());
            baseNave.readyAction();
        }
        public override void newTurn()
        {
            this.ship.setEvadeChance(0);
            if (this.GetCrewCount() > 0)
            {
                baseNave.UseAction(baseNave.AvailableTargets());
                baseNave.AdvanceRound();
            }
        }
    }
}
