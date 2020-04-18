namespace src.Model.ModelFramework.Targetables.Damageable
{
    public interface IDamageable : ITargetable
    {
        int TotalHP();
        int CurrentHP();
        int Damage(int damageCount);
    }
}
