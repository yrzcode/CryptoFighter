using System.Collections;
using UnityEngine;

namespace CryptoFighter.n_Unit
{
    public class S_AmountIntervalCoSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _spawnAmount;
        [SerializeField] private float _spawnInterval;
        [SerializeField] private bool _isRandPos;
        [SerializeField] private bool _spawn;
        [SerializeField] private bool _canRepeat;
        [SerializeField] private Vector2 _boundaryMin;
        [SerializeField] private Vector2 _boundaryMax;
        
        private bool _hasSpawn;
        private void Update()
        {
            if (!_canRepeat)
            {
                if (_hasSpawn) return;
            }
            
            if (_spawn) StartCoroutine(Co_Spawn());
        }

        private IEnumerator Co_Spawn()
        {
            _hasSpawn = true;
            for (int i = 0; i < _spawnAmount; i++)
            {
                if (_isRandPos) transform.position = Functions.GetRandPosInScreen(_boundaryMin, _boundaryMax);
                Instantiate(_prefab, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(_spawnInterval);
                
            }
        }
    }
}

