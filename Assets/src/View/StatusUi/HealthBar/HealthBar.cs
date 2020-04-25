using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace src.View.StatusUi.HealthBar
{
    public class HealthBar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public int _healthMax;
        public int _health;

        private float _currentAnimationHealth;

        private RectTransform _healthBarTransform;

        private int _totalHealthWidth;
        private int _healthWidth;
        private int _totalCurrentHealthWidth;

        private GameObject _canvasTipText;
        private CanvasTipText.CanvasTipText _tipText;

        private int _penultimateScreenWidth;
        private int _lastScreenWidth;

        private bool _healthTip;

        private void Start()
        {
            _healthMax = 50;
            _health = _healthMax;
            _currentAnimationHealth = _health;

            _healthBarTransform = GetComponent<RectTransform>();

            _canvasTipText = GameObject.Find("CanvasTipText");
            _tipText = _canvasTipText.GetComponent<CanvasTipText.CanvasTipText>();
        }

        private void Update()
        {
            _penultimateScreenWidth = _lastScreenWidth;
            _lastScreenWidth = Screen.width;

            if (Screen.width == _penultimateScreenWidth)
            {
                //_healthBarTransform.sizeDelta = new Vector2((Screen.width - 105) / (float)_healthMax * _health,
                //    _healthBarTransform.sizeDelta.y);
                
                if (Math.Abs(_health - _currentAnimationHealth) > 0.01)
                {
                    if (_health < _currentAnimationHealth)
                    {
                        _currentAnimationHealth -= 5 * Time.deltaTime;
                        if (_currentAnimationHealth < _health)
                        {
                            _currentAnimationHealth = _health;
                        }
                    }
                    else if (_health > _currentAnimationHealth)
                    {
                        _currentAnimationHealth += 5 * Time.deltaTime;
                        if (_currentAnimationHealth > _health)
                        {
                            _currentAnimationHealth = _health;
                        }
                    }
                }
                else
                {
                    _currentAnimationHealth = _health;
                }

                _healthBarTransform.sizeDelta = new Vector2((Screen.width - 105) / (float)_healthMax * _currentAnimationHealth,
                    _healthBarTransform.sizeDelta.y);
            }

            if (_healthTip)
            {
                _tipText.SetTipText("Current Health: " + _health + " out of " + _healthMax);
            }
        }

        public void StateChanged(int newHealth, int newMaxHealth)
        {
            if (newMaxHealth < 0)
            {
                _healthMax = 0;
            }
            else
            {
                _healthMax = newMaxHealth;
            }

            if (newHealth > newMaxHealth)
            {
                _health = newMaxHealth;
            }
            else if (newHealth < 0)
            {
                _health = 0;
            }
            else
            {
                _health = newHealth;
            }
        }

        public void ShowHealthTip()
        {
            _healthTip = true;
        }

        public void HideHealthTip()
        {
            _healthTip = false;
            _tipText.SetTipText("");
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            ShowHealthTip();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            HideHealthTip();
        }
    }
}
