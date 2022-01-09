using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

using CryptoFighter.n_UI;
using CryptoFighter.n_Status;


namespace CryptoFighter.n_Attack.n_Shooting
{
    public class ShooterMouse : Shooter
    {
        [SerializeField] Energy energy;
        [SerializeField] int energyConsume;
        [SerializeField] CanvasManager UI;

        [SerializeField] private GameObject projectilePrafab;
        [SerializeField] private GameObject fireEffectPrefab;

        private Animator _animator;
        private PlayerInput _playerInput;
        private PlayerPunk playerPunk;
        private bool isPlayerLaserShooting;
        private Rigidbody2D _rigidbody2D;
        [SerializeField] private int gunBackForce;
        [SerializeField] Vector3 SwapnPosOffSet;
        [SerializeField] private GameObject playerImage;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();

            _playerInput = GetComponent<PlayerInput>();

            playerPunk = FindObjectOfType<PlayerPunk>();

            _rigidbody2D = playerPunk.GetComponent<Rigidbody2D>();

        }


        //handler

        public override void HandleShooting()
        {
            if (energy.CurrentEnergy < energyConsume) return;

            if (playerPunk.IsPlayerTouchingWall()) return;

            HandlePlayerFlipping();


            PlayLaserAttakAnime();

            StartCoroutine(FireLaser());

            energy.Decrease(energyConsume);
            UI.UpdataEnergyBarVaule();

            PlayFireEffect();

            PlayShootSound();

            StartCoroutine(HandlePlayerFlipping());


        }

        private IEnumerator FireLaser()
        {
            GenerateProjectile();
            yield return new WaitForSeconds(0.2f);
            GenerateProjectile();
            yield return new WaitForSeconds(0.2f);
            GenerateProjectile();
            yield break;

        }

        private IEnumerator HandlePlyaerGravity()
        {

            Vector2 direction = Functions.GetMouseWorldPos() - new Vector2(transform.position.x, transform.position.y);
            _rigidbody2D.velocity -= Vector2.ClampMagnitude(direction, 1f) * gunBackForce;

            yield return null;


        }

        private void PlayFireEffect()
        {
            Vector3 offset = new Vector3(0, 0.5f, -1f);

            Instantiate(fireEffectPrefab,
                        transform.position + offset,
                        Quaternion.Euler(180f, 0, 0));
        }

        private void GenerateProjectile()
        {

            float direction = Functions.GetMousePointDirection();


            Instantiate(projectilePrafab,
                        transform.position +
                        new Vector3(SwapnPosOffSet.x * direction,
                                     SwapnPosOffSet.y, SwapnPosOffSet.z)
                        , Quaternion.identity);
        }

        private IEnumerator HandlePlayerFlipping()
        {

            isPlayerLaserShooting = true;

            float clickMousePositionX = GetCurrentMousePosition().x;


            float localScaleX = Mathf.Sign(clickMousePositionX - transform.position.x);


            transform.localScale = new Vector3(localScaleX, 1f, 1f);

            yield return new WaitForSeconds(0.5f);

            isPlayerLaserShooting = false;
        }

        private void PlayLaserAttakAnime()
        {
            _animator.Play("Base Layer.PlayerLaserAttacking");
        }



        //function
        private Vector2 GetCurrentMousePosition()
        {


            Vector2 mousePostion = playerPunk.input.GetInputAction().Player.GetMousePostion.ReadValue<Vector2>();

            return
            Camera.main.ScreenToWorldPoint(mousePostion);
        }



        // getter
        public bool IsPlayerLaserShooting() => isPlayerLaserShooting;



    }
}



