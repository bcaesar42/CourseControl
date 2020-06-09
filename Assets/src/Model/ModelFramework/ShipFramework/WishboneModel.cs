using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.src.Model.ModelConcrete.Ships;
using JetBrains.Annotations;
using src.Controller.TargetManager;
using src.Model.ModelFramework.ActionFramework;
using src.Model.ModelFramework.ShipFramework;

namespace Assets.src.Model.ModelFramework.ShipFramework
{
    public class WishboneModel : ShipModel
    {
        public WishboneModel()
        {
            Name = "Wishbone mk.1";
            ShipId = new Guid();
            Description = "The first attempt at something flightworthy...";
            InitialCrewCount = 5;
            InitialMaxHealth = 50;

            //ShipModelFile
            //GameActionId1
            //GameActionId2
            //GameActionId3
            //GameActionId4
            //GameActionId5
            //GameActionId6
            //GameActionId7
        }
    }
}
