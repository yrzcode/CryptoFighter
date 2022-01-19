using System.Collections.Generic;
using CryptoFighter.n_Status;
using UnityEngine;
using Sirenix.OdinInspector;

namespace CryptoFighter.n_Attack
{
    public class S_TriggerTakeDamage : SerializedMonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private Dictionary<GameObject, int> _damageDic;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_damageDic != null)
                foreach (var dic in _damageDic)
                {
                    if (other.gameObject.CompareTag(dic.Key.tag)) _health.Decrease(dic.Value);
                }
        }
    }
}