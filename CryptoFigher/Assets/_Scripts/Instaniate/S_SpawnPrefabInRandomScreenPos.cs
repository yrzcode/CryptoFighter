using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace CryptoFighter.n_Instaniate
{
    public class S_SpawnPrefabInRandomScreenPos : MonoBehaviour
    {
        [SerializeField] GameObject _prefab;
        [SerializeField] float _spawnInterval;
        [SerializeField] private bool _spawn;
        [SerializeField][CanBeNull] GameObject _spawnEffect;
        
        [SerializeField] private Vector2 _boundaryMin;
        [SerializeField] private Vector2 _boundaryMax;
        
        private void Update()
        {
            if (_spawn)
            {
                StartCoroutine(Co_SpawnInRandomScreenPos());
            }
            _spawn = false;
        }

        private IEnumerator Co_SpawnInRandomScreenPos()
        {
            while (true)
            {
                var spawnPos = Functions.GetRandPosInScreen(_boundaryMin, _boundaryMax);
                if (_spawnEffect != null) Functions.PlayEffect(_spawnEffect, spawnPos, 2f);
                yield return Functions.GetWait(0.5f);
                Instantiate(_prefab, spawnPos, _prefab.transform.rotation);
                yield return Functions.GetWait(_spawnInterval);
            }
        }
    }
}


