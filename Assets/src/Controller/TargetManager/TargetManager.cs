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
        private readonly List<ITargetable> targetList = new List<ITargetable>();
        
        public TargetManager()
        {

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

        public List<ITargetable> getEnemyByID(Guid id)
        {
            var rList = new List<ITargetable>();

            foreach (var t in targetList)
                if (t.GetSelfId() == id)
                    rList.Add(t);
            return rList;
        }

        public List<ITargetable> getEnemies(Guid id)
        {
            var rList = new List<ITargetable>();

            foreach (var t in targetList)
                if (t.GetTeamId() != id)
                    rList.Add(t);
            return rList;
        }

        public List<ITargetable> getAlliedByID(Guid id)
        {
            var rList = new List<ITargetable>();

            foreach (var t in targetList)
                if (t.GetSelfId() != id)
                    rList.Add(t);
            return rList;
        }
    }
}
