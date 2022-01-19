using System.Collections;
using UnityEngine;
using CryptoFighter.n_Status;

namespace CryptoFighter.n_Consume
{
    public class EnergyRecover : MonoBehaviour
    {

        [SerializeField] protected Energy _energy;
        [SerializeField] protected int _recoverAmountPerSec;
        
        [SerializeField] float _coolDownTime;
        protected Coroutine _coroutine;

        private void Start()
        {
            _coroutine = StartCoroutine(Co_RecoverEnergy());
        }


        protected IEnumerator Co_RecoverEnergy()
        {

            yield return new WaitForSeconds(_coolDownTime);

            while (true)
            {
                _energy.Increase(_recoverAmountPerSec * 0.1f);
                yield return Functions.GetWait(0.1f);
            }

        }

    }
}



