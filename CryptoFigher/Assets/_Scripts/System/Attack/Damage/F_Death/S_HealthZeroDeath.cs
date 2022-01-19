using System.Collections.Generic;
using CryptoFighter.n_Status;
using UnityEngine;

namespace CryptoFighter.n_Attack
{
    public class S_HealthZeroDeath : MonoBehaviour,I_Killable
    {
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private Health _health;
        [SerializeField] private GameObject _deathEffectPrefab;
        [SerializeField] private List<GameObject> _dropItemList;

        private void Update()
        {
            if (_health.CurrentHealth == 0) Kill();
        }

        public void Kill()
        { 
            Functions.PlayEffect(_deathEffectPrefab, _gameObject.transform.position, 1f);
            
            foreach (var dropList in _dropItemList)
            {
                Functions.PlayEffect(dropList, _gameObject.transform.position, 1f);
            }
            
            Destroy(_gameObject, 0.1f);
        }
    }
}