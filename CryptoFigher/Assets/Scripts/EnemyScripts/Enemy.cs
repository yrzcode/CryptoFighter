using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(Animator))]



public abstract class Enemy : MonoBehaviour
{
    protected Rigidbody2D enemyRigidbody2D;
    protected Animator enemyAnimator;

    protected abstract void HandleEnemyMovement();


    private void Awake()
    {
       enemyRigidbody2D = GetComponent<Rigidbody2D>();
       enemyAnimator = GetComponent<Animator>();
    }

}
