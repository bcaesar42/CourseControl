namespace src.Targetable
{
    public interface IShieldable : ITargetable
    {
        int MaxShieldCount();
        int CurrentShieldCount();
        int DamageShield(int damageCount);
    }
}