using UnityEngine;
using CryptoFighter.n_Status;
using CryptoFighter.n_InputSystem;

namespace CryptoFighter.n_Movement
{
    public class S_InputBaseVelocitySetSystemXY : VelocitySetSystem
    {
        [SerializeField] MoveSpeed _moveSpeed;
        [SerializeField] InputSystemBaseController _input;

        public override void SetVelocity()
        {
            var inputAmountX = _input.GetInputAction().Player.Move.ReadValue<Vector2>().x;
            var inputAmountY = _input.GetInputAction().Player.Move.ReadValue<Vector2>().y;

            var horizontalVelocity = _moveSpeed.CurrentMoveSpeed * inputAmountX;
            var verticalVelocity = _moveSpeed.CurrentMoveSpeed * inputAmountY;

            _rigidbody2D.velocity = new Vector2(horizontalVelocity, verticalVelocity);

        }
    }
}