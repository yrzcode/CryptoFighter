using CryptoFighter.n_Status;
using JetBrains.Annotations;
using UnityEngine;

namespace CryptoFighter.n_Attack
{
    public class DamageDealer : MonoBehaviour
    {
        [CanBeNull] protected Health _health;

        [SerializeField] [CanBeNull] private Damage _damage;
        [SerializeField] [CanBeNull] private AudioClip _damageSound;
        [SerializeField] private float _damageSoundVolume;
        [SerializeField] [CanBeNull] private GameObject _hitEffect;
        
        protected bool _dealDamage;
        protected bool _hasDealDamage;


        private void Update()
        {
            if (_dealDamage)
            {
                DealDamage();
                PlayDamageSound();
                PlayDamageEffect();
                _hasDealDamage = true;
            }
        }

        private void DealDamage()
        {
            if (_health != null)
                if (_damage != null)
                    _health.Decrease(_damage.DamageAmount);
        }

        private void PlayDamageSound()
        {
            if (_damageSound != null) Functions.PlaySound(_damageSound, _damageSoundVolume);
        }

        private void PlayDamageEffect()
        {
            if (_hitEffect != null) Functions.PlayEffect(_hitEffect, transform.position, 1f);
        }
        
    }
}


