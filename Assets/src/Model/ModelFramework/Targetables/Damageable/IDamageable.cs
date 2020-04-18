namespace src.Model.ModelFramework.Targetables.Damageable
{
    public interface IDamageable : ITargetable
    {
        int TotalHP();
        int CurrentHP();
        void Damage(int damageCount);
    }
}
