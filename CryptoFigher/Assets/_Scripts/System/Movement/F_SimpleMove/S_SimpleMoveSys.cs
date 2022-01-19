using UnityEngine;
using CryptoFighter.n_Status;

namespace System.Movement
{
    public class S_SimpleMoveSys : MonoBehaviour
    {
        [SerializeField] private MoveSpeed _speed;
        [SerializeField] private Vector3 _moveDirection;
        [SerializeField] private bool _useManager;
        [SerializeField] private Transform _object;
        
        public Vector3 MoveDirection
        {
            get => _moveDirection;
            set => _moveDirection = value.normalized;
        }

        private void OnValidate()
        {
            MoveDirection = _moveDirection;
        }

        private void Update()
        {
            if (!_useManager)
            {
                HandleMoveObject();
            }
        }

        private void HandleMoveObject()
        {
            Vector3 moveAmount = _moveDirection * _speed.CurrentMoveSpeed * Time.deltaTime;
            _object.transform.localPosition += moveAmount;
        }
    }
}