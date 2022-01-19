using UnityEngine;

namespace CryptoFighter.n_Movement
{
    public class S_SimpleVelocitySetSystemXY : VelocitySetSystem
    {
        [SerializeField] private Vector3 _velocity;
        public override void SetVelocity()
        {
            _rigidbody2D.velocity = _velocity;
        }
    }
}