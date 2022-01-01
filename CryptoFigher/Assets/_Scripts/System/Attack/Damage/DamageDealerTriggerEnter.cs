using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CryptoFighter.n_Status;
using CryptoFighter.n_Unit.n_Player;

namespace CryptoFighter.n_Attack.n_Damage
{
    public class DamageDealerTriggerEnter : MonoBehaviour
    {
        [SerializeField] int damage;
        [SerializeField] GameObject hitEffect;
        [SerializeField] AudioClip hitSound;
        [SerializeField] List<GameObject> targets;
        [SerializeField] GameObject effectPos;
        [SerializeField] Quaternion effectRotation;
        [SerializeField] float effectDuration;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (targets == null) return;

            foreach (var target in targets)
            {
                if (other.gameObject.tag == target.tag)
                {
                    other.gameObject.GetComponent<Health>().Decrease(damage);


                    if (hitSound != null)
                    {
                        Functions.PlaySound(hitSound, 0.5f);

                    }
                    if (hitEffect != null)
                    {
                        Functions.PlayEffect(hitEffect, effectPos, effectRotation, effectDuration);
                    }

                }
            }

        }
    }
}


