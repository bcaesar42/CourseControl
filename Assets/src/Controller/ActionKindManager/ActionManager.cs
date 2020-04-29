using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using src.Model.ModelFramework.ActionFramework;
using src.Model.ModelFramework.ActionFramework.ActionModels;
using src.Model.ModelFramework.ActionFramework.ActionTurnModels;

namespace src.Controller.ActionKindManager
{
    public static class ActionManager
    {
        private static readonly Collection<ActionModel> ActionModels = new Collection<ActionModel>();

        public static void InitializeManager()
        {
            var json = File.ReadAllText("ActionConfiguration.json");
            var conf = JObject.Parse(json);
            if (conf["action"].Type == JTokenType.Array)
                foreach (var jToken in conf["action"].Children())
                {
                    var name = jToken["name"].Value<string>();
                    var description = jToken["description"].Value<string>();
                    var level = jToken["level"].Value<int>();
                    var roomModel = jToken["roomModel"].Value<string>();
                    var priority = jToken["priority"].Value<int>();
                    var actionTimeJson = jToken["actionTime"];
                    var activation = actionTimeJson["activation"].Value<int>();
                    var completion = actionTimeJson["completion"].Value<int>();
                    var cooldown = actionTimeJson["cooldown"].Value<int>();
                    var actionTime = new ActionTime(activation, completion, cooldown);
                    var completionTimeValues = jToken["completionTimeValues"];
                    var nonRoundDependantValues = jToken["nonRoundDependantValues"];
                    if (jToken["type"].Type == JTokenType.String)
                    {
                        var type = jToken["type"].Value<string>();
                        switch (type)
                        {
                            case "weapon":
                                var turnModels = new List<WeaponTurnModel>();
                                foreach (var turnModel in completionTimeValues.Children())
                                {
                                    var roundNumber = turnModel["round"].Value<int>();
                                    var damage = turnModel["damage"].Value<int>();
                                    var shots = turnModel["shots"].Value<int>();
                                    var chanceToHit = turnModel["chanceToHit"].Value<int>();
                                    turnModels.Add(new WeaponTurnModel(roundNumber, damage, shots, chanceToHit));
                                }

                                ActionModels.Add(new WeaponModel(name, actionTime, level, description, roomModel,
                                    turnModels, (ActionPriority) priority));
                                break;
                            case "drone:":
                                var droneTurnModels = new List<DroneTurnModel>();
                                foreach (var turnModel in completionTimeValues.Children())
                                {
                                    var roundNumber = turnModel["round"].Value<int>();
                                    droneTurnModels.Add(new DroneTurnModel(roundNumber));
                                }

                                ActionModels.Add(new DroneModel(name, actionTime, level, description, roomModel,
                                    droneTurnModels, (ActionPriority) priority));
                                break;
                            case "sensor":
                                var sensorTurnModels = new List<SensorTurnModel>();
                                foreach (var turnModel in completionTimeValues.Children())
                                {
                                    var roundNumber = turnModel["round"].Value<int>();
                                    sensorTurnModels.Add(new SensorTurnModel(roundNumber));
                                }

                                ActionModels.Add(new SensorModel(name, actionTime, level, description, roomModel,
                                    sensorTurnModels, (ActionPriority) priority));
                                break;
                            case "scavenge":
                                var scavengeTurnModels = new List<ScavengerTurnModel>();
                                foreach (var turnModel in completionTimeValues.Children())
                                {
                                    var roundNumber = turnModel["round"].Value<int>();
                                    scavengeTurnModels.Add(new ScavengerTurnModel(roundNumber));
                                }

                                ActionModels.Add(new ScavengerModel(name, actionTime, level, description, roomModel,
                                    scavengeTurnModels, (ActionPriority) priority));
                                break;
                            case "navigation":
                                var navigationTurnModels = new List<NavigationTurnModel>();
                                foreach (var turnModel in completionTimeValues.Children())
                                {
                                    var roundNumber = turnModel["round"].Value<int>();
                                    var chanceToDodge = turnModel["chanceToDodge"].Value<int>();
                                    navigationTurnModels.Add(new NavigationTurnModel(chanceToDodge, roundNumber));
                                }

                                ActionModels.Add(new NavigationModel(name, actionTime, level, description, roomModel,
                                    navigationTurnModels, (ActionPriority) priority));
                                break;
                            case "replicationCenter":
                                var replicationTurnModels = new List<ReplicationTurnModel>();
                                foreach (var turnModel in completionTimeValues.Children())
                                {
                                    var roundNumber = turnModel["round"].Value<int>();
                                    replicationTurnModels.Add(new ReplicationTurnModel(roundNumber));
                                }

                                ActionModels.Add(new ReplicationModel(name, actionTime, level, description, roomModel,
                                    replicationTurnModels, (ActionPriority) priority));
                                break;
                            case "sensors":
                                var sensorsTurnModels = new List<SensorTurnModel>();
                                foreach (var turnModel in completionTimeValues.Children())
                                {
                                    var roundNumber = turnModel["round"].Value<int>();
                                    sensorsTurnModels.Add(new SensorTurnModel(roundNumber));
                                }

                                ActionModels.Add(new SensorModel(name, actionTime, level, description, roomModel,
                                    sensorsTurnModels, (ActionPriority) priority));
                                break;
                            case "research":
                                var researchTurnModels = new List<ResearchTurnModel>();
                                foreach (var turnModel in completionTimeValues.Children())
                                {
                                    var roundNumber = turnModel["round"].Value<int>();
                                    researchTurnModels.Add(new ResearchTurnModel(roundNumber));
                                }

                                ActionModels.Add(new ResearchModel(name, actionTime, level, description, roomModel,
                                    researchTurnModels, (ActionPriority) priority));
                                break;
                            case "shield":
                                var shieldTurnModels = new List<ShieldTurnModel>();
                                foreach (var turnModel in completionTimeValues.Children())
                                {
                                    var roundNumber = turnModel["round"].Value<int>();
                                    var tempHp = turnModel["tempHp"].Value<int>();
                                    shieldTurnModels.Add(new ShieldTurnModel(tempHp, roundNumber));
                                }

                                ActionModels.Add(new ShieldModel(name, actionTime, level, description, roomModel,
                                    shieldTurnModels, (ActionPriority) priority));
                                break;
                            case "heal":
                                var healTurnModels = new List<HealTurnModel>();
                                foreach (var turnModel in completionTimeValues.Children())
                                {
                                    var roundNumber = turnModel["round"].Value<int>();
                                    var heal = turnModel["heal"].Value<int>();
                                    healTurnModels.Add(new HealTurnModel(heal, roundNumber));
                                }

                                ActionModels.Add(new HealModel(name, actionTime, level, description, roomModel,
                                    healTurnModels, (ActionPriority) priority));
                                break;
                            case "projectile":
                                var projectileTurnModels = new List<ProjectileTurnModel>();
                                foreach (var turnModel in completionTimeValues.Children())
                                {
                                    var roundNumber = turnModel["round"].Value<int>();
                                    projectileTurnModels.Add(new ProjectileTurnModel(roundNumber));
                                }

                                ActionModels.Add(new ProjectileModel(name, actionTime, level, description, roomModel,
                                    projectileTurnModels, (ActionPriority) priority));
                                break;
                        }
                    }
                }
        }

        public static IEnumerable<T> GetModelKind<T>() where T : ActionModel
        {
            var actionKinds = ActionModels.Where(actionModel => actionModel.GetType() == typeof(T));
            var enumerable = actionKinds as ActionModel[] ?? actionKinds.ToArray();
            return enumerable.Cast<T>();
        }

        public static IEnumerable<T> GetUpgrades<T>(T actionModel) where T : ActionModel
        {
            var upgrades = ActionModels.Where(model =>
                model.ActionName == actionModel.ActionName && model.ActionLevel == actionModel.ActionLevel + 1);
            return upgrades.Cast<T>();
        }

        public static IEnumerable<T> GetActionModel<T>(string actionName, int upgradeLevel) where T : ActionModel
        {
            var model = ActionModels.Where(actionModel =>
                actionModel.ActionName == actionName && actionModel.ActionLevel == upgradeLevel);
            return model.Cast<T>();
        }
    }
}
