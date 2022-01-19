using System.Collections.Generic;
using UnityEngine;

namespace CryptoFighter.n_Restriction
{
    public class DestroyInWall : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject;
        
        private CircleCollider2D _circleCollider2D;
        private BoxCollider2D _boxCollider2D;
        private CapsuleCollider2D _capsuleCollider2D;
        
        [SerializeField] private List<string> _layerTags;

        private void Awake()
        {
            _circleCollider2D = GetComponent<CircleCollider2D>();
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        }

        private void Update()
        {
            if (_circleCollider2D != null && Functions.IsColliderTouchingLayer(_circleCollider2D, _layerTags)) Destroy(_gameObject);
            if (_boxCollider2D != null && Functions.IsColliderTouchingLayer(_boxCollider2D, _layerTags)) Destroy(_gameObject);
            if (_capsuleCollider2D != null && Functions.IsColliderTouchingLayer(_capsuleCollider2D, _layerTags)) Destroy(_gameObject);
        }
    }
}
