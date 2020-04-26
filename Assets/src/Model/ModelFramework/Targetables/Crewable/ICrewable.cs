namespace src.Model.ModelFramework.Targetables.Crewable
{
    public interface ICrewable
    {
        int MaxCrewCount();
        int CurrentCrewCount();
        bool AllocateCrew(int crewToAllocate);
        bool FreeCrew(int crewToFree);
        int IncreaseCrewCount(int amountToAdd);
        int DecreaseCrewCount(int amountToRemove);
    }
}
