using CryptoFighter.n_Instaniate;
using UnityEngine;

namespace CryptoFighter.n_Movement
{
    public class S_LaserShootingGravitySetSys : A_GravitySetSystem
    {
        [SerializeField] protected float _gravity;
        [SerializeField] S_InputBaseSpawnSystem _inputBaseSpawnSystem;
        
        public override void SetGravity()
        {
            var shouldSetGravity = _inputBaseSpawnSystem.IsSpawn;
            if (shouldSetGravity)
            {
                _rigidbody2D.gravityScale = _gravity;
            }
        }
    }
}