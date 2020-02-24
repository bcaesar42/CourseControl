using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using src.Model.ModelFramework.Actionables;

namespace src.Model.ModelConcrete.ActionUpgradeManager
{
    public static class UpgradeManager
    {
        private static readonly Collection<ActionKind> ActionKinds = new Collection<ActionKind>();

        public static void InitializeManager()
        {
            String json = File.ReadAllText("ActionConfiguration.json");
            JObject conf = JObject.Parse(json);
            if (conf["action"].Type == JTokenType.Array)
            {
                foreach (var jToken in conf["action"].Children())
                {
                    if (jToken["type"].Type == JTokenType.String)
                    {
                        string type = jToken["type"].Value<string>();
                        switch (type)
                        {
                            case "weapon":
                                break;
                        }
                    }
                }
            }
        }

        public static IEnumerable<T> GetKind<T>() where T : ActionKind
        {
            var actionKinds = ActionKinds.Where(kind => kind.GetType() == typeof(T));
            var enumerable = actionKinds as ActionKind[] ?? actionKinds.ToArray();
            return enumerable.Cast<T>();
        }

        public static IEnumerable<T> GetUpgrades<T>(T actionKind) where T : ActionKind
        {
            var upgrades = ActionKinds.Where(kind =>
                kind.ActionKindId == actionKind.ActionKindId && kind.ActionLevel == actionKind.ActionLevel + 1);
            return upgrades.Cast<T>();
        }

        public static IEnumerable<> Get
    }
}