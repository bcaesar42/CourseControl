using System;
using src.Controller.ActionModelManager;
using UnityEngine;

namespace src
{
    public class ActionManagerTester : MonoBehaviour
    {
        private void Start()
        {
            var inst = ActionManager.instance;
            var model1 = inst.ActionModels[0];
            Debug.Log(model1.Description);
            var turnModel = model1.ActionTurnModels[0];
            var dps = turnModel.DamagePerShot;
            Debug.Log(dps);
        }

        private void Update()
        {
            
        }
    }
}
