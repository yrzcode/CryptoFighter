using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CryptoFighter.n_InputSystem;
using CryptoFighter.n_Status;

namespace CryptoFighter.n_Movement
{
    public class InputBaseHorizontalMoveSystem : MonoBehaviour//, IVelocityBaseMovementSystem
    {
        [SerializeField] InputSystemBaseController _input;

        [SerializeField] MoveSpeed _moveSpeed;

        //public Vector3 GetVelocity()
        //{
        //    var horizontalMoveVelocity = _input.Player.Move.ReadValue<Vector2>().x * _moveSpeed.CurrentMoveSpeed;
        //    return new Vector3(horizontalMoveVelocity, 0, 0);
        //}
    }

}
