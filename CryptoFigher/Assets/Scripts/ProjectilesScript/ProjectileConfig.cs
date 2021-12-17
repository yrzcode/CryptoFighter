using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create ProjectileConfig", fileName = "new ProjetileConfig")]

public class ProjectileConfig : ScriptableObject
{

    [SerializeField] private float projectileSpeed;
    [SerializeField] private float waiteTimeToDestroy;


    public float GetProjectileSpeed() => projectileSpeed;
    public float GetWaitTimeToDestroy() => waiteTimeToDestroy;

}
