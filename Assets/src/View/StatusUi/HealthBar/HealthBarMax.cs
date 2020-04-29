using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace src.View.StatusUi.HealthBar
{
    public class HealthBarMax : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private GameObject _healthBar;

        private RectTransform _healthBarMaxTransform;
        private HealthBar _healthBarScript;

        private int _penultimateScreenWidth;
        private int _lastScreenWidth;

        private void Start()
        {
            _healthBar = GameObject.Find("HealthBar");
            _healthBarMaxTransform = GetComponent<RectTransform>();
            _healthBarScript = _healthBar.GetComponent<HealthBar>();
        }

        private void Update()
        {
            _penultimateScreenWidth = _lastScreenWidth;
            _lastScreenWidth = Screen.width;

            if (Screen.width == _penultimateScreenWidth)
            {
                _healthBarMaxTransform.sizeDelta = new Vector2(Screen.width - 95,
                    _healthBarMaxTransform.sizeDelta.y);
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _healthBarScript.ShowHealthTip();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _healthBarScript.HideHealthTip();
        }
    }
}
