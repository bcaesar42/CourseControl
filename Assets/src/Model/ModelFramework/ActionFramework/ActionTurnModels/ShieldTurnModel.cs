namespace src.Model.ModelFramework.ActionFramework.ActionTurnModels
{
    public class ShieldTurnModel : ActionTurnModel
    {
        public readonly int TempHp;

        public ShieldTurnModel(int tempHp, int roundNumber) : base(roundNumber)
        {
            TempHp = tempHp;//TODO decide on if shields work as temp hp or essentially an extension of hp being persistent form round to round
        }
    }
}
