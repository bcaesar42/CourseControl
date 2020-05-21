using System;
using UnityEngine;
using UnityEngine.UI;

namespace src.View.HUD
{
    public class InformationHUD : MonoBehaviour
    {
        private int ShipHealth { get; set; } = 0;
        private int ShipTotal { get; set; } = 50;
        private int ShieldHealth { get; set; } = 0;
        private int ShieldTotal { get; set; } = 50;

        private Text ShipAndShieldHealth;

        private void Start()
        {
            ShipAndShieldHealth = GameObject.Find("ShipAndShieldHealth").GetComponent<Text>();
            // ShipAndShieldHealth.text = "Hull Integrity: 20 / 30\nShield Strength: 10 / 40";

            /*Hull Integrity: 50/50
            Shield Strength: 50/50*/
        }

        private void Update()
        {
            //For testing purposes
            ShipHealth += 1;
            ShieldHealth += 1;

            ShipAndShieldHealth.text =
                $"Hull Integrity: {ShipHealth} / {ShipTotal}\nShield Strength: {ShieldHealth} / {ShieldTotal}";
        }
    }
}
