namespace src.Model.ModelFramework.Targetables.Damageable
{
    public interface IDamageable : ITargetable
    {
        int TotalHp();
        int CurrentHp();
        int Damage(int damageCount);
    }
}