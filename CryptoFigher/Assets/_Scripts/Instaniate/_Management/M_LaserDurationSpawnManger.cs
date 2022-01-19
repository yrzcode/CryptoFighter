using CryptoFighter.n_Restriction;
using UnityEngine;

namespace CryptoFighter.n_Instaniate
{
    public class M_LaserDurationSpawnManger : A_SpawnManger
    {
        [SerializeField] private S_LaserDurationCoolDownSys _laserDurationCoolDownSys;
        protected override void HandleSpawn()
        {
            if (!_laserDurationCoolDownSys.IsCoolDown)
            {
                foreach (var system in _spawnSystems)
                {
                    system.SpawnPrefabMatchCondition();
                }
            }
        }
    }
}