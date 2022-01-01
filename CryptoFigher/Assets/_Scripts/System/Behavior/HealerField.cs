using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CryptoFighter.n_Status;


namespace CryptoFighter._Behavior
{
    public class HealerField : MonoBehaviour
    {
        [SerializeField] List<GameObject> targets;

        [SerializeField] int healAmount;
        [SerializeField] GameObject HealEffect;


        private void OnTriggerStay2D(Collider2D other)
        {
            foreach (var target in targets)
            {
                if (other.gameObject.CompareTag(target.tag))
                {
                    other.gameObject.GetComponent<Health>().Increase(healAmount * Time.deltaTime);

                    HealEffect.SetActive(true);

                }
            }

        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            HealEffect.SetActive(false);
        }
    }
}


