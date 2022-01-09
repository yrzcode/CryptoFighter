using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CryptoFighter.n_Restriction
{
    public class MustTouchGround : MonoBehaviour
    {
        Coroutine DestroyCoroutine;
        float timer = 0;


        [SerializeField] float destroyTime;
        [SerializeField] Rigidbody2D _rigidbody2D;
        [SerializeField] SpriteRenderer _spriteRenderer;


        void Start()
        {

            _spriteRenderer.enabled = true;

            DestroyCoroutine = StartCoroutine(DestroySelf());


        }

        private void Update()
        {
            if (_rigidbody2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                _spriteRenderer.enabled = true;

                StopCoroutine(DestroyCoroutine);

            }
        }

        private IEnumerator DestroySelf()
        {

            while (timer < destroyTime)
            {
                timer += Time.deltaTime;
                yield return null;
            }

            timer = 0;
            Destroy(gameObject);

        }

    }

}


