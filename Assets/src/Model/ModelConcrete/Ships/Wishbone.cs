using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using src.Model.ModelFramework.ShipFramework;
using src.View.Rooms.ConcreteRooms;

namespace Assets.src.Model.ModelConcrete.Ships
{
    public class Wishbone : BaseShip
    {
        public Wishbone(ShipModel model) : base(model)
        {
            WeaponsBay weaponsBay = new WeaponsBay(this, new Guid());
            NavigationRoom navigation = new NavigationRoom(this, new Guid());
        }

        public Wishbone(ShipModel model, Guid teamId) : base(model, teamId)
        {
        }
    }
}
