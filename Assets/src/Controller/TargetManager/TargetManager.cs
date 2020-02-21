using System;
using System.Collections.Generic;
using src.Model.ModelFramework.Targetables;
using UnityEngine;

namespace src.Controller.TargetManager
{
    public class TargetManager
    {
        private GameObject scene;
        private readonly List<ITargetable> targetList = new List<ITargetable>();

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
