using UnityEngine;
using CryptoFighter.n_Status;

namespace CryptoFighter.Movement
{
    public class S_SimpleMoveHorizontalRandom : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private MoveSpeed _moveSpeed;
        
        private void Update()
        {
            var _velocityX = Mathf.Sin(_transform.localScale.x) * _moveSpeed.CurrentMoveSpeed + Time.deltaTime;
            _rigidbody2D.velocity = new Vector2(_velocityX, _rigidbody2D.velocity.y);
        }
    }
}