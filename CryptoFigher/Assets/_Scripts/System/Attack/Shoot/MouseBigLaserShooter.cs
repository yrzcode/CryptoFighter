using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CryptoFighter.n_Status;


namespace CryptoFighter.n_Attack.n_Shooting
{
    public class MouseBigLaserShooter : MonoBehaviour
    {
        [SerializeField] GameObject bigLaserShooter;
        [SerializeField] GameObject bigLaserShooterRotianContainer;

        [SerializeField] Energy energy;


        [SerializeField] Rigidbody2D playerRb;
        private bool isShootingbigLaser;

        [SerializeField] SpriteRenderer playerSpriteRenderer;
        [SerializeField] GameObject playerTransformEffect;
        [SerializeField] GameObject purpleHole;

        [SerializeField] float gravityRecoverSpeed;
        float timer;
        float coolDownTimer;

        [SerializeField] float MaxDuration;
        [SerializeField] float coolDownTime;
        [SerializeField] int energyConsume;

        private void Awake()
        {
            playerRb = GetComponent<Rigidbody2D>();
            bigLaserShooter.SetActive(false);
            purpleHole.SetActive(false);
            isShootingbigLaser = false;
        }


        private void Update()
        {

            if (energy.CurrentEnergy < energyConsume)
            {
                StopBigLaser();

                return;
            }

            if (timer > MaxDuration)
            {
                StopBigLaser();
                coolDownTimer += Time.deltaTime;

                if (coolDownTimer > coolDownTime)
                {
                    timer = 0;
                    coolDownTimer = 0;
                }
                return;
            }


            bigLaserShooter.transform.position = transform.position;

            HandleShootBigLaser();

            HandleShootBigLaserAnime();

            HandlePlayerSpriteChange();

            HandleEnergyConsume();

            ChangePlayerMovement();



            if (isShootingbigLaser)
            {
                GetComponent<PlayerPunk>().ResetJumpCount();
                timer += Time.deltaTime;
            }
            else
            {
                coolDownTimer += Time.deltaTime;
            }
        }

        private void HandleEnergyConsume()
        {
            if (isShootingbigLaser)
            {
                energy.Decrease(energyConsume);

            }
        }

        private void StopBigLaser()
        {
            playerSpriteRenderer.enabled = true;
            playerTransformEffect.SetActive(false);
            isShootingbigLaser = false;
            bigLaserShooter.SetActive(false);
            playerRb.gravityScale = Functions.GetPlayerNormalGravity();
        }

        private void HandlePlayerSpriteChange()
        {
            playerTransformEffect.SetActive(isShootingbigLaser);
        }

        private void HandleShootBigLaserAnime()
        {

            playerSpriteRenderer.enabled = !isShootingbigLaser;

            if (playerRb.velocity == Vector2.zero)
            {
                purpleHole.SetActive(isShootingbigLaser);

            }
            else
            {
                purpleHole.SetActive(false);
            }

        }

        private void ChangePlayerMovement()
        {

            if (isShootingbigLaser)
            {
                playerRb.velocity -= new Vector2(0, playerRb.velocity.y);

                var playPunk = FindObjectOfType<PlayerPunk>();
                var yMovement = playPunk.PlayerInputValue.y * playPunk.config.GetPlayerMoveSpeed();
                playerRb.velocity = new Vector2(playerRb.velocity.x, yMovement);

                playerRb.gravityScale = 0;
            }
            else
            {
                if (playerRb.gravityScale <= Functions.GetPlayerNormalGravity())
                {
                    playerRb.gravityScale += gravityRecoverSpeed * Time.deltaTime;
                }
                else
                {
                    playerRb.gravityScale = Functions.GetPlayerNormalGravity();
                }
            }
        }


        public void HandleShootBigLaser()
        {
            isShootingbigLaser = GetComponent<PlayerPunk>().input.InputActions.Player.BigAttack.IsPressed();


            bigLaserShooter.SetActive(isShootingbigLaser);


            bigLaserShooterRotianContainer.transform.localRotation = Quaternion.Euler(0, 0, transform.position.ToTargetAngle(Functions.GetMouseWorldPos()));

        }


    }
}


