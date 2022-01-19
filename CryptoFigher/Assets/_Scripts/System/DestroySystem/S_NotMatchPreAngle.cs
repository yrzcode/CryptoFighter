using System;
using UnityEngine;

namespace CryptoFighter.n_Destroy
{
    public class S_NotMatchPreAngle : MonoBehaviour
    {
        private Vector3 _preRotation;
        [SerializeField] private GameObject _gameObject;
        private void Update()
        {

            if (_gameObject.transform.eulerAngles != _preRotation)
            {
                Destroy(_gameObject);
            }
            
            _preRotation = _gameObject.transform.eulerAngles;
        }
    }
}

