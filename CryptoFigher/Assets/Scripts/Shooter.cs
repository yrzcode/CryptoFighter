using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Shooter : MonoBehaviour
{
    [SerializeField]private AudioClip shootSound;
    [SerializeField]private float shootSoundVolume;

    protected abstract void HandleShooting();


    private void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            HandleShooting();

        }
    }

    protected void PlayShootSound()
    {
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position,shootSoundVolume);
    }
}
