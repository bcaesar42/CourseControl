namespace src.Model.ModelFramework.Targetables.Shieldable
{
    public interface IShieldable : ITargetable
    {
        int MaxShieldCount();
        int CurrentShieldCount();
        void DamageShield(int damageCount);
    }
}
