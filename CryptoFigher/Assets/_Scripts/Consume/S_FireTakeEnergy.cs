using CryptoFighter.n_Status;
using UnityEngine;

namespace CryptoFighter.n_Consume
{
    public class S_FireTakeEnergy : MonoBehaviour
    {
        private bool _isFiring;
        [SerializeField] private float _consumeSpeed;
        [SerializeField] private Energy _energy;

        [SerializeField]
        private FireMode _fireMode;
        enum FireMode
        {
            Normal,
            Special
        }

        private void Update()
        {

            switch (_fireMode)
            {
                case FireMode.Normal:
                    _isFiring = Functions.InputController.GetInputAction().Player.Fire.IsPressed();
                    break;
                case FireMode.Special:
                    _isFiring = Functions.InputController.GetInputAction().Player.BigAttack.IsPressed();
                    break;
            }
            
            if (_isFiring)
            {
                var consumeAmount = _consumeSpeed * Time.deltaTime;
                _energy.Decrease(consumeAmount);
            }
        }
    }
}