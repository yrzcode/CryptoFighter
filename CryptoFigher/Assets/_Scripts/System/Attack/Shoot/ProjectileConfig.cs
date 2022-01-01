using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CryptoFighter.n_Attack.Prejectile
{
    [CreateAssetMenu(menuName = "Create ProjectileConfig", fileName = "new ProjetileConfig")]

    public class ProjectileConfig : ScriptableObject
    {

        [SerializeField] private float projectileSpeed;
        [SerializeField] private float waiteTimeToDestroy;


        [SerializeField] GameObject laserExplosionEffectPrefab;


        public float GetProjectileSpeed() => projectileSpeed;
        public float GetWaitTimeToDestroy() => waiteTimeToDestroy;

        public GameObject GetLaserExplosionEffectPrefab() => laserExplosionEffectPrefab;

    }
}


