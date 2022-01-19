using CryptoFighter.n_InputSystem;
using UnityEngine;

namespace CryptoFighter.n_Sound
{
    public class S_LaserShootingSimpleSoundPlaySys : A_SimpleSoundPlaySys
    {
        [SerializeField] private InputSystemBaseController _input;
        
        private void Update()
        {
            _shouldPlaySound = _input.GetInputAction().Player.BigAttack.IsPressed();
            HandlePlaySound();

        }

        public override void HandlePlaySound()
        {
            if (_audioSources != null)
                foreach (var audioSource in _audioSources)
                {
                    audioSource.enabled = _shouldPlaySound;
                }
        }
    }
}