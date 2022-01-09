
using System;
using UnityEngine;
using CryptoFighter.n_InputSystem;
using Unity.Mathematics;
using UnityEngine.InputSystem;

namespace CryptoFighter.n_Instaniate
{
    public class S_InputSubSwpanSystem : ASpawnSystem
    {
        [SerializeField] private InputSystemBaseController _input;
        private bool _hasSubscript = false;

        private void OnEnable()
        {
            if (_hasSubscript)
            {
                _input.GetInputAction().Player.Jump.performed -= SpawnPrefab;
            }
            else
            {
                _input.JumpAction += SpawnPrefab;
                _hasSubscript = true;
            }
            
        }

        private void OnDisable()
        {
            _input.GetInputAction().Player.Jump.performed -= SpawnPrefab;
        }

        private void SpawnPrefab(InputAction.CallbackContext context)
        {
            foreach (var prefab in _prefabs)
            {
                Instantiate(prefab, _spawnPos.position, quaternion.identity, _parent);
            }
            
        }
        public override void SpawnPrefab()
        {
            foreach (var prefab in _prefabs)
            {
                Instantiate(prefab, _spawnPos.position, quaternion.identity, _parent);
            }
        }
    }
    
    
    
    
    
    
}

