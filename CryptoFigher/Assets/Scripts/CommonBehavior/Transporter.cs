using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transporter : MonoBehaviour
{

    [SerializeField] Vector3 destination;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.position = destination;
    }

}
