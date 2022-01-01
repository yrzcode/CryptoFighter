using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CryptoFighter.n_Unit.n_Player;

namespace CryptoFighter.n_Attack._Motion
{
    public class BeatBackTriggerEnter : MonoBehaviour
    {
        [SerializeField] List<GameObject> targets;
        [SerializeField] float force;

        Player player;

        private void Awake()
        {
            player = FindObjectOfType<Player>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            foreach (var target in targets)
            {
                if (target.tag == other.gameObject.tag)
                {
                    BeatBackTarget(other.gameObject);
                }
            }

            if (other.CompareTag("Player"))
            {
                if (player == null) return;
                player.PlayerIsHurt();

            }
        }


        void BeatBackTarget(GameObject target)
        {
            Rigidbody2D rigidbody2D = target.GetComponent<Rigidbody2D>();

            if (rigidbody2D != null)
            {
                rigidbody2D.velocity -= new Vector2(target.transform.localScale.x * force, 0f);

            }


        }
    }
}



