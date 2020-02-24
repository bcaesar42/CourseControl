using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Turn
{
    public class TurnManager
    {
        // Properties and fields:
        private IEnumerable<Action.Action> SubscribedActions_VeryLow { get; set; }
        private IEnumerable<Action.Action> SubscribedActions_Low { get; set; }
        private IEnumerable<Action.Action> SubscribedActions_Moderate { get; set; }
        private IEnumerable<Action.Action> SubscribedActions_High { get; set; }
        private IEnumerable<Action.Action> SubscribedActions_VeryHigh { get; set; }
        public int TurnNum { get; private set; }


        // Constructor:
        public TurnManager()
        {
            SubscribedActions_VeryLow = new List<Action.Action>();
            SubscribedActions_Low = new List<Action.Action>();
            SubscribedActions_Moderate = new List<Action.Action>();
            SubscribedActions_High = new List<Action.Action>();
            SubscribedActions_VeryHigh = new List<Action.Action>();
        }


        // Methods:
        public bool SubscribeAction(Action.Action action, ActionPriority priority) // The first "Action" specifies the namespace, the second "Action" specifies the class.
        {
            bool didSubscribe = false;

            if (action != null)
            {
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
            }

            return didSubscribe;
        }


    }
}
