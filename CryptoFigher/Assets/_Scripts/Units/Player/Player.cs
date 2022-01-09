using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using CryptoFighter.n_InputSystem;
using CryptoFighter.n_Attack.n_Shooting;
using CryptoFighter.n_Status;


namespace CryptoFighter.n_Unit.n_Player
{
    public class Player : MonoBehaviour
    {

        [SerializeField] Health health;

        public static Player punk;

        [SerializeField] public PlayerConfig config;

        public InputSystemBaseController input;

        [SerializeField] ShooterMouse shooterMouse;


        private CircleCollider2D playerCircleCollider2D;
        private BoxCollider2D PlayerBoxCollider2D;
        private Transform playerImageContainer;
        private Vector2 playerInputValue;
        private Rigidbody2D playerRigidbody2D;
        private Animator playerAnimator;


        private float preDirectionX;
        private int jumpCount;


        private bool isPlayerHurt;
        private Vector3 startPositon;
        [SerializeField] private int fallDownDamage;
        private bool isPlayerStartJumpShrinkCoroutine;
        [SerializeField] private float playerJumpShrinkTime;

        private Vector3 playerContainerNormalScaleSize;

        [SerializeField] private float playerJumpShrinkSpeedY;
        [SerializeField] private float playerJumpShrinkRecoverSpeedY;
        [SerializeField] private float playerJumpShrinkLimitY;
        [SerializeField] private float playerJumpShrinkRecoverSpeedX;
        [SerializeField] private float playerJumpShrinkSpeedX;
        [SerializeField] private float playerJumpShrinkLimitX;
        [SerializeField] private Vector3 playerContainerMaxRecoverScaleSize;
        private bool isRecoverSizeReachMaxX;
        private bool isRecoverSizeReachMaxY;
        [SerializeField] private GameObject playerJumpEffectPrefab;
        private bool hasPlayerEndJumpRecoverX;
        private bool hasPlayerEndJumpRecoverY;
        [SerializeField] private GameObject bornEffect;
        [SerializeField] private float BigLaserCancleAnimeTime;

        public Transform PlayerImageContainer { get => playerImageContainer; set => playerImageContainer = value; }
        public Vector2 PlayerInputValue { get => playerInputValue; set => playerInputValue = value; }

        private void Awake()
        {
            punk = this;

            playerImageContainer = transform.GetChild(0);

            playerRigidbody2D = GetComponent<Rigidbody2D>();
            playerAnimator = playerImageContainer.GetComponentInChildren<Animator>();

            playerCircleCollider2D = GetComponent<CircleCollider2D>();
            PlayerBoxCollider2D = GetComponent<BoxCollider2D>();

        }



        private void OnEnable()
        {
            input.GetInputAction().Player.Jump.performed += OnJump;

            input.GetInputAction().Player.Fire.performed += OnShoot;

            input.GetInputAction().Player.Fire.performed += context => shooterMouse.HandleShooting();

            input.GetInputAction().Player.BigAttack.canceled += BigLaserCancleAnime;
        }

        private void OnShoot(InputAction.CallbackContext obj)
        {
            GetComponent<Shooter>().HandleShooting();
        }

        private void BigLaserCancleAnime(InputAction.CallbackContext obj)
        {

            StartCoroutine(BigLaserCancleAnimeCoroutine());

        }

        private IEnumerator BigLaserCancleAnimeCoroutine()
        {

            float timer = 0;

            while (timer < BigLaserCancleAnimeTime)
            {
                if (playerRigidbody2D.velocity.x == 0)
                {
                    playerAnimator.Play("Base Layer.PoseAfterBigLaser");

                }


                timer += Time.deltaTime;
                yield return null;
            }

            yield break;
        }

        private void OnDisable()
        {
            input.GetInputAction().Player.Jump.performed -= OnJump;

            input.GetInputAction().Player.Fire.performed -= OnShoot;

            input.GetInputAction().Player.Fire.performed -= context => shooterMouse.HandleShooting();

            input.GetInputAction().Player.BigAttack.canceled -= BigLaserCancleAnime;

        }


        private void Start()
        {
            preDirectionX = transform.localScale.x;

            startPositon = transform.position;
            playerContainerNormalScaleSize = playerImageContainer.localScale;


            Instantiate(bornEffect, transform.position, Quaternion.Euler(90f, 0, 0));


        }

        private void Update()
        {

            playerInputValue = input.GetInputAction().Player.Move.ReadValue<Vector2>();

            HandlePlayerMovement();


            //player filpping follow mouse
            if (!shooterMouse.IsPlayerLaserShooting())
            {
                HandlePlayerFlipping();
            }
            else
            {
                preDirectionX = transform.localScale.x;
            }

            HandlePlayerJumpingAnime();

            HandlePlayerClambingAnime();


            HandlePlayerJumpShrink();


        }



        private void HandlePlayerJumpShrink()
        {
            if (!isPlayerStartJumpShrinkCoroutine &&
                IsPlayerInNormalSize())
            {
                if (!IsPlayerFeetTouchingLayer(Layer.Ground) &&
                    !IsPlayerFeetTouchingLayer(Layer.Box)) return;

                StartCoroutine(PlayerJumpShrink());

                isPlayerStartJumpShrinkCoroutine = true;
            }

            if (!IsPlayerFeetTouchingLayer(Layer.Ground) &&
                !IsPlayerFeetTouchingLayer(Layer.Box))
            {
                isPlayerStartJumpShrinkCoroutine = false;
            }


        }

        private bool IsPlayerInNormalSize()
        {
            return
            playerImageContainer.localScale == playerContainerNormalScaleSize;
        }

        private IEnumerator PlayerJumpShrink()
        {


            float time = 0;

            // shrink
            while (time < playerJumpShrinkTime)
            {
                playerImageContainer.localScale -= Vector3.up * playerJumpShrinkSpeedY * Time.deltaTime;
                playerImageContainer.localScale += Vector3.right * playerJumpShrinkSpeedX * Time.deltaTime;


                if (playerImageContainer.localScale.y < playerJumpShrinkLimitY)
                {
                    playerImageContainer.localScale = new Vector3(playerImageContainer.localScale.x,
                                                                  playerJumpShrinkLimitY,
                                                                  playerImageContainer.localScale.z);
                }

                if (playerImageContainer.localScale.x < playerJumpShrinkLimitX)
                {
                    playerImageContainer.localScale = new Vector3(playerJumpShrinkLimitX,
                                                                  playerImageContainer.localScale.y,
                                                                  playerImageContainer.localScale.z);
                }

                time += Time.deltaTime;
                yield return null;
            }



            // recover

            StartCoroutine(RecoverShrinkSizeY());
            StartCoroutine(RecoverShrinkSizeX());


        }

        private IEnumerator RecoverShrinkSizeX()
        {

            hasPlayerEndJumpRecoverX = false;

            while (playerImageContainer.localScale.x > playerContainerMaxRecoverScaleSize.x)
            {
                playerImageContainer.localScale -= Vector3.right * playerJumpShrinkRecoverSpeedX * Time.deltaTime;

                isRecoverSizeReachMaxX = playerImageContainer.localScale.x < playerContainerMaxRecoverScaleSize.x;

                yield return null;
            }


            while (!IsRecoverSizeReachMax())
            {
                yield return null;
            }


            while (playerImageContainer.localScale.x < playerContainerNormalScaleSize.x)
            {
                playerImageContainer.localScale += Vector3.right * playerJumpShrinkRecoverSpeedX * Time.deltaTime;


                yield return null;
            }


            playerImageContainer.localScale = new Vector3(playerContainerNormalScaleSize.x,
                                                          playerImageContainer.localScale.y,
                                                          playerImageContainer.localScale.z);


            yield return null;


            hasPlayerEndJumpRecoverX = true;

            yield break;




        }

        private IEnumerator RecoverShrinkSizeY()
        {

            hasPlayerEndJumpRecoverY = false;

            while (playerImageContainer.localScale.y < playerContainerMaxRecoverScaleSize.y)
            {
                playerImageContainer.localScale += Vector3.up * playerJumpShrinkRecoverSpeedY * Time.deltaTime;

                isRecoverSizeReachMaxY = playerImageContainer.localScale.y > playerContainerMaxRecoverScaleSize.y;


                yield return null;
            }

            while (!IsRecoverSizeReachMax())
            {
                yield return null;
            }

            while (playerImageContainer.localScale.y > playerContainerNormalScaleSize.y)
            {
                playerImageContainer.localScale -= Vector3.up * playerJumpShrinkRecoverSpeedY * Time.deltaTime;

                yield return null;

                playerImageContainer.localScale = new Vector3(playerImageContainer.localScale.x,
                                                          playerContainerNormalScaleSize.y,
                                                          playerImageContainer.localScale.z);


            }

            yield return null;


            hasPlayerEndJumpRecoverY = true;

            yield break;
        }

        private bool IsRecoverSizeReachMax()
        {
            return
            isRecoverSizeReachMaxY && isRecoverSizeReachMaxX;
        }





        // handler

        private void HandlePlayerClambingAnime()
        {
            playerAnimator.SetBool("isPlayerClambing", IsPlayerTouchingWall());
        }

        private void HandlePlayerJumpingAnime()
        {
            if (!IsPlayerBodyTouchingLayer(Layer.Ground) &&
                !IsPlayerBodyTouchingLayer(Layer.Box))
            {
                playerAnimator.SetBool("isPlayerJumping", true);
            }
            else
            {
                playerAnimator.SetBool("isPlayerJumping", false);

                ResetJumpCount();

            }

        }

        private void HandlePlayerFlipping()
        {



            if (IsPlayerHasHorizontalSpeed())
            {
                float xDirection = Mathf.Sign(playerRigidbody2D.velocity.x);
                preDirectionX = xDirection;
                transform.localScale = new Vector3(xDirection, 1f, 1f);
            }
            else
            {
                transform.localScale = new Vector3(preDirectionX, 1f, 1f);
            }


        }

        private bool IsPlayerHasHorizontalSpeed()
        {
            return Mathf.Abs(playerRigidbody2D.velocity.x) > Mathf.Epsilon;
        }

        private void HandlePlayerMovement()
        {
            if (isPlayerHurt)
            {
                StartCoroutine(ResetPlayerHurtTrigger());
                return;

            }

            if (shooterMouse.IsPlayerLaserShooting()) return;


            var xMovement = PlayerInputValue.x * config.GetPlayerMoveSpeed(); ;
            playerRigidbody2D.velocity = new Vector2(xMovement,
                                                     playerRigidbody2D.velocity.y);


            playerAnimator.SetBool("isPlayerRuning", isPlayerRuning());


        }

        private IEnumerator ResetPlayerHurtTrigger()
        {
            yield return new WaitForSeconds(config.GetplayerHitRecoverTime());
            isPlayerHurt = false;
        }



        // function



        public void PlayerIsHurt() => isPlayerHurt = true;

        public void DisablePlayerInput()
        {
            playerInputValue = Vector2.zero;
        }



        private void PlayPlayerJumpEffect()
        {
            Vector3 offset = Vector3.up * 1f;
            Instantiate(playerJumpEffectPrefab, transform.position + offset, Quaternion.identity);
        }




        // player movement

        private void PlayerJump()
        {

            playerRigidbody2D.velocity += Vector2.up * config.GetPlayerJumpSpeed();


        }

        public void ResetJumpCount()
        {
            jumpCount = 0;
        }


        // checker

        public bool IsPlayerTouchingWall()
        {
            return
    playerCircleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"));

        }

        protected bool IsPlayerFrontSensorTouchingLayer(Layer layer)
        {
            return playerCircleCollider2D.IsTouchingLayers(
                LayerMask.GetMask(layer.ToString()));
        }

        public bool IsPlayerBodyTouchingLayer(Layer layer)
        {

            return playerRigidbody2D.IsTouchingLayers(
                LayerMask.GetMask(layer.ToString()));
        }


        public bool IsPlayerFeetTouchingLayer(Layer layer)
        {

            return PlayerBoxCollider2D.IsTouchingLayers(
                LayerMask.GetMask(layer.ToString()));
        }


        public bool IsplayerEndRecoverMotion() => hasPlayerEndJumpRecoverX && hasPlayerEndJumpRecoverY;


        bool isPlayerRuning()
        {
            return Mathf.Abs(playerRigidbody2D.velocity.x) > Mathf.Epsilon;
        }



        // check input situation

        //void OnMove(InputValue value)
        //{
        //    PlayerInputValue = value.Get<Vector2>();
        //}

        //public void OnMove(InputAction.CallbackContext context)
        //{
        //    PlayerInputValue = context.ReadValue<Vector2>();
        //}


        //void OnJump(InputValue value)
        //{
        //    if (value.isPressed)
        //    {

        //        if (jumpCount < playerConfig.GetPlayerMaxJumpCount())
        //        {
        //            PlayerJump();
        //            jumpCount++;

        //            PlayPlayerJumpEffect();

        //        }

        //        playerAnimator.SetBool("isPlayerJumping", true);

        //    }

        //}



        public void OnJump(InputAction.CallbackContext context)
        {


            playerRigidbody2D.gravityScale = Functions.GetPlayerNormalGravity();

            if (jumpCount < config.GetPlayerMaxJumpCount())
            {
                PlayerJump();
                jumpCount++;

                PlayPlayerJumpEffect();

            }

            playerAnimator.SetBool("isPlayerJumping", true);



        }

    }
}


