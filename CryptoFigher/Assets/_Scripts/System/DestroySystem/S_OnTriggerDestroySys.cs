using JetBrains.Annotations;
using UnityEngine;

namespace CryptoFighter.n_Destroy
{
    public class S_OnTriggerDestroySys : MonoBehaviour
    {
        [SerializeField] private GameObject _destroyObject;
        [SerializeField] [CanBeNull] private GameObject _destroyEffect;

        private void OnTriggerEnter2D(Collider2D col)
        {
            PlayDestroyEffect();
            Destroy(_destroyObject,0.01f);
        }
        
        private void OnTriggerStay2D(Collider2D other)
        {
            Destroy(_destroyObject);
        }
        
        private void PlayDestroyEffect()
        {
            if (_destroyEffect != null) Functions.PlayEffect(_destroyEffect, transform.position, 1f);
        }
    }
}