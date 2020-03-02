namespace src.Model.ModelFramework.Actionables.ActionTurnModels
{
    public class WeaponTurnModel
    {
        public readonly int Damage;
        public readonly int Shots;
        public readonly int ChanceToHit;//0 to 100

        public WeaponTurnModel(int damage, int shots, int chanceToHit)
        {
            Damage = damage;
            Shots = shots;
            ChanceToHit = chanceToHit;
        }
    }
}