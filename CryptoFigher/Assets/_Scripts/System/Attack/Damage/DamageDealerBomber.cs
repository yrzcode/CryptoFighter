using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CryptoFighter.n_Attack.n_Damage
{

    public class DamageDealerBomber : DamageDealer
    {

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {

                PlayDamageHitSound();


            }

        }
    }
}


    