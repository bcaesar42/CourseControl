using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace src.View.StatusUi.ShieldIndicator
{
    public class ShieldIndicatorCell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private ShieldIndicatorManager _parent;
        
        private void Start()
        {
            
        }

        private void Update()
        {
            
        }

        public void SetShieldCellParent(ShieldIndicatorManager parent)
        {
            _parent = parent;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("in enter");
            if (_parent != null)
            {
                Debug.Log("in enter not null");
                _parent.ShowShieldTip();
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_parent != null)
            {
                _parent.HideShieldTip();
            }
        }
    }
}
