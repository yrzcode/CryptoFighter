using CryptoFighter.n_Status;
using UnityEngine;

namespace CryptoFighter.n_Movement
{
    public class S_SimpleMoveToPos : MonoBehaviour
    {
        [SerializeField] private bool _move;
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private Vector3 _endPos;
        [SerializeField] private string _targetTag;
        [SerializeField] private MoveSpeed _moveSpeed;
        [SerializeField] private float _moveSpeedOffset;
        

        private Transform _endTransform;

        private void Start()
        {
            if (_targetTag != "") _endTransform = GameObject.FindGameObjectWithTag(_targetTag).transform;
        }

        private void Update()
        {
            if (_move)
            {
                MoveToPosVariety();
            }
        }


        private void MoveToPosVariety()
        {
            if (_endTransform != null)
            {
                var endPos = _endTransform.position;
                var direction = endPos - _gameObject.transform.position;
                _gameObject.transform.Translate(Vector3.ClampMagnitude(direction, 1f) * _moveSpeed.CurrentMoveSpeed * Time.deltaTime);
            }
        }
        
    }
}