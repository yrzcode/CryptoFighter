using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CryptoFighter.n_Unit._Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected EnemyConfig config;


        protected Rigidbody2D enemyRigidbody2D;
        protected CircleCollider2D enemyCircleCollider2D;
        protected BoxCollider2D enemyBoxCollider2D;


        protected virtual void Awake()
        {
            enemyRigidbody2D = GetComponent<Rigidbody2D>();
            enemyCircleCollider2D = GetComponent<CircleCollider2D>();
            enemyBoxCollider2D = GetComponent<BoxCollider2D>();

        }

        protected bool IsEnemySensorTouchingLayer(Layer layer)
        {
            return enemyCircleCollider2D.IsTouchingLayers(
                LayerMask.GetMask(layer.ToString()));
        }


        protected bool IsEnemyFootTouchingLayer(Layer layer)
        {
            return enemyBoxCollider2D.IsTouchingLayers(
                LayerMask.GetMask(layer.ToString()));
        }


        protected void FlipSelf()
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        //protected abstract void HandleEnemyMovement();

    }
}


