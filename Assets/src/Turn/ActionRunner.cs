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
        public bool SubscribeAction(GameAction action)
        {
            bool didSubscribe = false;

            if (action != null)
            {
                SubscribedActions.Append(action);
                didSubscribe = true;
            }

            return didSubscribe;
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
                IEnumerable<Task> tasks = priorityGroup.Select(action => action.PerformAction());

                foreach (Task task in tasks)
                {
                    task.Start();
                }

                await Task.WhenAll(tasks.ToArray()); // Wait for all Task from this priority level to finish before starting the Task of the next priority level.
            }
        }
    */}
    
}
