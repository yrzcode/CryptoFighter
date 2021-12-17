using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjetctileController : MonoBehaviour
{

    ProjectileConfig projectileConfig;

    protected float projectileDirection;


    private void Awake()
    {
        projectileConfig = FindObjectOfType<LaserController>().GetPrejectileConfig();

        projectileDirection = transform.localScale.x;


        Destroy(gameObject, projectileConfig.GetWaitTimeToDestroy());
    }


    protected virtual void HandleProjectileMovement()
    {
        transform.position += (Vector3)Vector2.right
                              * projectileDirection
                              * projectileConfig.GetProjectileSpeed()
                              * Time.deltaTime;
    }

    protected abstract void DestroyProjectile();
    

}

