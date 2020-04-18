namespace src.Model.ModelFramework.Targetables.Shieldable
{
    public interface IShieldDamagable : ITargetable
    {
        int MaxShieldCount();
        int CurrentShieldCount();
        int DamageShield(int damageCount);
    }
}
