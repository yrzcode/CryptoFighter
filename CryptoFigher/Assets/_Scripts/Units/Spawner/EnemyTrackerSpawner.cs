using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CryptoFighter.n_Unit._Spawner
{
    public class EnemyTrackerSpawner : EnemySpawner
    {

        protected override void Start()
        {
            base.Start();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

            Destroy(gameObject);
        }

    }

}

