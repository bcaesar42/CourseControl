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
        
        private TargetManager()
        {
            using (StreamReader r = new StreamReader("Assets/resources/BalanceConfig/ShipModels/ActionModels.json"))
            {
                string json = r.ReadToEnd();
                ActionModels = JsonConvert.DeserializeObject<List<ActionModel>>(json);
            }
        }

        /*
                private void getTargetableChildren(Transform parent) 
                {
                    ITargetable[] t = parent.gameObject.GetComponents<ITargetable>();

                    foreach (ITargetable target in t)
                    {
                        if (target.getSelfId() == id) ;
                        {
                            targetList.Add(target);
                        }
                    }


                    if (parent.childCount > 0)
                    {
                        foreach (Transform child in parent) //Should recusivly call down all children grabbing targetables and adding them.
                        {
                            getTargetableChildren(child);
                        }
                    }
                }

                    private void addTargetableChildren(Guid id, Transform parent)
                {
                    ITargetable[] t = parent.gameObject.GetComponents<ITargetable>();

                    foreach (ITargetable target in t)
                    {
                        if (target.getSelfId() == id) ;
                        {
                            targetList.Add(target);
                        }
                    }

                    if (parent.childCount > 0)
                    {
                        foreach (Transform child in parent) 
                        {
                            addTargetableChildren(id, child);
                        }
                    }
                }
        */
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
