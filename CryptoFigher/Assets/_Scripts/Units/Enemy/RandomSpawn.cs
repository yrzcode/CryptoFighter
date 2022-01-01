using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CryptoFighter
{
    public class RandomSpawn : MonoBehaviour
    {
        [SerializeField] GameObject prefab;
        [SerializeField] float SpawnInterval;
        [SerializeField] int spawnWave;
        [SerializeField] float WaveInterval;
        [SerializeField] GameObject SpawnEffect;


        private void Start()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            int counter = 0;
            while (true)
            {
                var spawnPos = GetSwpanPos();

                PlaySpawnEffect(spawnPos);
                Instantiate(prefab, spawnPos, Quaternion.identity);

                counter++;
                yield return new WaitForSeconds(SpawnInterval);

                if (counter % spawnWave == 0)
                {
                    yield return new WaitForSeconds(WaveInterval);
                    continue;
                }
            }

        }

        private Vector3 GetSwpanPos()
        {
            return Functions.GetRandPosInScreen(20, 15);
        }

        private void PlaySpawnEffect(Vector3 spawnPos)
        {
            if (SpawnEffect == null) return;
            Instantiate(SpawnEffect, spawnPos, Quaternion.Euler(90f, 0, 0));

        }
    }
}


