using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour
{
    [SerializeField] private float healAmount;
    [SerializeField] GameObject HealEffect;



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerPunk>().UpdatePlayerCurrentHealth(-healAmount);

            HealEffect.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            HealEffect.SetActive(false);

    }
}