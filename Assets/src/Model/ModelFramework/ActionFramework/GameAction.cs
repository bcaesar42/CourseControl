using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using src.Controller.TargetManager;
using src.Model.ModelFramework.Targetables;

namespace src.Model.ModelFramework.ActionFramework
{
    public abstract class GameAction
    {
        private string actionName; //Name of the action
        private readonly Guid _actionId;
        private ActionModel model;

        private readonly TargetManager _targetManager;
        public readonly Guid ActionInstanceId;
        public readonly ActionPriority Priority;
        public readonly Guid SelfId;
        public readonly Guid TeamId;
        public int level;
        private int _currentActivationLeft;

        private int _currentActivationTime;
        private int _currentCompletionLeft;
        private int _currentCompletionTime;
        private int _currentCooldownLeft;
        private int _currentCooldownTime;

        private ActionState _currentState;

        protected IEnumerable<ITargetable> Targets;

        protected GameAction(TargetManager targetManager, Guid actionId, Guid actionInstanceId, Guid selfId, Guid teamId)
        {
            _targetManager = targetManager;
            _actionId = actionId;
            ActionInstanceId = actionInstanceId;
            SelfId = selfId;
            TeamId = teamId;
        }

        public ActionState CurrentState
        {
            get => _currentState;
            set
            {
                if (value == ActionState.Ready || value == ActionState.Activation || value == ActionState.Completion ||
                    value == ActionState.Cooldown || value == ActionState.Deactivated)
                    _currentState = value;
            }
        }

        public bool ActionUsable
        {
            get => CurrentState == ActionState.Ready;
            set
            {
                if (!value)
                {
                    CurrentState = ActionState.Deactivated;
                }
                else if (CurrentState == ActionState.Deactivated)
                {
                    _currentActivationTime = GetActionModel().ActionTime.ActivationTime;
                    _currentCompletionTime = GetActionModel().ActionTime.CompletionTime;
                    _currentCooldownTime = GetActionModel().ActionTime.CooldownTime;
                    _currentActivationLeft = _currentActivationTime;
                    _currentCompletionLeft = _currentCompletionTime;
                    _currentCooldownLeft = _currentCooldownTime;

                    CurrentState = ActionState.Ready;
                }
            }
        }

        public Task PerformAction { get; internal set; }

        public abstract ActionModel GetActionModel(); //

        public abstract IEnumerable<ITargetable> AvailableTargets();

        protected abstract void DoAction(int roundNum, IEnumerable<ITargetable> targets);

        public bool UseAction(IEnumerable<ITargetable> targets)
        {
            if (!ActionUsable) return false;

            Targets = targets;
            CurrentState = ActionState.Activation;
            return true;
        }

        public ActionState AdvanceRound()
        {
            switch (CurrentState)
            {
                case ActionState.Deactivated:
                    return ActionState.Deactivated;
                case ActionState.Ready:
                    _currentActivationTime = GetActionModel().ActionTime.ActivationTime;
                    _currentCompletionTime = GetActionModel().ActionTime.CompletionTime;
                    _currentCooldownTime = GetActionModel().ActionTime.CooldownTime;
                    _currentActivationLeft = _currentActivationTime;
                    _currentCompletionLeft = _currentCompletionTime;
                    _currentCooldownLeft = _currentCooldownTime;

                    return ActionState.Ready;
                case ActionState.Activation:
                    _currentActivationLeft--;
                    break;
                case ActionState.Completion:
                    _currentCompletionLeft--;
                    break;
                case ActionState.Cooldown:
                    _currentCooldownLeft--;
                    break;
                default:
                    CurrentState = ActionState.Ready;
                    return ActionState.Ready;
            }

            if (CurrentState == ActionState.Activation)
            {
                if (_currentActivationLeft <= _currentActivationTime)
                    CurrentState = ActionState.Completion;
                else
                    return ActionState.Activation;
            }

            if (CurrentState == ActionState.Completion)
            {
                //Call the IActionable version of this
                if (_currentCompletionLeft <= _currentCompletionTime)
                    CurrentState = ActionState.Cooldown;
                else
                    return ActionState.Completion;
            }

            if (CurrentState == ActionState.Cooldown)
            {
                if (_currentCooldownLeft <= _currentCooldownTime)
                    CurrentState = ActionState.Ready;
                else
                    return ActionState.Cooldown;
            }

            return CurrentState;
        }
    }
}
