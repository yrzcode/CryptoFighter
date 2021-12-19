using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : Enemy
{

    private Animator enemyAnimator;
    private float _bombEnemyMoveSpeed;

    protected override void Awake()
    {
        base.Awake();
        enemyAnimator = GetComponentInChildren<Animator>();
        _bombEnemyMoveSpeed = enemyConfig.GetEnemyMoveSpeed();


    }




    private void Update()
    {
        HandleEnemyMovement();
        HandleEnemyMoveAnime();
        HandleEnemyFlipping();
        HandleEnemyFootFlipping();


    }

    private void HandleEnemyFootFlipping()
    {
        if (IsEnemyFootTouchingLayer(Layer.Ground)) return;
        FlipSelf();

    }

    private void HandleEnemyFlipping()
    {

        if (IsEnemySensorTouchingLayer(Layer.Ground) ||
            IsEnemySensorTouchingLayer(Layer.BombEnemy) ||
            IsEnemySensorTouchingLayer(Layer.Boundary))
        {
            var preDirectionX = transform.localScale.x;
            var preDirectionY = transform.localScale.y;
            var preDirectionZ = transform.localScale.z;


            transform.localScale = new Vector3(-preDirectionX, preDirectionY, preDirectionZ);
        }

    }


    private void HandleEnemyMoveAnime()
    {
        enemyAnimator.SetBool("isEnemyRuning", enemyHasHorizontalVelocity());

    }

    private bool enemyHasHorizontalVelocity()
    {
        return Mathf.Abs(enemyRigidbody2D.velocity.x) > Mathf.Epsilon;
    }

    protected override void HandleEnemyMovement()
    {

        enemyRigidbody2D.velocity =
            new Vector3(_bombEnemyMoveSpeed * transform.localScale.x, 0f, 0f);
    }

    public void UpdateBombEnmeyMoveSpeed(float v)
    {
        _bombEnemyMoveSpeed += v;
    }


   

}
