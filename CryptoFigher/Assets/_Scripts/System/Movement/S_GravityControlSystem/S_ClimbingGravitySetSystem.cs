using UnityEngine;
using CryptoFighter.n_Sensor;

namespace CryptoFighter.n_Movement
{
    public class S_ClimbingGravitySetSystem : A_GravitySetSystem
    {
        [SerializeField] protected float _gravity;
        [SerializeField] A_StaySensor _climbingSensor;
        
        public override void SetGravity()
        {
            var shouldSetGravity = _climbingSensor.IsTouchingTarget();
            if (shouldSetGravity)
            {
                _rigidbody2D.gravityScale = _gravity;
            }
        }
        
    }

}

