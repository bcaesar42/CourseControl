using src.Model.ModelFramework.Actionables.ActionTurnModels;

namespace src.Model.ModelFramework.Actionables.ActionModels
{
    public class WeaponModel: ActionModel
    {
        public readonly WeaponTurnModel[] WeaponTurnModel;
        
        public WeaponModel(string actionName, ActionTime actionTime, int actionLevel, string description, string roomModel, WeaponTurnModel[] weaponTurnModel) : base(actionName, actionTime, actionLevel, description, roomModel)
        {
            WeaponTurnModel = weaponTurnModel;
        }
    }
}