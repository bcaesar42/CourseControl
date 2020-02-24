namespace src.Model.ModelFramework.Targetables.Shieldable
{
    public interface IShieldHealable : ITargetable
    {
        int MaxShieldCount();
        int CurrentShieldCount();
        int HealShield(int healCount);
    }
}