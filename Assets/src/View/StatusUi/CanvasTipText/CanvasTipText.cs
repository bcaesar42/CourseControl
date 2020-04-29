using System;
using UnityEngine;
using UnityEngine.UI;

namespace src.View.StatusUi.CanvasTipText
{
    public class CanvasTipText : MonoBehaviour
    {
        private RectTransform _tipTextTransform;
        private Text _tipText;
        
        private int _penultimateScreenWidth;
        private int _lastScreenWidth;

        private void Start()
        {
            _tipTextTransform = GetComponent<RectTransform>();
            _tipText = GetComponent<Text>();

        }

        private void Update()
        {
            _penultimateScreenWidth = _lastScreenWidth;
            _lastScreenWidth = Screen.width;
            
            if (Screen.width == _penultimateScreenWidth)
            {
                _tipTextTransform.sizeDelta = new Vector2(Screen.width - 95, _tipTextTransform.sizeDelta.y);
            }
        }

        public void SetTipText(string tipText)
        {
            _tipText.text = tipText;
        }
    }
}
