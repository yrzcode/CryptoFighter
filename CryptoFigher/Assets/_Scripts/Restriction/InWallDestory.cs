using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CryptoFighter._Restriction
{

    public class InWallDestory : MonoBehaviour
    {

        private CapsuleCollider2D _capsuleCollider2D;

        void Start()
        {
            _capsuleCollider2D = GetComponents<CapsuleCollider2D>()[1];
        }

        void Update()
        {
            if (_capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {

                Destroy(gameObject);
            }

        }
    }


}
