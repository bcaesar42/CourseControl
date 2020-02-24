using System;
using src.Action;

namespace src.Model.ModelFramework.Actionables.ActionKinds
{
    public class Weapon: Action
    {
        public Weapon(string actionName, ActionTime actionTime, int actionLevel, string description, string roomModel) : base(actionName, actionTime, actionLevel, description, roomModel)
        {
        }
    }
}