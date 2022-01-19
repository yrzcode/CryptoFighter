using CryptoFighter.n_Status;
using DG.Tweening;
using UnityEngine;

namespace CryptoFighter.n_Movement
{
    public class S_SimpleMoveToTarget : MonoBehaviour,ITweenCompleteFunction
    {
        
        [SerializeField] private GameObject _gameObject, _targetGameObject;
        [SerializeField] private MoveSpeed _moveSpeed;
        [SerializeField] private bool _move;
        [SerializeField] private Vector3 _offset;

        public bool Move
        {
            get => _move;
            set => _move = value;
        }

        private void Awake()
        {
            _targetGameObject = GameObject.FindGameObjectWithTag(_targetGameObject.tag);
        }

        private void Update()
        {
            if (Move) MoveToPos();
        }
        
        private void MoveToPos()
        {
            var moveAmount = Vector3.ClampMagnitude(_targetGameObject.transform.position + _offset - _gameObject.transform.position, _moveSpeed.CurrentMoveSpeed);
            _gameObject.transform.DOMove(moveAmount, Time.deltaTime).SetRelative().SetEase(Ease.Linear);
        }

        public void TweenCompleteFunction() => enabled = true;
    }
}