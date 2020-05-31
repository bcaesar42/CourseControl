using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using src.Model.ModelFramework.ActionFramework;
using src.Model.ModelFramework.TargetableFramework;
using src.Model.ModelFramework.Targetables;
using UnityEngine;

namespace src.Controller.TargetManager
{
    public class TargetManager
    {
        private GameObject scene;
        private readonly List<ITargetable> targetList = new List<ITargetable>();
        
        public TargetManager()
        {
            using (StreamReader r = new StreamReader("Assets/resources/BalanceConfig/ActionModels/ActionModels.json"))
            {
                string json = r.ReadToEnd();
                //ActionModels = JsonConvert.DeserializeObject<List<ActionModel>>(json);
            }
        }

        public void RemoveTarget(Guid id)
        {
            foreach (var t in targetList)
                if (t.GetSelfId() == id)
                    targetList.Remove(t);
        }

        public void AddTarget(ITargetable target)
        {
            targetList.Add(target);
        }

        public List<ITargetable> getEnemyID(Guid id)
        {
            var rList = new List<ITargetable>();

            foreach (var t in targetList)
                if (t.GetSelfId() == id)
                    rList.Add(t);
            return rList;
        }

        public List<ITargetable> getAlliedID(Guid id)
        {
            var rList = new List<ITargetable>();

            foreach (var t in targetList)
                if (t.GetSelfId() != id)
                    rList.Add(t);
            return rList;
        }
    }
}
