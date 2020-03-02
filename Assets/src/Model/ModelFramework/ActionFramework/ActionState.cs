namespace src.Model.ModelFramework.ActionFramework
{
    public enum ActionState
    {
        //Inactive: Action is not being used, and cannot be used
        //Ready: Action is not being used, and can be used
        //Activation: Action is being used, but has not started doing its job yet
        //Completion: Action is being used, and is in the process of doing its job
        //Cooldown: Action has finished being used and cannot be used again until out of this state and back into ready
        Deactivated, Ready, Activation, Completion, Cooldown
    }
}