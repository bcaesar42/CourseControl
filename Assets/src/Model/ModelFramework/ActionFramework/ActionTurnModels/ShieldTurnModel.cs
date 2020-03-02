namespace src.Model.ModelFramework.ActionFramework.ActionTurnModels
{
    public class ShieldTurnModel: ActionTurnModel
    {
        public readonly int TempHp;

        public ShieldTurnModel(int tempHp, int roundNumber) : base(roundNumber)
        {
            this.TempHp = tempHp;
        }
    }
}