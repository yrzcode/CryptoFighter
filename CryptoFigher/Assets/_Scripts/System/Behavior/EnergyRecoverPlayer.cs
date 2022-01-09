using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CryptoFighter.n_Behavior
{
    public class EnergyRecoverPlayer : EnergyRecover
    {

        private void OnEnable()
        {
            energy.OnDecreseCruurentEnergy += PauseEnergyRecover;

        }

        private void OnDisable()
        {
            energy.OnDecreseCruurentEnergy -= PauseEnergyRecover;
        }

        private void PauseEnergyRecover()
        {
            StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(Co_RecoverEnergy());

        }

    }
}


