using System.Collections.Generic;
using UnityEngine;

namespace CryptoFighter.n_Instaniate
{
    public class S_TriggerEnterSpawnEffect : MonoBehaviour
    {
        [SerializeField] private GameObject _effectPrefab;
        [SerializeField] private List<GameObject> _triggerObjects;
        [SerializeField] private float _duration;

        private void OnTriggerEnter2D(Collider2D other)
        {
            foreach (var triggerObject in _triggerObjects)
            {
                if (other.gameObject.CompareTag(triggerObject.tag))
                {
                    Functions.PlayEffect(_effectPrefab,transform.position,_duration);
                }
            }
        }
    }
}