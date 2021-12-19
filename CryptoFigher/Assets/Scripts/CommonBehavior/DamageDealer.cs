using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] protected float damage;
    [SerializeField] protected AudioClip hitPlayerSound;
    [SerializeField] protected float hitPlayerSoundVolume;
    [SerializeField] protected float beatBackForce;

    protected void PlayDamageHitSound()
    {
        AudioSource.PlayClipAtPoint(hitPlayerSound, transform.position, hitPlayerSoundVolume);
    }

    protected void PlayPlayerHurtAnime()
    {
        PlayerPunk playerPunk = FindObjectOfType<PlayerPunk>();
        if (playerPunk != null)
        {
            Animator animator = playerPunk.GetComponentInChildren<Animator>();

            animator.Play("Base Layer.PlayerHurtAnime");
        }
    }

    protected void BeatBackTarget(GameObject target, float force)
    {
        Rigidbody2D rigidbody2D = target.GetComponent<Rigidbody2D>();

        if (rigidbody2D != null)
        {

            if (target.gameObject.CompareTag("Player"))
            {

                PlayerPunk playerPunk = target.gameObject.GetComponent<PlayerPunk>();



                playerPunk.PlayerIsHurt();
            }

            rigidbody2D.velocity -= new Vector2(target.transform.localScale.x * force, 0f);

        }
    }
}
