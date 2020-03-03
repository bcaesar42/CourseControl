namespace src.Model.ModelFramework.ActionFramework.ActionTurnModels
{
    public class NavigationTurnModel : ActionTurnModel
    {
        public readonly int ChanceToDodge; //0 to 100

        public NavigationTurnModel(int chanceToDodge, int roundNumber) : base(roundNumber)
        {
            ChanceToDodge = chanceToDodge;
        }
    }
}