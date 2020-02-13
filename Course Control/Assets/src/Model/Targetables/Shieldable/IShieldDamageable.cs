namespace src.Model.Targetable.Shieldable
{
    public interface IShieldable : ITargetable
    {
        int MaxShieldCount();
        int CurrentShieldCount();
        int DamageShield(int damageCount);
    }
}