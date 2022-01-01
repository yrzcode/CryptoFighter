using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CryptoFighter.n_Status;


namespace CryptoFighter.n_Unit._Enemy
{
    public class EnemyTracker : Enemy
    {

        [SerializeField] MoveSpeed _moveSpeed;
        [SerializeField] GameObject image;
        private Vector3 direction;

        private void Update()
        {

            //HandleEnemyMovement();
            HandleFlipping();
        }

        private void HandleFlipping()
        {
            image.transform.localScale = new Vector3(Mathf.Sign(direction.x),
               image.transform.localScale.y,
               image.transform.localScale.z);
        }

        //protected override void HandleEnemyMovement()
        //{

        //    direction = Player.punk.transform.position - transform.position;

        //    transform.Translate(Vector3.ClampMagnitude(direction, 1f) * _moveSpeed.CurrentMoveSpeed * Time.deltaTime);
        //}


        private void OnTriggerEnter2D(Collider2D collision)
        {


            if (collision.gameObject.CompareTag("Ground"))
            {
                playTrackerDestroyEffcet(config.WallDestroyEffect);

            }


            playTrackerDestroyEffcet(config.GetDestroyEffcet());

            Destroy(gameObject);

        }

        private void playTrackerDestroyEffcet(GameObject prefab)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}


