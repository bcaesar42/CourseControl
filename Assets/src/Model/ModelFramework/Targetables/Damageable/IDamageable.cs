namespace src.Model.ModelFramework.Targetables.Damageable
{
    public interface IDamageable : ITargetable
    {
        int TotalHP();
        int CurrentHP();
<<<<<<< HEAD
        int Damage(int damageCount);
=======
        void Damage(int damageCount);
>>>>>>> ShipBranch
    }
}
