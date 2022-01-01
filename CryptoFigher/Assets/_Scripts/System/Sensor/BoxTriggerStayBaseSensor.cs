using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CryptoFighter._Sensor
{
    public class BoxTriggerStayBaseSensor : MonoBehaviour, _ITouchingSensor
    {

        [SerializeField] List<string> tags;
        [SerializeField] BoxCollider2D _boxCollider2D;


        bool isTouchingTarget;

        public bool IsTouchingTarget { get => isTouchingTarget; }


        void OnTriggerStay2D(Collider2D collision)
        {
            foreach (var tag in tags)
            {
                if (collision.CompareTag(tag))
                {
                    isTouchingTarget = true;
                }
            }
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            foreach (var tag in tags)
            {
                if (collision.CompareTag(tag))
                {
                    isTouchingTarget = false;
                }
            }

        }


    }

}


