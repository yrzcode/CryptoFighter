using UnityEngine;

namespace CryptoFighter.n_Movement
{
    public abstract class MA_VelocitySetSystemSwitchManager : MonoBehaviour, ISystemSwitchableManager
    {
        
        [SerializeField] VelocitySetSystem _velocitySetSystemX;
        [SerializeField] VelocitySetSystem _velocitySetSystemXY;
        [SerializeField] VelocitySetSystem _simpleVelocitySetSystem;

        protected VelocitySetSystem _currentSystem;

        private void Awake() => _currentSystem = _velocitySetSystemX;
        protected virtual void Update() => HandleVelocitySetting();
        protected abstract void HandleVelocitySetting();
        
        public void SwitchSystemTo() => _currentSystem = _velocitySetSystemX;

        public void SwitchSystemTo(E_VelocitySetSystem system)
        {
            _currentSystem = system switch
            {
                E_VelocitySetSystem.InputBaseVelocitySetSystemX => _velocitySetSystemX,
                E_VelocitySetSystem.InputBaseVelocitySetSystemXY => _velocitySetSystemXY,
                E_VelocitySetSystem.SimpleVelocitySetSystemXY => _simpleVelocitySetSystem,
                _ => _velocitySetSystemX
            };
        }

        public enum E_VelocitySetSystem 
        {
            InputBaseVelocitySetSystemX,
            InputBaseVelocitySetSystemXY,
            SimpleVelocitySetSystemXY
        }
        
    }
    
}
