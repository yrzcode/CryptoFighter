using System.Collections.Generic;
using CryptoFighter.n_Status;
using UnityEngine;

namespace CryptoFighter.n_Attack
{
    public class TriggerStayDamageDealer : DamageDealer
    {
        [SerializeField] private List<string> _triggerList;
        [SerializeField] private Mode _damageMode;

        private enum Mode {JustOneTime, OnGoingDamage}

        private void OnTriggerStay2D(Collider2D other)
        {
            switch (_damageMode)
            {
                case Mode.JustOneTime:
                    if (_hasDealDamage) return;
                    break;
                case Mode.OnGoingDamage:
                    break;
            }
            
            foreach (var target in _triggerList)
            {
                var isTarget = other.gameObject.CompareTag(target);
                
                if (!isTarget) return;
                
                _health = other.gameObject.GetComponent<Health>();
                _dealDamage = true;
            }
            
        }
    }
}