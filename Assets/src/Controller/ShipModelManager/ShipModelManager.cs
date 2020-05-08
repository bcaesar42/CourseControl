using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using src.Model.ModelFramework.ActionFramework;
using src.Model.ModelFramework.ShipFramework;

namespace src.Controller.ShipModelManager
{
    public class ShipModelManager
    {
        public static readonly ShipModelManager instance = new ShipModelManager();
        
        public List<ShipModel> ShipModels;
        
        private ShipModelManager()
        {
            using (StreamReader r = new StreamReader("Assets/resources/BalanceConfig/ShipModels/ShipModels.json"))
            {
                string json = r.ReadToEnd();
                ShipModels = JsonConvert.DeserializeObject<List<ShipModel>>(json);
            }
        }
    }
}
