using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CryptoFighter.n_Movement
{
    public class VelocityChangeSystemSwitchManager : MonoBehaviour,ISystemSwitchableManager
    {

        E_VelocityChangeSystem systems;

        [SerializeField] VeloctiyChangeSystem _currentSystem;

        [SerializeField] VeloctiyChangeSystem _inputBaseVelocityChangeSystem;


        private void Update()
        {
            if (_currentSystem != null) return;
            _currentSystem.ChangeVelocity();
        }

        public void SwitchSystemTo()
        {
            _currentSystem = null;
        }


        public void SwitchSystemTo(E_VelocityChangeSystem system)
        {
            switch (system)
            {
                case E_VelocityChangeSystem.InputBaseVelocityChangeSystem:
                    _currentSystem = _inputBaseVelocityChangeSystem;
                    break;
                default:
                    _currentSystem = null;
                    break;
            }


        }

    }
}

