using System.Collections.Generic;
using src.Action;
using src.Model.ModelFramework.Targetables;

namespace src.Model.ModelFramework.Actionables
{
    public interface IActionable
    {
        ActionTime GetActionTime();
        IActionKind GetActionKind();

        IEnumerable<ITargetable> AvailableTargets();

        //I added self back in so that the action knows who it's from, otherwise there's no way for it to know
        void Do(int turnNumber, ITargetable self, IEnumerable<ITargetable> targets);
    }
}