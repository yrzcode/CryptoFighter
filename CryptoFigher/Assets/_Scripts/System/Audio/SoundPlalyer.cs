using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CryptoFighter.n_Audio
{

    public class SoundPlayer : MonoBehaviour
    {

        [SerializeField] AudioSource _soundPlayer;


        public void PlayMusic(AudioClip sound)
        {
            _soundPlayer.PlayOneShot(sound);
        }

    }
}
