using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Shooter : MonoBehaviour
{

    protected abstract void HandleShooting();


    private void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            HandleShooting();
        }
    }
    
}
