using System;
using System.Collections.Generic;
using src.Model.ModelFramework.Actionables;
using src.Model.ModelFramework.Targetables;

namespace src.Model.ModelConcrete.Actions
{
    public class Scavenger: IActionable
    {
        public Guid GetSelfId()
        {
            throw new NotImplementedException();
        }

        public Guid GetTeamId()
        {
            throw new NotImplementedException();
        }

        public ActionKind GetActionKind()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITargetable> AvailableTargets()
        {
            throw new NotImplementedException();
        }

        public void Do(int turnNumber, IEnumerable<ITargetable> targets)
        {
            throw new NotImplementedException();
        }
    }
}