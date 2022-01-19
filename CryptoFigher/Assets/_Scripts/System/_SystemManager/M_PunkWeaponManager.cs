using System;
using UnityEngine;
using CryptoFighter.n_InputSystem;

namespace CryptoFighter.n_Attack
{
    public class M_PunkWeaponManager : MonoBehaviour
    {
        [SerializeField] private InputSystemBaseController _input;
        [SerializeField] private GameObject _laser;
        private bool _isShootingLaser;

        private void Update()
        {
            HandlePunkLaser();
        }

        private void HandlePunkLaser()
        {
            _isShootingLaser = _input.GetInputAction().Player.BigAttack.IsPressed();
            _laser.SetActive(_isShootingLaser);
        }
    }
}

