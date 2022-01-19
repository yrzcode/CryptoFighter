using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace CryptoFighter.n_Attack
{
    public class S_TouchExplosion : MonoBehaviour
    {
        [SerializeField] private List<string> _tags;
        [SerializeField] private GameObject _gameObject;
        [SerializeField] [CanBeNull] private GameObject _explosionPrefab;

        private int _count;
        [SerializeField] private int _maxTouchTouchCount;

        private int MaxTouchCount
        {
            get => _maxTouchTouchCount;
            set => _maxTouchTouchCount = Mathf.Clamp(value,1 ,int.MaxValue) ;
        }

        private void OnValidate() => MaxTouchCount = _maxTouchTouchCount;

        private void OnTriggerEnter2D(Collider2D other)
        {
            foreach (var item in _tags)
            {
                if (other.gameObject.CompareTag(item))
                {
                    _count++;
                    if (_count < MaxTouchCount) continue;
                    if (_explosionPrefab != null) Functions.PlayEffect(_explosionPrefab, transform.position, 1f);
                    Destroy(_gameObject, 0.1f);
                }
            }
        }
    }

}


