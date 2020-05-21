namespace src.Model.ModelFramework.TargetableFramework.Damageable
{
    public interface IDamageable : ITargetable
    {
        int TotalHP();
        int CurrentHP();
        int Damage(int damageCount);
        int IncreaseMaxHealth(int amountToAdd);
        int DecreaseMaxHealth(int amountToRemove);
    }
}
