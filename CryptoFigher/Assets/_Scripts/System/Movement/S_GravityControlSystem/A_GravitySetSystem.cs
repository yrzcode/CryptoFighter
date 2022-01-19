using System;
using UnityEngine;
using System.Collections;

namespace CryptoFighter.n_Movement
{
    public abstract class A_GravitySetSystem : MonoBehaviour
    {

        [SerializeField] protected Rigidbody2D _rigidbody2D;
        protected float _normalGravity;

        private void Awake()
        {
            _normalGravity = _rigidbody2D.gravityScale;
        }

        public abstract void SetGravity();
    }
}

