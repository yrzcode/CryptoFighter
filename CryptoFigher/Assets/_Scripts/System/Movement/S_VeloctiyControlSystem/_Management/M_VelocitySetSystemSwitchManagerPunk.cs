using CryptoFighter.n_Instaniate;
using UnityEngine;

namespace CryptoFighter.n_Movement
{
    public class M_VelocitySetSystemSwitchManagerPunk : MA_VelocitySetSystemSwitchManager
    {
        [SerializeField] S_InputBaseSpawnSystem _inputBaseSpawnSystem;
        
        protected override void HandleVelocitySetting()
        {
            _currentSystem.SetVelocity();
        }

        protected override void Update()
        {
            SwitchSystemTo(_inputBaseSpawnSystem.IsSpawn
                ? E_VelocitySetSystem.InputBaseVelocitySetSystemXY
                : E_VelocitySetSystem.InputBaseVelocitySetSystemX);
            
            base.Update();
        }
    }
}