using System.Collections.Generic;
using UnityEngine;

namespace  CryptoFighter.n_Destroy
{
    public class S_TriggerColliderDestroySys : MonoBehaviour
    {
        
        [SerializeField] bool _useTouchingLayer;
        [SerializeField] private List<string> _layers;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        
        [SerializeField] private bool _compareTag;
        [SerializeField] private List<string> _tags;
        
        [SerializeField] private GameObject _gameObject;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (_compareTag)
            {
                foreach (var item in _tags)
                {
                    if (col != null && col.gameObject.CompareTag(item))
                    {
                        Destroy(_gameObject);
                    }
                }
            }
            else
            {
                Destroy(_gameObject);
            }
        }
        private void OnTriggerStay2D(Collider2D col)
        {
            if (_compareTag)
            {
                foreach (var item in _tags)
                {
                    if (col != null && col.gameObject.CompareTag(item))
                    {
                        Destroy(_gameObject);
                    }
                }
            }
            else
            {
                Destroy(_gameObject);
            }
        }

        private void Update()
        {
            if (!_useTouchingLayer) return;

            foreach (var layer in _layers)
            {
                var isTouchingLayer = _rigidbody2D.IsTouchingLayers(LayerMask.GetMask(layer));
                if (isTouchingLayer)
                    Destroy(_gameObject);
                else
                    return;
            }

        }
    }
}

