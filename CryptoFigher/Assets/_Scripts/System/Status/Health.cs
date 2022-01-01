using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


namespace CryptoFighter.n_Status
{
    public class Health : MonoBehaviour, IChangeableStatus, IOnChangeAction
    {

        [SerializeField] int maxHealth;
        [SerializeField] int currentHealth;

        public event Action OnIncrease;
        public event Action DeIncrease;

        public int MaxHealth { get => maxHealth; private set => maxHealth = value; }
        public int CurrentHealth
        {
            get => currentHealth;
            set
            {
                if (value > MaxHealth)
                {
                    value = MaxHealth;
                    return;
                }
                else if (value < 0)
                {
                    value = 0;
                    return;
                }

                currentHealth = value;
            }
        }


        public void DecreaseCurrentHealth(int amount)
        {

            currentHealth -= amount;

            if (currentHealth < 0)
            {
                currentHealth = 0;
            }

        }

        public void Increase(float amount)
        {
            CurrentHealth += (int)amount;
            OnIncrease?.Invoke();

        }

        public void Decrease(float amount)
        {
            CurrentHealth -= (int)amount;
            DeIncrease?.Invoke();
        }
    }
}







