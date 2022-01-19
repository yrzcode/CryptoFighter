using System.Collections.Generic;
using UnityEngine;

namespace CryptoFighter.n_Scale
{
    public class S_TouchChangeFlip : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private List<string> _tags;

        private void OnTriggerStay2D(Collider2D other)
        {
            foreach (var item in _tags)
            {
                if (other.gameObject.CompareTag(item))
                {
                    Functions.FlipGameObject(_gameObject);
                }
            }
            
        }
    }
}