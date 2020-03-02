using src.Model.ModelFramework.Targetables;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace src.Controller.TargetManager
{
    public class TargetManager
    {
        List<ITargetable> targetList = new List<ITargetable>();
        GameObject scene;

        public TargetManager() //Scene should be a game object that all other game objects in the scene are under.
        {

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
            foreach(ITargetable t in targetList)
            {
                if(t.GetSelfId() == id)
                {
                    targetList.Remove(t);
                }
            }
        }

        public void AddTarget(ITargetable target)
        {
            targetList.Add(target);
        }

        public List<ITargetable> getEnemyID(Guid id)
        {
            List<ITargetable> rList = new List<ITargetable>();

            foreach(ITargetable t in targetList)
            {
                if(t.GetSelfId() == id)
                {
                    rList.Add(t);
                }
            }
            return rList;
        }

        public List<ITargetable> getAlliedID(Guid id)
        {
            List<ITargetable> rList = new List<ITargetable>();

            foreach (ITargetable t in targetList)
            {
                if (t.GetSelfId() != id)
                {
                    rList.Add(t);
                }
            }
            return rList;
        }
    }
}