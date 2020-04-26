using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using src.Model.ModelFramework.ActionFramework;

namespace src.Controller.ActionKindManager
{
    public class NewActionManager
    {
        public static readonly NewActionManager Instance = new NewActionManager();

        protected NewActionManager()
        {
            using (StreamReader r = new StreamReader("ActionConfiguration.json"))
            {
                string json = r.ReadToEnd();
                List<ActionModel> items = JsonConvert.DeserializeObject<List<ActionModel>>(json);
            }
        }
    }
}
