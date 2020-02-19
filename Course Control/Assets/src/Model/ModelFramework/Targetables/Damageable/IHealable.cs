namespace src.Model.ModelFramework.Targetables.Damageable
{
    public interface IHealable : ITargetable
    {
        int TotalHp();
        int CurrentHp();
        int Heal(int healCount);
    }
}