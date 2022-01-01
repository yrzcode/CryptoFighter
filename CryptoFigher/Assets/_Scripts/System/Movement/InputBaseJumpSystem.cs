using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CryptoFighter.n_InputSystem;

namespace CryptoFighter.n_Movement
{
    public class InputBaseJumpSystem : MonoBehaviour, IVelocityBaseMovementSystem
    {
        [SerializeField] PlayerAction input;
        //[SerializeField] 

        public Vector3 GetVelocity()
        {
            throw new System.NotImplementedException();
        }

    }

}
