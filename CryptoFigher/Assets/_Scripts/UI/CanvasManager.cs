using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CryptoFighter.n_Status;

namespace CryptoFighter.n_UI
{
    public class CanvasManager : MonoBehaviour
    {

        [SerializeField] Health _health;
        [SerializeField] Energy _energy;

        [SerializeField] Slider _healthBar;
        [SerializeField] Slider _energyBar;

        [SerializeField] TextMeshProUGUI _healthTMPro;
        [SerializeField] TextMeshProUGUI _energyTMPro;


        private void Start()
        {
            _healthBar.maxValue = _health.MaxHealth;
            _healthBar.value = _healthBar.maxValue;

            _energyBar.maxValue = _energy.MaxEnergy;
            _energyBar.value = _energyBar.maxValue;
        }

        private void Update()
        {
            UpdateHealthSlider();
            UpdateEnergyBarValue();
            
            UpdateHealthAmountText();
            UpdateEnergyAmountText();
        }

        private void UpdateHealthAmountText() => _healthTMPro.text = _health.CurrentHealth.ToString();
        private void UpdateEnergyAmountText() => _energyTMPro.text = _energy.CurrentEnergy.ToString();


        private void UpdateHealthSlider() => _healthBar.value = _health.CurrentHealth;
        public void UpdateEnergyBarValue() => _energyBar.value = _energy.CurrentEnergy;
    }
}



