using System;
using System.Collections;
using System.Collections.Generic;
using src.Action;
using src.Model.ModelFramework.Actionables;
using src.Model.ModelFramework.Targetables;

namespace src.Action
{
    [Obsolete("use Model.ModelConcrete.Actions instead")]
    public class Action
    {
        public readonly IActionable Actionable;
        private ITargetable _self;
        private ActionTime _actionTime;

        private int _currentActivationTime;
        private int _currentCompletionTime;
        private int _currentCooldownTime;
        private int _currentActivationLeft;
        private int _currentCompletionLeft;
        private int _currentCooldownLeft;

        private IEnumerable<ITargetable> _currentTargets;

        protected Action(IActionable actionable, ITargetable self)
        {
            Actionable = actionable;
            this._self = self;
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
                _actionTime = Actionable.GetActionTime();
                if (!value)
                {
                    CurrentState = ActionState.Inactive;
                }
                else if (CurrentState == ActionState.Inactive)
                {
                    _currentActivationTime = _actionTime.ActivationTime;
                    _currentCompletionTime = _actionTime.CompletionTime;
                    _currentCooldownTime = _actionTime.CooldownTime;
                    _currentActivationLeft = _currentActivationTime;
                    _currentCompletionLeft = _currentCompletionTime;
                    _currentCooldownLeft = _currentCooldownTime;

                    CurrentState = ActionState.Ready;
                }
            }
        }

        public IEnumerable<ITargetable> AvailableTargets()
        {
            return Actionable.AvailableTargets();
        }

        public bool UseAction(IEnumerable<ITargetable> targets)
        {
            if (!ActionUsable)
            {
                return false;
            }

            _currentTargets = targets;
            CurrentState = ActionState.Activation;
            return true;
        }

        public ActionState AdvanceRound()
        {
            _actionTime = Actionable.GetActionTime();
            switch (CurrentState)
            {
                case ActionState.Inactive:
                    return ActionState.Inactive;
                case ActionState.Ready:
                    _currentActivationTime = _actionTime.ActivationTime;
                    _currentCompletionTime = _actionTime.CompletionTime;
                    _currentCooldownTime = _actionTime.CooldownTime;
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
                Actionable.Do(_currentActivationLeft, _self, _currentTargets);
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