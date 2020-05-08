using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using src.Model.ModelFramework.ActionFramework;
using UnityEngine;

namespace src.Controller.ActionModelManager
{
    public class ActionManager
    {
        public static readonly ActionManager instance = new ActionManager();
        
        public ActionModel[] ActionModels;

        private ActionManager()
        {
            using (StreamReader r = new StreamReader("Assets/resources/BalanceConfig/ActionModels/ActionModels.json"))
            {
                string json = r.ReadToEnd();
                ActionModels = JsonConvert.DeserializeObject<ActionModel[]>(json);
            }
        }

        public IEnumerable<T> GetActionModels<T>() where T : ActionModel
        {
            var actionKinds = ActionModels.Where(actionModel => actionModel.GetType() == typeof(T));
            var enumerable = actionKinds as ActionModel[] ?? actionKinds.ToArray();
            return enumerable.Cast<T>();
        }

        public IEnumerable<T> GetUpgrades<T>(T actionModel) where T : ActionModel
        {
            var upgrades = ActionModels.Where(model =>
                model.ActionName == actionModel.ActionName && model.ActionLevel == actionModel.ActionLevel + 1);
            return upgrades.Cast<T>();
        }

        public IEnumerable<T> GetActionModel<T>(string actionName, int upgradeLevel) where T : ActionModel
        {
            var model = ActionModels.Where(actionModel =>
                actionModel.ActionName == actionName && actionModel.ActionLevel == upgradeLevel);
            return model.Cast<T>();
        }
    }
}
