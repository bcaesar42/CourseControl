using System;
using System.Collections.Generic;
using System.Linq;
using src.Model.ModelFramework.ActionFramework;

namespace src.Turn
{
    public class ActionRunner
    {
        // Constructor:
        public ActionRunner()
        {
            SubscribedActions_VeryLow = new List<GameAction>();
            SubscribedActions_Low = new List<GameAction>();
            SubscribedActions_Moderate = new List<GameAction>();
            SubscribedActions_High = new List<GameAction>();
            SubscribedActions_VeryHigh = new List<GameAction>();
        }

        // Properties and fields:
        private IEnumerable<GameAction> SubscribedActions_VeryLow { get; }
        private IEnumerable<GameAction> SubscribedActions_Low { get; }
        private IEnumerable<GameAction> SubscribedActions_Moderate { get; }
        private IEnumerable<GameAction> SubscribedActions_High { get; }
        private IEnumerable<GameAction> SubscribedActions_VeryHigh { get; }
        public int TurnNum { get; private set; }


        // Methods:
        public bool
            SubscribeAction(GameAction action) // The first "Action" specifies the namespace, the second "Action" specifies the class.
        {
            var didSubscribe = false;

            ActionPriority priority = action.Priority;

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
