namespace src.Model.ModelFramework.ActionFramework.ActionTurnModels
{
    public class WeaponTurnModel: ActionTurnModel
    {
        public readonly int Damage;
        public readonly int Shots;
        public readonly int ChanceToHit;//0 to 100

        public WeaponTurnModel(int roundNumber, int damage, int shots, int chanceToHit) : base(roundNumber)
        {
            Damage = damage;
            Shots = shots;
            ChanceToHit = chanceToHit;
        }
    }
}