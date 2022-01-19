using System;
using CryptoFighter.n_Status;
using UnityEngine;

namespace CryptoFighter.n_Restriction
{
    public class S_JumpDisableSys : MonoBehaviour
    {
        [SerializeField] JumpForce _jumpForce;
        private void OnEnable() => _jumpForce.SetCurrentForceTo(e_JumpForce.noJumpForce);
        private void Update() => _jumpForce.SetCurrentForceTo(e_JumpForce.noJumpForce);
        private void OnDisable() => _jumpForce.SetCurrentForceTo(e_JumpForce.normalJumpForce);
    }
}
 
