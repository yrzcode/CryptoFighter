using UnityEngine;

namespace CryptoFighter.n_Movement
{
    public abstract class VelocitySetSystem : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D _rigidbody2D;
        public abstract void SetVelocity();
    }
}
