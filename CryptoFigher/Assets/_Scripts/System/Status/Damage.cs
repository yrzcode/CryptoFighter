using UnityEngine;

namespace CryptoFighter.n_Status
{
    public class Damage : MonoBehaviour
    {
        [SerializeField] private int _damageAmount;

        public int DamageAmount
        {
            get => _damageAmount;
            set => _damageAmount = Mathf.Clamp(value, 0,int.MaxValue) ;
        }

        private void OnValidate() => DamageAmount = _damageAmount;
    }
}