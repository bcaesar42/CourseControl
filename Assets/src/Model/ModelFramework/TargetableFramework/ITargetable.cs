using System;

namespace src.Model.ModelFramework.TargetableFramework
{
    public interface ITargetable
    {
        //This is the base interface for all targetables.
        Guid GetSelfId();
        Guid GetTeamId();
    }
}
