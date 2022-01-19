using CryptoFighter.n_Instaniate;
using UnityEngine;

namespace CryptoFighter.n_Restriction
{
    public class M_LaserShootJumpCountResetManager : MonoBehaviour
    {
        [SerializeField] private S_InputBaseSpawnSystem _inputBaseSpawnSystem;
        [SerializeField] private S_JumpCountResetSys _jumpCountResetSys;

        private void Update()
        {
            _jumpCountResetSys.enabled = _inputBaseSpawnSystem.IsSpawn;

        }
    }
}