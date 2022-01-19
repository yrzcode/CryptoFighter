
using UnityEngine;
using CryptoFighter.n_InputSystem;
using Unity.Mathematics;
using UnityEngine.InputSystem;
using CryptoFighter.n_Restriction;


namespace CryptoFighter.n_Instaniate
{
    public class S_InputBaseSubSpawnSystem : A_SpawnSystem
    {
        [SerializeField] private bool _useJumpRestriction;
        [SerializeField] private S_InputBaseJumpRestrictionSys _inputBaseJumpRestrictionSys;
        [SerializeField] private InputSystemBaseController _input;
        private bool _hasSubscript;

        private void OnEnable()
        {
            if (_hasSubscript)
            {
                _input.GetInputAction().Player.Jump.performed += SpawnPrefabMatchCondition;
            }
            else
            {
                _input.JumpAction += SpawnPrefabMatchCondition;
                _hasSubscript = true;
            }
        }
        

        private void OnDisable()
        {
            _input.GetInputAction().Player.Jump.performed -= SpawnPrefabMatchCondition;
        }

        private void SpawnPrefabMatchCondition(InputAction.CallbackContext context)
        {
            if (_useJumpRestriction && !_inputBaseJumpRestrictionSys.CanJump) return;
            SpawnEachPrefabInList();
        }
        
        public override void SpawnPrefabMatchCondition()
        {
            if (_useJumpRestriction && !_inputBaseJumpRestrictionSys.CanJump) return;
            SpawnEachPrefabInList();
        }
    }
    
}

