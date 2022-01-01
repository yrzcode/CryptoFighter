using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CryptoFighter.n_Movement;


namespace CryptoFighter.n_Unit
{

    public class MovementSystemManager : MonoBehaviour
    {

        [SerializeField] Rigidbody2D _rigidbody2D;
        List<IVelocityBaseMovementSystem> _movementSystems = new List<IVelocityBaseMovementSystem>();


        private void Awake()
        {
            IVelocityBaseMovementSystem[] movementSystems = GetComponents<IVelocityBaseMovementSystem>();
            _movementSystems.AddRange(movementSystems);
        }


        private void Update()
        {
            UpdateVeloctiy();
        }

        private void UpdateVeloctiy()
        {
            Vector3 velocity = new Vector3();
            foreach (var movementSystem in _movementSystems)
            {
                velocity += movementSystem.GetVelocity();
            }
            _rigidbody2D.velocity = velocity;
        }
    }
}
