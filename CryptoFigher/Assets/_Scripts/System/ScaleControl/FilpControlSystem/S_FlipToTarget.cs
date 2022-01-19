using UnityEngine;

namespace  CryptoFighter.n_Scale
{
    public class S_FlipToTarget : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private GameObject _target;
        [SerializeField] private string _targetTag;
        private bool _hasFlip;

        private void Awake() => _target = GameObject.FindGameObjectWithTag(_targetTag);

        private void Update()
        {
            bool flip = (_target.transform.position.x - _gameObject.transform.position.x) < 0 ;
            if (!_hasFlip)
            {
                if (flip)
                {
                    Functions.FlipGameObject(_gameObject);
                    _hasFlip = true;
                }
            }
            else
            {
                if (!flip)
                {
                    Functions.FlipGameObject(_gameObject);
                    _hasFlip = false;
                }
            }
            
        }
    }
}
