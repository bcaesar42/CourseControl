namespace src.Model.ModelFramework.TargetableFramework.Damageable
{
    public interface IHealable : ITargetable
    {
        int TotalHP();
        int CurrentHP();
        int Heal(int healCount);
        int IncreaseMaxHealth(int amountToAdd);
        int DecreaseMaxHealth(int amountToRemove);
    }
}
