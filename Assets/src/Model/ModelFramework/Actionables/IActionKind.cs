using System;
using src.Action;

namespace src.Model.ModelFramework.Actionables
{
    
    [Obsolete("use Model.ModelFramework.ActionFramework.ActonModels instead")]
    public interface IActionKind
    {
        ActionTime GetActionTime();
    }
}