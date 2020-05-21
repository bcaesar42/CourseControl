using src.Model.ModelFramework.Targetables;

namespace src.Model.ModelFramework.TargetableFramework.Shieldable
{
    public interface IShieldable : ITargetable
    {
        int MaxShieldCount();
        int CurrentShieldCount();
        int DamageShield(int damageCount);
        void ActivateShield(int shieldCount);
    }
}
