using System;
using src.Action;

namespace src.Model.ModelFramework.Actionables.ActionKinds
{
    public class WeaponKind: ActionKind
    {
        public WeaponKind(string actionName, ActionTime actionTime, int actionLevel, string description, string roomModel) : base(actionName, actionTime, actionLevel, description, roomModel)
        {
        }
    }
}