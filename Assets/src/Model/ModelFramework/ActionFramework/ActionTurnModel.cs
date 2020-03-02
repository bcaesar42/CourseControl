namespace src.Model.ModelFramework.ActionFramework
{
    public abstract class ActionTurnModel
    {
        public readonly int RoundNumber;

        protected ActionTurnModel(int roundNumber)
        {
            RoundNumber = roundNumber;
        }
    }
}