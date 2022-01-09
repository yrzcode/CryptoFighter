using System.Collections;
using System.Collections.Generic;
using System;


using UnityEngine;
using UnityEngine.UI;
using TMPro;

using CryptoFighter.n_Status;


namespace CryptoFighter.n_UI
{
    public class CanvasManager : MonoBehaviour
    {

        [SerializeField] Health health;
        [SerializeField] Energy energy;

        [SerializeField] Slider healthBar;
        [SerializeField] Slider energyBar;

        [SerializeField] TextMeshProUGUI healthTMPro;


        private void Start()
        {
            healthBar.maxValue = health.MaxHealth;
            healthBar.value = healthBar.maxValue;

            energyBar.maxValue = energy.MaxEnergy;
            energyBar.value = energyBar.maxValue;
        }

        private void Update()
        {
            UpdateHealthSlider();

            UpdataEnergyBarVaule();

            UpdateHealthAmountText();


        }


        public void UpdataEnergyBarVaule()
        {
            energyBar.value = energy.CurrentEnergy;
        }

        private void UpdateHealthAmountText()
        {
            healthTMPro.text = health.CurrentHealth.ToString();
        }

        private void UpdateHealthSlider()
        {
            healthBar.value = health.CurrentHealth;

        }
    }
}



