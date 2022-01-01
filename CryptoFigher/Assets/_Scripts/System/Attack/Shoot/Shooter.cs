using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace CryptoFighter.n_Attack.n_Shooting
{
    public abstract class Shooter : MonoBehaviour
    {
        [SerializeField] private AudioClip shootSound;
        [SerializeField] private float shootSoundVolume;

        public abstract void HandleShooting();


        private void OnFire(InputAction.CallbackContext context)
        {
            HandleShooting();
        }

        protected void PlayShootSound()
        {
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
        }
    }
}


