using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : Enemy
{
    [SerializeField] private EnemyConfig bombEnemyConfig;

    private void Update()
    {
        HandleEnemyMovement();
        HandleEnemyMoveAnime();


    }

    private void HandleEnemyMoveAnime()
    {

        enemyAnimator.SetBool("isEnemyRuning", enemyHasHorizontalVelocity());

    }

    private bool enemyHasHorizontalVelocity()
    {
        return enemyRigidbody2D.velocity.x > Mathf.Epsilon;
    }

    protected override void HandleEnemyMovement()
    {
        enemyRigidbody2D.velocity = new Vector3(bombEnemyConfig.GetEnemyMoveSpeed(), 0f, 0f);
    }

}
