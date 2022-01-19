using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CryptoFighter.n_Instaniate
{
    public class S_IntervalSpawnSystem : A_SpawnSystem
    {
        [SerializeField] private bool _shouldSpawn;
        [SerializeField] private bool _spawnAtStart;
        
        public bool ShouldSpawn
        {
            get => _shouldSpawn;
            set => _shouldSpawn = value;
        }

        private void Start()
        {
            if (!_spawnAtStart) return;
            SpawnEachPrefabInList();
        }

        private void Update()
        {
            if (!_shouldSpawn) return;
            _timer += Time.deltaTime;
            SpawnPrefabMatchCondition();
        }

        [Button("SpawnPrefab")]
        public override void SpawnPrefabMatchCondition()
        {
            var spawnInterval = Random.Range(_minSpawnInterval, _maxSpawnInterval);
            if (_timer < spawnInterval) return;
            if (_parent == null) return;

            SpawnEachPrefabInList();
                
            _timer = 0f;
            
        }
        
    }
}

