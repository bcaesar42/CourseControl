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
            WeaponsBay weaponsBay = new WeaponsBay(this, Guid.NewGuid());
            NavigationRoom navigation = new NavigationRoom(this, Guid.NewGuid());
            DroneBay droneBay = new DroneBay(this, Guid.NewGuid());
            MaintenanceBay maintenanceBay = new MaintenanceBay(this, Guid.NewGuid());
            ScavengeBay scavengeBay = new ScavengeBay(this, Guid.NewGuid());
            SensorRoom sensorRoom = new SensorRoom(this, Guid.NewGuid());
            ShieldBay shieldBay = new ShieldBay(this, Guid.NewGuid());
            ResearchCenter researchCenter = new ResearchCenter(this, Guid.NewGuid());
        }

        public Wishbone(ShipModel model, Guid teamId) : base(model, teamId)
        {
        }
    }
}
