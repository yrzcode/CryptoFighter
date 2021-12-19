using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroier : MonoBehaviour
{
    [SerializeField] private float timeWaitToDestroy;

    private void Awake()
    {
        Destroy(gameObject, timeWaitToDestroy);
    }
}
