using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CryptoFighter.n_Status;

namespace CryptoFighter.n_Behavior
{
    public class EnergyRecover : MonoBehaviour
    {

        [SerializeField] protected Energy energy;
        [SerializeField] protected int recoverAmountPerSec;


        [SerializeField] float coolDownTime;


        protected Coroutine _coroutine;

        private void Start()
        {
            _coroutine = StartCoroutine(Co_RecoverEnergy());
        }


        protected IEnumerator Co_RecoverEnergy()
        {

            yield return new WaitForSeconds(coolDownTime);

            while (true)
            {

                energy.Increase(recoverAmountPerSec / 10);

                yield return new WaitForSeconds(0.1f);

            }

        }

    }
}



