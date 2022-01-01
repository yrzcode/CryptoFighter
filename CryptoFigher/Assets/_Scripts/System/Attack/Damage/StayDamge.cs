using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CryptoFighter.n_Status;

public class StayDamge : MonoBehaviour, IStayDamge
{

    [SerializeField] int damage;
    [SerializeField] List<GameObject> targets;

    public int Damage { get => damage; private set => damage = value; }


    public void OnTriggerStay2D(Collider2D other)
    {
        foreach (var target in targets)
        {
            if (other.gameObject.CompareTag(target.tag))
            {
                Health health = other.gameObject.GetComponent<Health>();

                if (health != null)
                {
                    health.Decrease(damage * Time.deltaTime);

                }

            }
        }

    }

}
