﻿using src.Model.ModelConcrete.Ships;
using UnityEngine;

namespace src.View.Rooms.ConcreteRooms
{
    public class SensorRoom : BaseRoom
    {
        public SensorRoom(BaseShip ship, System.Guid teamId) 
            : base(ship, "Sensor Room", 0, 3, new System.Guid(), teamId)
        {
        }

        public override void newTurn()
        {
            Debug.Log("Not Implemented");
        }
    }
}
