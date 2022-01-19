using System.Collections.Generic;
using CryptoFighter.n_Movement;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CryptoFighter.n_Instaniate
{
    public class S_RoundExplosionSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private List<GameObject>  _tweenCompleteFunctions;
        [SerializeField] private Transform _prefabParent;
        [SerializeField] private int _spawnAmountMin, _spawnAmountMax;
        [SerializeField] private float _blastTime;
        [SerializeField] private float _blastRadius;
        [SerializeField] private float _blastRepeatingInterval;

        enum SpawnMode {Once, Repeat}
        [SerializeField] private SpawnMode _spawnMode;
        
        private int _spawnAmount;

        private void Start()
        {
            switch (_spawnMode)
            {
                case SpawnMode.Once:
                    Invoke(nameof(BlastSpawn),0f);
                    break;
                case SpawnMode.Repeat:
                    InvokeRepeating(nameof(BlastSpawn) ,0f , _blastRepeatingInterval);
                    break;
            }
        }
        [Button]
        private void BlastSpawn()
        {
            _spawnAmount = Random.Range(_spawnAmountMin, _spawnAmountMax + 1);
            var angle = 360 / _spawnAmount;
            for (int i = 0; i < _spawnAmount; i++)
            {
                var angleToTranslate = angle * i;
                
                var item = Instantiate(_prefab, _gameObject.transform.position, _prefab.transform.localRotation, _prefabParent);
                var amountX = _blastRadius * Mathf.Cos(angleToTranslate * Mathf.Deg2Rad);
                var amountY = _blastRadius * Mathf.Sin(angleToTranslate * Mathf.Deg2Rad);
                var offset = new Vector2(amountX, amountY);
                var endPos = item.transform.position + (Vector3)offset;

                item.transform.DOMove(endPos, _blastTime).SetEase(Ease.Linear).OnComplete(() =>
                {
                    var tweenCompleteFunctions = item.GetComponentsInChildren<ITweenCompleteFunction>();
                    foreach (var tweenCompleteFunction in tweenCompleteFunctions)
                    {
                        tweenCompleteFunction.TweenCompleteFunction();
                    }
                });
            }
        }
    }
}