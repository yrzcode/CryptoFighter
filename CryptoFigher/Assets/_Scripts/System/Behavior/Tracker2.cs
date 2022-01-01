using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace CryptoFighter._Behavior
{
    public class Tracker2 : MonoBehaviour
    {
        [SerializeField] Transform targert;
        [SerializeField] float speed;

        private void Update()
        {
            transform.DOMove(targert.position,speed).SetEase(Ease.Linear);
        }
    }
}


