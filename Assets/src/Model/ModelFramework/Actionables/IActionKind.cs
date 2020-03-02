using System;
using src.Action;
using ActionTime = src.Model.ModelFramework.ActionFramework.ActionTime;

namespace src.Model.ModelFramework.Actionables
{
    
    [Obsolete("use Model.ModelFramework.ActionFramework.ActonModels instead")]
    public interface IActionKind
    {
        ActionTime GetActionTime();
    }
}