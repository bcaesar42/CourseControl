namespace src.Targetable.Shieldable
{
    public interface IShieldHealable : ITargetable
    {
        int MaxShieldCount();
        int CurrentShieldCount();
        int HealShield(int healCount);
    }
}