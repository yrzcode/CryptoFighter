using UnityEngine;
using Random = UnityEngine.Random;

namespace CryptoFighter.n_Status
{
    public class MoveSpeed : MonoBehaviour, IChangeableStatus
    {
        [SerializeField] float _currentMoveSpeed;
        [SerializeField] private bool _fromRandomRange;
        [SerializeField] private float _randomRange;

        public float CurrentMoveSpeed
        {
            get => _currentMoveSpeed;
            set => _currentMoveSpeed = Mathf.Clamp(value, 0, float.MaxValue);
        }

        private void Start()
        {
            if (_fromRandomRange) CurrentMoveSpeed += Random.Range(-_randomRange, _randomRange);
        }

        private void OnValidate() => CurrentMoveSpeed = _currentMoveSpeed;
        
        public void Increase(float amount) => CurrentMoveSpeed += amount;
        public void Decrease(float amount) => CurrentMoveSpeed -= amount;
    }
}

