using System.Collections;
using System.Collections.Generic;
using src.Targetable;

namespace src.Action
{
    public interface IActionable
    {
        ActionKind GetActionKind();
        IEnumerable<ITargetable> AvailableTargets();
        void Do(int turnNumber, IEnumerable<ITargetable> targets);
    }
}