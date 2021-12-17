using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    [SerializeField]private GameObject proJectilePrafab;


    private void HandleShooting()
    {
        Instantiate(proJectilePrafab,
                    transform.position,
                    Quaternion.Euler(0,0,90f));
    }

    private void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            HandleShooting();
        }
    }
}
