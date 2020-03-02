using System.Collections.Generic;
using src.Model.ModelFramework.Actionables;
using src.Model.ModelFramework.ActionFramework.ActionTurnModels;

namespace src.Model.ModelFramework.ActionFramework.ActionModels
{
    public class WeaponModel: ActionModel
    {
        public readonly IEnumerable<WeaponTurnModel> WeaponTurnModel;
        
        public WeaponModel(string actionName, ActionTime actionTime, int actionLevel, string description, string roomModel, IEnumerable<WeaponTurnModel> weaponTurnModel) : base(actionName, actionTime, actionLevel, description, roomModel)
        {
            WeaponTurnModel = weaponTurnModel;
        }
    }
}