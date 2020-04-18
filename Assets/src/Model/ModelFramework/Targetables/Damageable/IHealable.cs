namespace src.Model.ModelFramework.Targetables.Damageable
{
    public interface IHealable : ITargetable
    {
        int TotalHP();
        int CurrentHP();
<<<<<<< HEAD
        int Heal(int healCount);
=======
        void Heal(int healCount);
>>>>>>> ShipBranch
    }
}
