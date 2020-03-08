using UnityEngine;

namespace src.View.HealthBar
{
    public class HealthBar : MonoBehaviour
    {
        private int _health;
        private GameObject[] _healthCells;
        private Transform _healthBarTransform;

        private void Start()
        {
            _healthCells = new GameObject[50];
            _healthBarTransform = GetComponent<Transform>();

            for (int i = 0; i < 50; i++)
            {
                GameObject cell = new GameObject();
                RectTransform cellTransform = cell.AddComponent<RectTransform>();
                cellTransform.SetParent(_healthBarTransform);
                cellTransform.pivot = new Vector2(0, 1);
                cellTransform.sizeDelta = new Vector2(200, 300);
                cellTransform.localScale = new Vector3(1, 1, 1);

                int xPos = 20;
                cellTransform.position = new Vector3(((xPos + 10) * i), -20, 0);

                _healthCells[i] = cell;
                SVGImage imageComponent = cell.AddComponent<SVGImage>();
                imageComponent.color = Color.green;
                cell.name = "cell" + i;
                cell.SetActive(true);
            }
        }

        private void Update()
        {
        }

        public void StateChanged(int newHealth)
        {
            if (newHealth > 50)
            {
                _health = 50;
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
    }
}
