using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace src.Model.ModelConcrete.UpgradeManager
{
    public static class UpgradeManager
    {
        public static void InitializeManager()
        {
            String json = File.ReadAllText("ActionConfiguration.json");
            JObject conf = JObject.Parse(json);
        }
    }
}