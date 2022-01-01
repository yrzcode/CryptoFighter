using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CryptoFighter.n_Unit._Spawner
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemy;
        [SerializeField] private int maxSpwanAmount;
        [SerializeField] private float waitTime;
        [SerializeField] bool isRandPos;

        protected virtual void Start()
        {

            StartCoroutine(Spwan());

            if (isRandPos)
            {
                transform.position = Functions.GetRandPosInScreen(20, 15);

            }

        }

        private IEnumerator Spwan()
        {
            for (int i = 0; i < maxSpwanAmount; i++)
            {

                Instantiate(enemy, transform.position, Quaternion.identity);

                yield return new WaitForSeconds(waitTime);

            }

        }

    }
}

