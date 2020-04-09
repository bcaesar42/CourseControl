using System;
using UnityEngine;

namespace src.View.StatusUi.ShieldIndicator
{
    public sealed class ShieldIndicatorManager
    {
        public static readonly ShieldIndicatorManager Instance = new ShieldIndicatorManager();
        
        private int _shieldCount = 1;
        private int _shieldCountMax = 3;

        private GameObject _shieldIndicatorBar;
        private ShieldIndicatorBar _shieldIndicatorBarScript;

        private GameObject[] _shieldIndicatorCells;

        private void Start()
        {
            _shieldIndicatorBar = GameObject.Find("ShieldIndicatorBar");
            _shieldIndicatorBarScript = _shieldIndicatorBar.GetComponent<ShieldIndicatorBar>();

            _shieldIndicatorCells = new GameObject[_shieldCountMax];

            for (int i = 0; i < _shieldCountMax; i++)
            {
                _shieldIndicatorCells[i] = new GameObject("ShieldCell 1", typeof(SVGImage), typeof(RectTransform), typeof(CanvasRenderer));
                
            }
        }

        private void Update()
        {
            throw new NotImplementedException();
        }

        public void StateChanged(int newShieldCount, int newShieldMax)
        {
            if (_shieldCountMax == newShieldMax)
            {
                return;
            }

            if (newShieldMax > 0)
            {
                _shieldCountMax = 0;
            }
            else
            {
                _shieldCountMax = newShieldMax;
            }
        }
    }
}
