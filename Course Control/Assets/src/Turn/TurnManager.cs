﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Turn
{
    public class TurnManager
    {
        // Properties and fields:
        private IEnumerable<Action.Action> SubscribedActions;
        public int TurnNum { get; private set; }


        // Constructor:
        public TurnManager()
        {
            SubscribedActions = new List<Action.Action>();
        }


        // Methods:
        public bool SubscribeAction(Action.Action action, ActionPriority priority) // The first "Action" specifies the namespace, the second "Action" specifies the class.
        {
            bool didSubscribe = false;

            if (action != null)
            {
                SubscribedActions.
            }

            return didSubscribe;
        }


    }
}
