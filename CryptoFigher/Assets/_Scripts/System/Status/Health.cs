using System;
using UnityEngine;
namespace CryptoFighter.n_Status
{
    public class Health : MonoBehaviour, IChangeableStatus
    {

        [SerializeField] int _maxHealth;
        [SerializeField] int _currentHealth;

        public event Action OnIncrease;
        public event Action DeIncrease;

        public int MaxHealth { get => _maxHealth; private set => _maxHealth = value; }
        public int CurrentHealth
        {
            get => _currentHealth;
            private set => _currentHealth = Mathf.Clamp(value, 0, _maxHealth);
        }

        public void Increase(float amount){}
        public void Decrease(float amount){}
   
        
        public void Increase(int amount)
        {
            CurrentHealth += amount;
            OnIncrease?.Invoke();
        }

        public void Decrease(int amount)
        {
            CurrentHealth -= amount;
            DeIncrease?.Invoke();
        }
    }
}







