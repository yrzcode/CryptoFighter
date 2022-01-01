using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CryptoFighter.n_Status
{
    public class JumpFroce : MonoBehaviour
    {
        [SerializeField] float jumpForce;

        public float JumpForce
        {
            get => jumpForce;
            set
            {
                if (jumpForce < 0)
                {
                    jumpForce = 0;
                    return;
                }
                jumpForce = value;
            }
        }
    }

}
