using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetctileController : MonoBehaviour
{
    private ProjectileConfig projectileConfig;
    private PlayerPunk playerPunk;
    private float projectileDirection;

    private void Awake()
    {
        projectileConfig = FindObjectOfType<LaserController>().GetPrejectileConfig();
        playerPunk = FindObjectOfType<PlayerPunk>();
        projectileDirection = playerPunk.transform.localScale.x;

        Invoke("DestroyProjectile", projectileConfig.GetWaitTimeToDestroy());

    }

    private void Update()
    {
        HandleProjectileMovement();
    }

    protected virtual void HandleProjectileMovement()
    {
        transform.position += (Vector3)Vector2.right
                              * projectileDirection
                              * projectileConfig.GetProjectileSpeed()
                              * Time.deltaTime;
    }

    protected virtual void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}

