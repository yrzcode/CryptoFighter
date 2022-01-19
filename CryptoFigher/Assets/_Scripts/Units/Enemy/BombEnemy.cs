using UnityEngine;
using CryptoFighter.n_Status;

namespace CryptoFighter.n_Unit._Enemy
{
    public class BombEnemy : Enemy
    {

        [SerializeField] MoveSpeed _moveSpeed;

        private Animator enemyAnimator;

        protected override void Awake()
        {
            base.Awake();
            enemyAnimator = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            HandleEnemyMovement();
            HandleEnemyMoveAnime();
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            var preDirectionX = transform.localScale.x;
            var preDirectionY = transform.localScale.y;
            var preDirectionZ = transform.localScale.z;


            transform.localScale = new Vector3(-preDirectionX, preDirectionY, preDirectionZ);
        }


        private void HandleEnemyMoveAnime()
        {
            enemyAnimator.SetBool("isEnemyRuning", enemyHasHorizontalVelocity());

        }

        private bool enemyHasHorizontalVelocity()
        {
            return Mathf.Abs(enemyRigidbody2D.velocity.x) > Mathf.Epsilon;
        }

        protected void HandleEnemyMovement()
        {
            if (enemyRigidbody2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                enemyRigidbody2D.velocity =
               new Vector3(_moveSpeed.CurrentMoveSpeed * transform.localScale.x, 0f, 0f);
            }

        }

    }
}


