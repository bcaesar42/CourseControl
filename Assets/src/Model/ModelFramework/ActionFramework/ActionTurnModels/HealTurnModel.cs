namespace src.Model.ModelFramework.ActionFramework.ActionTurnModels
{
    public class HealTurnModel : ActionTurnModel
    {
        public readonly int Heal;

        public HealTurnModel(int heal, int roundNumber) : base(roundNumber)
        {
            Heal = heal;
        }
    }
}