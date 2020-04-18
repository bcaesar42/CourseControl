namespace src.Model.ModelFramework.Targetables.Damageable
{
    public interface IHealable : ITargetable
    {
        int TotalHP();
        int CurrentHP();
        int Heal(int healCount);
    }
}
