using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CryptoFighter.n_Movement
{
    public class S_BasicGravitySetSystem : A_GravitySetSystem
{
    
    public override void SetGravity()
    {
        _rigidbody2D.gravityScale = _normalGravity;
    }
}

}
