using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using src.Model.ModelFramework.Actionables;
using src.Model.ModelFramework.Actionables.ActionKinds;

namespace src.Model.ModelConcrete.ActionKindManager
{
    public static class ActionKindManager
    {
        private static readonly Collection<ModelFramework.Actionables.ActionKind> ActionKinds = new Collection<ModelFramework.Actionables.ActionKind>();

        public static void InitializeManager()
        {
            String json = File.ReadAllText("ActionConfiguration.json");
            JObject conf = JObject.Parse(json);
            if (conf["action"].Type == JTokenType.Array)
            {
                foreach (var jToken in conf["action"].Children())
                {
                    var name = jToken["name"].Value<string>();
                    var description = jToken["description"].Value<string>();
                    var level = jToken["level"].Value<int>();
                    var roomModel = jToken["roomModel"].Value<string>();
                    var actionTimeJson = jToken["actionTime"];
                    var activation = actionTimeJson["activation"].Value<int>();
                    var completion = actionTimeJson["completion"].Value<int>();
                    var cooldown = actionTimeJson["cooldown"].Value<int>();
                    var actionTime = new ActionTime(activation, completion, cooldown);
                    var completionTimeValues = jToken["completionTimeValues"];
                    var nonRoundDependantValues = jToken["nonRoundDependantValues"];
                    if (jToken["type"].Type == JTokenType.String)
                    {
                        string type = jToken["type"].Value<string>();
                        switch (type)
                        {
                            case "weapon":
                                
                                var w = new WeaponKind(name, actionTime, level, description, roomModel);
                                break;
                            case "drone:":
                                break;
                            case "sensor":
                                break;
                            case "scavenge":
                                break;
                            case "navigation":
                                break;
                            case "replicationCenter":
                                break;
                            case "sensors":
                                break;
                            case "research":
                                break;
                            case "shield":
                                break;
                            case "heal":
                                break;
                        }
                    }
                }
            }
        }

        public static IEnumerable<T> GetKind<T>() where T : ModelFramework.Actionables.ActionKind
        {
            var actionKinds = ActionKinds.Where(kind => kind.GetType() == typeof(T));
            var enumerable = actionKinds as ModelFramework.Actionables.ActionKind[] ?? actionKinds.ToArray();
            return enumerable.Cast<T>();
        }

        public static IEnumerable<T> GetUpgrades<T>(T actionKind) where T : ModelFramework.Actionables.ActionKind
        {
            var upgrades = ActionKinds.Where(kind =>
                kind.ActionName == actionKind.ActionName && kind.ActionLevel == actionKind.ActionLevel + 1);
            return upgrades.Cast<T>();
        }

        public static IEnumerable<> Get
    }
}