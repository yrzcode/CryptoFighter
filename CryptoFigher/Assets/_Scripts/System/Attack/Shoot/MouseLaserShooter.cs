using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CryptoFighter.n_Attack.n_Shooting
{
    public class MouseLaserShooter : MonoBehaviour
    {

        [SerializeField] GameObject shooter;

        [SerializeField] GameObject laserShooter;
        [SerializeField] GameObject laserShooterRotianContainer;


        private bool isShootingLaser;
        [SerializeField] private Animator _animator;

        private void Awake()
        {
            laserShooter.SetActive(false);
        }


        private void Update()
        {

            laserShooter.transform.position = transform.position;

            HandleShootLaser();

            HandleShootLaserAnime();

        }


        private void HandleShootLaserAnime()
        {
            if (isShootingLaser)
            {
                _animator.Play("Base Layer.PunkStandAttack");

            }

        }

        public void HandleShootLaser()
        {

            isShootingLaser = GetComponent<PlayerPunk>().input.GetInputAction().Player.Fire.IsPressed();


            laserShooter.SetActive(isShootingLaser);

            laserShooterRotianContainer.transform.localRotation = Quaternion.Euler(0, 0, transform.position.ToTargetAngle(Functions.GetMouseWorldPos()));

        }


    }


}

 

