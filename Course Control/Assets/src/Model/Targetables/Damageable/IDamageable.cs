namespace src.Model.Targetable.Damageable
{
    public interface IDamageable : ITargetable
    {
        int TotalHp();
        int CurrentHp();
        int Damage(int damageCount);
    }
}