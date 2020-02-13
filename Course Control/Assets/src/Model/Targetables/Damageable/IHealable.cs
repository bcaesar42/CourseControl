namespace src.Model.Targetable.Damageable
{
    public interface IHealable : ITargetable
    {
        int TotalHp();
        int CurrentHp();
        int Heal(int healCount);
    }
}