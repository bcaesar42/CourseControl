using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using src.View.Rooms;
using UnityEngine;

namespace Assets.src.View.UI
{
    public class AllocationButton : MonoBehaviour
    {
        GameObject slot;
        /*
         * Constructor is passed in slot number and reference to room
         * Find slot object and put in order
         * Add listener
         */

        public AllocationButton(int slotNumber, BaseRoom room)
        {
            //slot = GameObject.Find($"Slot{slotNumber}").AddComponent()
        }
        void Start()
        {
            
        }

        void Update()
        {
            
        }

        void TaskOnClick()
        {

        }
    }
}
