using System;
using System.Collections.Generic;
using src.Action;
using src.Model.ModelFramework.Targetables;

namespace src.Model.ModelFramework.Actionables
{
    public interface IActionable
    {
        Guid GetSelfId();
        Guid GetTeamId();
        ActionKind GetActionKind();

        IEnumerable<ITargetable> AvailableTargets();

        void Do(int turnNumber, IEnumerable<ITargetable> targets);
    }
}