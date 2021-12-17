using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
               

public class Player : MonoBehaviour
{

    PlayerConfig playerConfig;

    private Vector2 playerInputValue;
    private Rigidbody2D playerRigidbody2D;
    private Animator playerAnimator;

    private float preDirectionX;
    private int jumpCount;

    private void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponentInChildren<Animator>();
        playerConfig = FindObjectOfType<PlayerPunk>().GetPlayerConfig();
    }

    private void Start()
    {
        preDirectionX = transform.localScale.x;
    }

    private void Update()
    {
        HandlePlayerMovement();

        HandlePlayerFlipping();

        HandlePlayerJumpingAnime();


    }



    //Handler
    private void HandlePlayerJumpingAnime()
    {
        if (!isPlayerTouchingGround())
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


        bool playerHasHorizontalSpeed = Mathf.Abs(playerRigidbody2D.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
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

    private void HandlePlayerMovement()
    {
        var xMovement = playerInputValue.x * playerConfig.GetPlayerMoveSpeed(); ;
        playerRigidbody2D.velocity = new Vector2(xMovement,
                                                 playerRigidbody2D.velocity.y);


        playerAnimator.SetBool("isPlayerRuning", isPlayerRuning());



    }



    //player movement
    private void PlayerJump()
    {

        playerRigidbody2D.velocity += Vector2.up * playerConfig.GetPlayerJumpSpeed();


    }

    private void ResetJumpCount()
    {
        jumpCount = 0;
    }


    //checker
    bool isPlayerTouchingGround()
    {
        return

        playerRigidbody2D.IsTouchingLayers(LayerMask.GetMask("Ground"));

    }

    bool isPlayerRuning()
    {
        return Mathf.Abs(playerRigidbody2D.velocity.x) > Mathf.Epsilon;
    }



    //check input situation
    void OnMove(InputValue value)
    {
        playerInputValue = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed)
        {

            if (jumpCount < playerConfig.GetPlayerMaxJumpCount())
            {
                PlayerJump();
                jumpCount++;

            }

            playerAnimator.SetBool("isPlayerJumping", true);

        }

    }

}
