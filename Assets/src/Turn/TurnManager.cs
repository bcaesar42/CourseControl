using System;
using System.Collections.Generic;
using System.Linq;

namespace src.Turn
{
    public class TurnManager
    {
        // Properties and fields:
        private List<Action.Action> SubscribedActions { get; set; }
        public int TurnNum { get; private set; }


        // Constructor:
        public TurnManager()
        {
            SubscribedActions = new List<Action.Action>();
        }

        // Properties and fields:
        private IEnumerable<Action.Action> SubscribedActions_VeryLow { get; }
        private IEnumerable<Action.Action> SubscribedActions_Low { get; }
        private IEnumerable<Action.Action> SubscribedActions_Moderate { get; }
        private IEnumerable<Action.Action> SubscribedActions_High { get; }
        private IEnumerable<Action.Action> SubscribedActions_VeryHigh { get; }
        public int TurnNum { get; private set; }


        // Methods:
        public bool
            SubscribeAction(Action.Action action,
                ActionPriority priority) // The first "Action" specifies the namespace, the second "Action" specifies the class.
        {
            var didSubscribe = false;

            if (action != null)
            {
                SubscribedActions.Append(action);
            }

            return didSubscribe;
        }

        public void PerformActions()
        {
            SubscribedActions.Sort();

        }
    }
}