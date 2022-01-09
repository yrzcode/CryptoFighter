using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CryptoFighter.n_Restriction
{
    public class TopBouncy : MonoBehaviour
    {
        private BoxCollider2D topSensor;
        private Rigidbody2D rb;
        [SerializeField] private float bouncyForce;
        [SerializeField] private float downTime;

        private void Start()
        {
            topSensor = GetComponents<BoxCollider2D>()[1];
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (topSensor.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                rb.velocity += Vector2.down * bouncyForce;

                StartCoroutine(Functions.Co_DisablePlayerControl(downTime));
            }
        }
    }
}

