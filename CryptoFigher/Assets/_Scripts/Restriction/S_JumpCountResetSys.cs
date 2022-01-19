using System;
using CryptoFighter.n_Instaniate;
using UnityEngine;

namespace  CryptoFighter.n_Restriction
{
    public class S_JumpCountResetSys : MonoBehaviour
    {
        [SerializeField] private S_InputBaseJumpRestrictionSys _inputBaseJumpRestrictionSys;
        
        private void OnEnable()
        {
             _inputBaseJumpRestrictionSys.JumpCount = 0;
        }
        
    }
}

