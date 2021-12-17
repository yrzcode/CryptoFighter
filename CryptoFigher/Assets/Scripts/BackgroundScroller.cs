using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    private Material _material;
    private Rigidbody2D playerRigidBody2D;


    [SerializeField] private float scrollSpeed;
    [SerializeField] private float transitionTime;
    [SerializeField] private float decelerateSpeed;


    private float timer;
    private float preDirectionX;



    private void Awake()
    {
        _material = GetComponent<SpriteRenderer>().material;
        playerRigidBody2D = FindObjectOfType<PlayerPunk>().GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        HandleBackgroundScroll();
    }


    private void HandleBackgroundScroll()
    {
        bool isPlayerHasHorizontalSpeed = Mathf.Abs(playerRigidBody2D.velocity.x) > Mathf.Epsilon;


        float scrollDirectionX = Mathf.Sign(playerRigidBody2D.velocity.x);

        Vector2 scrollDirection = new Vector2(scrollDirectionX, 0);


        if (isPlayerHasHorizontalSpeed)
        {
            _material.mainTextureOffset += scrollSpeed * scrollDirection * Time.deltaTime;
            preDirectionX = scrollDirectionX;
            timer = transitionTime;
        }
        else
        {
            timer -= Time.deltaTime;

            if (timer > 0)
            {
                float deceletareScrollSpeed = scrollSpeed - decelerateSpeed * Time.deltaTime;
                _material.mainTextureOffset += new Vector2(preDirectionX *
                    Mathf.Clamp(deceletareScrollSpeed, 0, float.MaxValue), 0) * Time.deltaTime;
            }
            else
            {
                timer = 0;
            }

        }

    }
}
