using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealerFire : DamageDealer
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().UpdatePlayerCurrentHealth(damage * Time.deltaTime);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayPlayerHurtAnime();
            PlayDamageHitSound();

            BeatBackTarget(other.gameObject, beatBackForce);
                
        }

    }


}
