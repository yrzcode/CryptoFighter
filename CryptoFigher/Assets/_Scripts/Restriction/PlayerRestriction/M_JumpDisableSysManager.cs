using CryptoFighter.n_Instaniate;
using UnityEngine;

namespace CryptoFighter.n_Restriction
{
    public class M_JumpDisableSysManager : MonoBehaviour
    {
        [SerializeField] S_InputBaseSpawnSystem _inputBaseSpawnSystem;
        [SerializeField] private S_JumpDisableSys _jumpDisableSys;
        
        private void Update()
        {
            _jumpDisableSys.enabled = _inputBaseSpawnSystem.IsSpawn;
        }
    }
}