using System;
using CryptoFighter.n_Instaniate;
using UnityEngine;

namespace CryptoFighter.n_Unit.PunkLaser
{
    public class S_LaserShootingDisableImage : MonoBehaviour
    {
        [SerializeField] private S_InputBaseSpawnSystem _laserShooter;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private void Update()
        {
            _spriteRenderer.enabled = !_laserShooter.IsSpawn;
        }
    }
}