namespace CourseControl.src.Action
{
    public class Action
    {
        public readonly IActionable Actionable;
        public readonly ActionKind ActionKind;

        private int _currentActivationTime;
        private int _currentCompletionTime;
        private int _currentCooldownTime;
        private int _currentActivationLeft;
        private int _currentCompletionLeft;
        private int _currentCooldownLeft;

        protected Action(IActionable actionable, ActionKind actionKind)
        {
            Actionable = actionable;
            ActionKind = actionKind;
        }

        private ActionState _currentState;

        public ActionState CurrentState
        {
            get => _currentState;
            set
            {
                if (value == ActionState.Ready || value == ActionState.Activation || value == ActionState.Completion ||
                    value == ActionState.Cooldown || value == ActionState.Inactive)
                {
                    _currentState = value;
                }
            }
        }

        public bool ActionUsable
        {
            get => CurrentState == ActionState.Ready;
            set
            {
                if (!value)
                {
                    CurrentState = ActionState.Inactive;
                }
                else if (CurrentState == ActionState.Inactive)
                {
                    _currentActivationTime = _actionKind.ActivationTime;
                    _currentCompletionTime = _actionKind.CompletionTime;
                    _currentCooldownTime = _actionKind.CooldownTime;
                    _currentActivationLeft = _currentActivationTime;
                    _currentCompletionLeft = _currentCompletionTime;
                    _currentCooldownLeft = _currentCooldownTime;

                    CurrentState = ActionState.Ready;
                }
            }
        }

        public bool UseAction()
        {
            if (!ActionUsable)
            {
                return false;
            }

            CurrentState = ActionState.Activation;
            return true;
        }

        public ActionState AdvanceRound()
        {
            switch (CurrentState)
            {
                case ActionState.Inactive:
                    return ActionState.Inactive;
                case ActionState.Ready:
                    _currentActivationTime = _actionKind.ActivationTime;
                    _currentCompletionTime = _actionKind.CompletionTime;
                    _currentCooldownTime = _actionKind.CooldownTime;
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
                {
                    CurrentState = ActionState.Completion;
                }
                else
                {
                    return ActionState.Activation;
                }
            }

            if (CurrentState == ActionState.Completion)
            {
                if (_currentCompletionLeft <= _currentCompletionTime)
                {
                    CurrentState = ActionState.Cooldown;
                }
                else
                {
                    return ActionState.Completion;
                }
            }

            if (CurrentState == ActionState.Cooldown)
            {
                if (_currentCooldownLeft <= _currentCooldownTime)
                {
                    CurrentState = ActionState.Ready;
                }
                else
                {
                    return ActionState.Cooldown;
                }
            }

            return CurrentState;
        }
    }
}