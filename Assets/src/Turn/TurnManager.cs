using System;
using System.Collections.Generic;
using System.Linq;

namespace src.Turn
{
    public class TurnManager
    {
        // Constructor:
        public TurnManager()
        {
            SubscribedActions_VeryLow = new List<Action>();
            SubscribedActions_Low = new List<Action>();
            SubscribedActions_Moderate = new List<Action>();
            SubscribedActions_High = new List<Action>();
            SubscribedActions_VeryHigh = new List<Action>();
        }

        // Properties and fields:
        private IEnumerable<Action> SubscribedActions_VeryLow { get; }
        private IEnumerable<Action> SubscribedActions_Low { get; }
        private IEnumerable<Action> SubscribedActions_Moderate { get; }
        private IEnumerable<Action> SubscribedActions_High { get; }
        private IEnumerable<Action> SubscribedActions_VeryHigh { get; }
        public int TurnNum { get; private set; }


        // Methods:
        public bool
            SubscribeAction(Action action,
                ActionPriority priority) // The first "Action" specifies the namespace, the second "Action" specifies the class.
        {
            var didSubscribe = false;

            if (action != null)
                switch (priority)
                {
                    case ActionPriority.VeryLow:
                        SubscribedActions_VeryLow.Append(action);
                        break;
                    case ActionPriority.Low:
                        SubscribedActions_Low.Append(action);
                        break;
                    case ActionPriority.Moderate:
                        SubscribedActions_Moderate.Append(action);
                        break;
                    case ActionPriority.High:
                        SubscribedActions_High.Append(action);
                        break;
                    case ActionPriority.VeryHigh:
                        SubscribedActions_VeryHigh.Append(action);
                        break;
                }

            return didSubscribe;
        }
    }
}
