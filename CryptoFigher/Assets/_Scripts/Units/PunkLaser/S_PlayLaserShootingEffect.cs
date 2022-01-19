using CryptoFighter.n_Instaniate;
using UnityEngine;

namespace CryptoFighter.n_Unit.PunkLaser
{
    public class S_PlayLaserShootingEffect : MonoBehaviour
    {
        [SerializeField] private GameObject _laserEffect;
        [SerializeField] private S_InputBaseSpawnSystem _inputBaseSpawnSystem;

        private void Update()
        {
            _laserEffect.SetActive(_inputBaseSpawnSystem.IsSpawn);
        }
    }
}