using System.Collections.Generic;
using src.Model.ModelFramework.ActionFramework.ActionTurnModels;

namespace src.Model.ModelFramework.ActionFramework.ActionModels
{
    public class ProjectileModel : ActionModel
    {
        public readonly IEnumerable<ProjectileTurnModel> ProjectileTurnModels;

        public ProjectileModel(string actionName, ActionTime actionTime, int actionLevel, string description,
            string roomModel, IEnumerable<ProjectileTurnModel> projectileTurnModels, ActionPriority priority) : base(
            actionName, actionTime, actionLevel, description, roomModel, priority)
        {
            ProjectileTurnModels = projectileTurnModels;
        }
    }
}