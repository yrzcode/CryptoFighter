using CryptoFighter.n_Instaniate;
using UnityEngine;
using CryptoFighter.n_Sensor;

namespace CryptoFighter.n_Movement
{
    public class M_GravitySetSystemManager : MonoBehaviour,ISystemSwitchableManager
    {
        [SerializeField] A_GravitySetSystem _currentGravitySetSystem;
        
        [SerializeField] private A_GravitySetSystem _basicGravitySetSystem;

        [SerializeField] private A_GravitySetSystem _climbingGravitySetSystem;
        [SerializeField] private A_StaySensor _boxStaySensor;
        
        [SerializeField] private A_GravitySetSystem _laserShootingGravitySetSys;
        [SerializeField] S_InputBaseSpawnSystem _inputBaseSpawnSystem;



        private void Awake() => _currentGravitySetSystem = _basicGravitySetSystem;

        void Update()
        {
            HandleSwitchGravitySetSystem();
            _currentGravitySetSystem.SetGravity();
        }
        
        
        private void HandleSwitchGravitySetSystem()
        {
            var isClimbing = _boxStaySensor.IsTouchingTarget();
            var isLaserShooting = _inputBaseSpawnSystem.IsSpawn;
            
            _currentGravitySetSystem = isClimbing ? _climbingGravitySetSystem : isLaserShooting ? _laserShootingGravitySetSys: _basicGravitySetSystem;
     
        }
        
        public void SwitchSystemTo() => _currentGravitySetSystem = null;

        public void SwitchSystemTo(E_GravitySetSystem gravitySetSystem)
        {
            _currentGravitySetSystem = gravitySetSystem switch
            {
                E_GravitySetSystem.BasicGravitySetSystem => _basicGravitySetSystem,
                E_GravitySetSystem.ClimbingGravitySetSystem => _climbingGravitySetSystem,
                E_GravitySetSystem.LaserShootingGravitySetSystem => _laserShootingGravitySetSys,
                _ => _basicGravitySetSystem
            };
        }
        public enum E_GravitySetSystem
        {
            BasicGravitySetSystem,
            ClimbingGravitySetSystem,
            LaserShootingGravitySetSystem
        }
      
    }
 

}

