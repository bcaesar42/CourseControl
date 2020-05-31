using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using src.Model.ModelFramework.ShipFramework;

namespace Assets.src.Model.ModelConcrete.Ships
{
    public class Wishbone : BaseShip
    {
        public Wishbone(ShipModel model) : base(model)
        {
        }

        public Wishbone(ShipModel model, Guid teamId) : base(model, teamId)
        {
        }
    }
}
