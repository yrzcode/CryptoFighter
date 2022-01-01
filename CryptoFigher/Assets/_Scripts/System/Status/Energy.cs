using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CryptoFighter.n_Status
{
    public class Energy : MonoBehaviour, IChangeableStatus
    {

        [SerializeField] int _maxEnergy;
        [SerializeField] int _currentEnergy;


        public event Action OnDecreseCruurentEnergy;

       
        public int CurrentEnergy
        {
            get => _currentEnergy;

            private set
            {
                if (value < 0)
                {
                    _currentEnergy = 0;
                    return;
                }
                else if (value > MaxEnergy)
                {
                    _currentEnergy = MaxEnergy;
                    return;
                }

                _currentEnergy = value;
            }
        }

        public int MaxEnergy { get => _maxEnergy; private set => _maxEnergy = value; }


        public void ResetEnergy()
        {
            CurrentEnergy = MaxEnergy;
        }



        public void Increase(float amount)
        {
            CurrentEnergy += (int)amount;
        }

        public void Decrease(float amount)
        {
            CurrentEnergy -= (int)amount;

            OnDecreseCruurentEnergy?.Invoke();
        }

    }
}

