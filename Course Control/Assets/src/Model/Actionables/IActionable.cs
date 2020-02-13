using System.Collections.Generic;
using src.Action;
using src.Model.Targetable;

namespace src.Model.Actionables
{
    public interface IActionable
    {
        ActionKind GetActionKind();
        IEnumerable<ITargetable> AvailableTargets();
        //I added self back in so that the action knows who it's from, otherwise there's no way for it to know
        void Do(int turnNumber, ITargetable self, IEnumerable<ITargetable> targets);
    }
}