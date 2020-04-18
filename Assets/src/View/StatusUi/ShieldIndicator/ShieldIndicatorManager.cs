using System;
using System.Linq;
using System.Threading;
using UnityEngine;
using Timer = System.Timers.Timer;

namespace src.View.StatusUi.ShieldIndicator
{
    public sealed class ShieldIndicatorManager : MonoBehaviour
    {
        private GameObject shieldPrefab;
        private GameObject canvas;
        private Transform canvasTransform;

        private int _shieldCount;
        private int _shieldCountMax;
        public int _newShieldCount;
        public int _newShieldCountMax;

        private GameObject[] _shieldIndicatorCells;
        private RectTransform[] _shieldIndicatorCellTransforms;
        private SVGImage[] _shieldIndicatorCellSvgImages;

        private void Start()
        {
            _shieldCountMax = _newShieldCountMax;
            _shieldCount = _newShieldCount;

            shieldPrefab = Resources.Load<GameObject>("prefabs/StatusUi/ShieldCell");
            canvas = GameObject.Find("Canvas");
            canvasTransform = canvas.GetComponent<Transform>();

            _shieldIndicatorCells = new GameObject[_shieldCountMax];
            _shieldIndicatorCellTransforms = new RectTransform[_shieldCountMax];
            _shieldIndicatorCellSvgImages = new SVGImage[_shieldCountMax];

            for (int i = 0; i < _shieldCountMax; i++)
            {
                _shieldIndicatorCells[i] = Instantiate(shieldPrefab, canvasTransform, false);
                _shieldIndicatorCellTransforms[i] = _shieldIndicatorCells[i].GetComponent<RectTransform>();
                _shieldIndicatorCellSvgImages[i] = _shieldIndicatorCells[i].GetComponent<SVGImage>();

                _shieldIndicatorCellTransforms[i].anchoredPosition =
                    new Vector2(_shieldIndicatorCellTransforms[i].anchoredPosition.x, -15 - (65 * i));
            }

            for (int i = 0; i < _newShieldCountMax; i++)
            {
                if (i < _newShieldCount)
                {
                    _shieldIndicatorCellSvgImages[i].color = Color.cyan;
                }
                else
                {
                    _shieldIndicatorCellSvgImages[i].color = Color.red;
                }
            }
        }

        private void Update()
        {
            if (_newShieldCountMax > _shieldCountMax)
            {
                for (int i = _shieldCountMax; i < _newShieldCountMax; i++)
                {
                    GameObject cell = Instantiate(shieldPrefab, canvasTransform, false);
                    RectTransform addedTransform = cell.GetComponent<RectTransform>();
                    SVGImage image = cell.GetComponent<SVGImage>();

                    _shieldIndicatorCells = _shieldIndicatorCells.Append(cell).ToArray();
                    _shieldIndicatorCellTransforms = _shieldIndicatorCellTransforms.Append(addedTransform).ToArray();
                    _shieldIndicatorCellSvgImages = _shieldIndicatorCellSvgImages.Append(image).ToArray();
                }

                for (int i = 0; i < _shieldIndicatorCells.Length; i++)
                {
                    _shieldIndicatorCellTransforms[i].anchoredPosition =
                        new Vector2(_shieldIndicatorCellTransforms[i].anchoredPosition.x, -15 - (65 * i));
                }
            }
            else if (_newShieldCountMax < _shieldCountMax)
            {
                if (_newShieldCountMax < 0)
                {
                    _newShieldCountMax = 0;
                }

                while (_newShieldCountMax < _shieldIndicatorCells.Length)
                {
                    Destroy(_shieldIndicatorCells[_shieldIndicatorCells.Length - 1]);
                    Array.Resize(ref _shieldIndicatorCells, _shieldIndicatorCells.Length - 1);
                }

                while (_newShieldCountMax < _shieldIndicatorCellTransforms.Length)
                {
                    Array.Resize(ref _shieldIndicatorCellTransforms, _shieldIndicatorCellTransforms.Length - 1);
                }

                while (_newShieldCountMax < _shieldIndicatorCellSvgImages.Length)
                {
                    Array.Resize(ref _shieldIndicatorCellSvgImages, _shieldIndicatorCellSvgImages.Length - 1);
                }
            }


            if (_newShieldCount > _newShieldCountMax)
            {
                _newShieldCount = _newShieldCountMax;
            }
            else if (_newShieldCount < 0)
            {
                _newShieldCount = 0;
            }

            if (_newShieldCount != _shieldCount || _newShieldCountMax != _shieldCountMax)
            {
                for (int i = 0; i < _newShieldCountMax; i++)
                {
                    if (i < _newShieldCount)
                    {
                        _shieldIndicatorCellSvgImages[i].color = Color.cyan;
                    }
                    else
                    {
                        _shieldIndicatorCellSvgImages[i].color = Color.red;
                    }
                }
            }

            _shieldCountMax = _newShieldCountMax;
            _shieldCount = _newShieldCount;
        }

        public void StateChanged(int newShieldCount, int newShieldMax)
        {
            if (_newShieldCountMax == newShieldMax)
            {
                return;
            }

            if (newShieldMax < 0)
            {
                _newShieldCountMax = 0;
            }
            else
            {
                _newShieldCountMax = newShieldMax;
            }

            if (newShieldCount < 0)
            {
                _newShieldCount = 0;
            }
            else if (newShieldCount > newShieldMax)
            {
                _newShieldCount = newShieldMax;
            }
            else
            {
                _newShieldCount = newShieldCount;
            }
        }
    }
}
