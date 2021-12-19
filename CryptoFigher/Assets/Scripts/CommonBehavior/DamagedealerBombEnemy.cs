using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedealerBombEnemy : DamageDealer
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            GetComponent<Bomber>().ExplpodeInmediately();
             other.gameObject.GetComponent<Player>().UpdatePlayerCurrentHealth(damage * Time.deltaTime);

            PlayDamageHitSound();

            BeatBackTarget(other.gameObject, beatBackForce);

        }

    }
}
    