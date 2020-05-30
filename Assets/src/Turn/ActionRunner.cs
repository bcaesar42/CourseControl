using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Model.ModelFramework.ActionFramework;

namespace src.Turn
{
    public class ActionRunner
    {

        /*
        // Constructor:
        public ActionRunner()
        {
            SubscribedActions = new List<GameAction>();
        }


        // Properties and fields:
        private List<GameAction> SubscribedActions { get; set; }


        // Methods:
        public bool SubscribeAction(GameAction action) // The first "Action" specifies the namespace, the second "Action" specifies the class.
        {
            bool didSubscribe = false;

            ActionPriority priority = action.ActionModel.Priority;

            return true; //TODO get this to error check itself before assigning to true
        }

        public bool UnsubscribeAction(GameAction action)
        {
            bool didUnsubscribe = false;

            if (action != null && SubscribedActions.Contains(action))
            {
                SubscribedActions.Remove(action);
                didUnsubscribe = true;
            }

            return didUnsubscribe;
        }

        public void Reset()
        {
            SubscribedActions = new List<GameAction>();
        }

        public async void RunActions()
        {
            IOrderedEnumerable<IGrouping<ActionPriority, GameAction>> priorityGroups = SubscribedActions.GroupBy(action => action.ActionModel.Priority).OrderBy(group => group.Key);
            
            foreach (IGrouping<ActionPriority, GameAction> priorityGroup in priorityGroups)
            {
                IEnumerable<Task> tasks = priorityGroup.Select(action => action.AdvanceRound);

                foreach (Task task in tasks)
                {
                    
                    switch (task)
                    {
                        case ActionPriority.VeryLow:
                            SubscribedActions_VeryLow.Append(action);
                            didSubscribe = true;
                            break;
                        case ActionPriority.Low:
                            SubscribedActions_Low.Append(action);
                            didSubscribe = true;
                            break;
                        case ActionPriority.Moderate:
                            SubscribedActions_Moderate.Append(action);
                            didSubscribe = true;
                            break;
                        case ActionPriority.High:
                            SubscribedActions_High.Append(action);
                            didSubscribe = true;
                            break;
                        case ActionPriority.VeryHigh:
                            SubscribedActions_VeryHigh.Append(action);
                            didSubscribe = true;
                            break;
                    }
                    
                }

                await Task.WhenAll(tasks.ToArray()); // Wait for all Task from this priority level to finish before starting the Task of the next priority level.
            }
        } */
    } 
    
}
