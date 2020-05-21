using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using src.Controller.TargetManager;
using src.Model.ModelFramework.TargetableFramework;
using src.Model.ModelFramework.Targetables;
using UnityEngine;

namespace src.Model.ModelFramework.ActionFramework
{
    public abstract class GameAction
    {
        //private string actionName; //Name of the action
        public readonly Guid ActionInstanceId;
        public readonly Guid SelfId;
        public readonly Guid TeamId;

        private ActionModel _actionModelBacking;

        public ActionModel ActionModel
        {
            get
            {
                return _actionModelBacking;
            }
            private set
            {
                if (IsValidActionModel(value))
                {
                    _actionModelBacking = value;
                }
                else
                {
                    Debug.Log(
                        $"Action: {ActionInstanceId} tried to assign ActionModel: {_actionModelBacking.ActionId} {_actionModelBacking.ActionName} but the actionModel was of the wrong type");
                }
            }
        }

        private int _currentActivationLeft;
        private int _currentActivationTime;
        private int _currentCompletionLeft;
        private int _currentCompletionTime;
        private int _currentCooldownLeft;
        private int _currentCooldownTime;

        private ActionState _currentState;

        protected IEnumerable<ITargetable> Targets;

        protected GameAction(ActionModel actionModel, Guid actionId, Guid selfId, Guid teamId)
        {
            ActionModel = actionModel;
            ActionInstanceId = actionId;
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
                    _currentActivationTime = ActionModel.ActionTime.ActivationTime;
                    _currentCompletionTime = ActionModel.ActionTime.CompletionTime;
                    _currentCooldownTime = ActionModel.ActionTime.CooldownTime;
                    _currentActivationLeft = _currentActivationTime;
                    _currentCompletionLeft = _currentCompletionTime;
                    _currentCooldownLeft = _currentCooldownTime;

                    CurrentState = ActionState.Ready;
                }
            }
        }

        public abstract IEnumerable<ITargetable> AvailableTargets();

        public abstract bool IsValidActionModel(ActionModel actionModel);

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
                    _currentActivationTime = ActionModel.ActionTime.ActivationTime;
                    _currentCompletionTime = ActionModel.ActionTime.CompletionTime;
                    _currentCooldownTime = ActionModel.ActionTime.CooldownTime;
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
                if (_currentCompletionLeft <= _currentCompletionTime)
                    CurrentState = ActionState.Cooldown;
                else
                {
                    DoAction(_currentCooldownTime - _currentCompletionLeft, Targets);
                    return ActionState.Completion;
                }
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
