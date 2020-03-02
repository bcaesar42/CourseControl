namespace src.Model.ModelFramework.Actionables.ActionTurnModels
{
    public class NavigationTurnModel
    {
        public readonly int ChanceToDodge;//0 to 100

        public NavigationTurnModel(int chanceToDodge)
        {
            this.ChanceToDodge = chanceToDodge;
        }
    }
}